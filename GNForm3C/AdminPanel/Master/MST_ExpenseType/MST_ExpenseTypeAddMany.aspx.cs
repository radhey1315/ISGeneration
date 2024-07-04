using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System.Data.SqlTypes;


public partial class AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddMany : System.Web.UI.Page
{

    #region 10.0 Local Variables

    String FormName = "MST_ExpenseTypeAddMany";

    #endregion 10.0 Variables

    #region 11.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["HospitalID"] != null)
            {
                btnShow_Click(sender, e);
            }

            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderAddMany + " Expense Type";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 11.4 Set Control Default Value

            #region 11.5 Set Help Text

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.5 Set Help Text

        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 

    #region 13.0 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 Show Button Event

    protected void btnShow_Click(object sender, EventArgs e)
    {
        #region Parameters
        SqlInt32 HospitalID = SqlInt32.Null;
        #endregion Parameters

      
        // gather data load karavana bakii che !
        
        #region Gather Data
        if (Request.QueryString["HospitalID"] != null)
        {
            if (!Page.IsPostBack)
            {
                HospitalID = CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]);
                // ddlHospitalID.SelectedValue = Convert.ToInt32(HospitalID);
            }
            else
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        }
        else
        {
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        }
        #endregion Gather Data

        #region Show Repeater 

        DataTable dtBlank = new DataTable();

        for (int i = 0; i < 10 ; i++)
        {
            DataRow dtRow = dtBlank.NewRow();
            dtBlank.Rows.Add(dtRow);
        }

        rpData.DataSource = dtBlank;
        rpData.DataBind();


        MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
        DataTable dt = balMST_ExpenseType.SelectShow(HospitalID);


        if (Request.QueryString["HospitalID"] != null)
            ddlHospitalID.SelectedValue = Convert.ToString(dt.Rows[0]["HospitalID"]);
        foreach (DataRow dtRow in dt.Rows)
        {
            foreach (RepeaterItem Ri in rpData.Items)
            {
                TextBox txtExpenseType = (TextBox)Ri.FindControl("txtExpenseType");
                TextBox txtRemarks = (TextBox)Ri.FindControl("txtRemarks");
                HiddenField hfExpenseTypeID = (HiddenField)Ri.FindControl("hfExpenseTypeID");
                CheckBox chkIsSelected = (CheckBox)Ri.FindControl("chkIsSelected");

                if (hfExpenseTypeID.Value == string.Empty)
                {
                    if (!dtRow["ExpenseType"].Equals(DBNull.Value))
                    {
                        txtExpenseType.Text = dtRow["ExpenseType"].ToString();
                        txtRemarks.Text = dtRow["Remarks"].ToString();
                        hfExpenseTypeID.Value = dtRow["ExpenseTypeID"].ToString();
                        chkIsSelected.Checked = true;   
                    }
                    break;
                }
            }
        }

        int count = 1;
        foreach (RepeaterItem Ri in rpData.Items)
        {
            Label lblSrNo = (Label)Ri.FindControl("lblSrNo");
            lblSrNo.Text = count.ToString();
            count++;
        }

        Div_ShowResult.Visible = true;
        
        #endregion Show Repeater 
    }

    #endregion 14.0 Show Button Event

    #region 15.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {

            SqlInt32 HospitalID = SqlInt32.Null;

            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

            MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
            MST_ExpenseTypeENT entMST_ExpenseType = new MST_ExpenseTypeENT();

            #region 15.1 Save For Repeater 
            foreach (RepeaterItem Ri in rpData.Items)
            {
                try
                {

                    #region 15.1.0 Parameter
                    TextBox txtExpenseType = (TextBox)Ri.FindControl("txtExpenseType");
                    TextBox txtRemarks = (TextBox)Ri.FindControl("txtRemarks");
                    HiddenField hfExpenseTypeID = (HiddenField)Ri.FindControl("hfExpenseTypeID");
                    CheckBox chkIsSelected = (CheckBox)Ri.FindControl("chkIsSelected");
                    #endregion 15.1.0 Parameter

                    #region 15.2.1 Gather Data
                    entMST_ExpenseType.ExpenseType = txtExpenseType.Text.Trim();
                    entMST_ExpenseType.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                    entMST_ExpenseType.Remarks = txtRemarks.Text.Trim();
                    entMST_ExpenseType.UserID = Convert.ToInt32(Session["UserID"]);
                    entMST_ExpenseType.Created = DateTime.Now;
                    entMST_ExpenseType.Modified = DateTime.Now;
                    #endregion 15.2.1 Gather Data

                    if (txtExpenseType.Text.Trim() != string.Empty)
                    {
                        //if (dt.Rows.Count == 0 || dt.Rows[i]["ExpenseType"].ToString() != txtExpenseType.Text.Trim() || dt.Rows[i]["Remarks"].ToString() != txtRemarks.Text.Trim())
                        //{

                            if (hfExpenseTypeID.Value != string.Empty)
                            {
                                #region 15.1.1 Gather Data
                                entMST_ExpenseType.ExpenseTypeID = Convert.ToInt32(hfExpenseTypeID.Value);
                                #endregion 15.1.1 Gather Data

                                if (chkIsSelected.Checked)
                                {
                                    #region 15.1.2 Update
                                    if (balMST_ExpenseType.Update(entMST_ExpenseType))
                                    {
                                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                    }
                                    else
                                    {
                                        ucMessage.ShowError(balMST_ExpenseType.Message);
                                    }
                                    #endregion 15.1.2 Update
                                }
                                else
                                {
                                    #region 15.1.2 Update
                                    if (balMST_ExpenseType.Delete(entMST_ExpenseType.ExpenseTypeID))
                                    {
                                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                    }
                                    else
                                    {
                                        ucMessage.ShowError(balMST_ExpenseType.Message);
                                    }
                                    #endregion 15.1.2 Update
                                }
                                
                            }
                            else
                            {
                                if (chkIsSelected.Checked)
                                {
                                    #region 15.1.2 Insert
                                    if (balMST_ExpenseType.Insert(entMST_ExpenseType))
                                    {
                                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());

                                    }
                                    #endregion 15.1.2 Insert
                                }
                                
                            }
                        //}
                    }


                    else if (txtExpenseType.Text.Trim() == string.Empty && txtRemarks.Text.Trim() != string.Empty)
                    {
                        ucMessage.ShowError("Enter Expense Type");
                        break;
                    }
                }


                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }
            }

            #endregion 15.1 Save For Repeater 

            
            ClearControls();
            Div_ShowResult.Visible = false;
            
        }
    }
    #endregion 15.0 Save Button Event

    #region 16.0 Clear Controls
    private void ClearControls()
    {
      ddlHospitalID.SelectedIndex = 0;
    }
    #endregion 16.0 Clear Controls
}