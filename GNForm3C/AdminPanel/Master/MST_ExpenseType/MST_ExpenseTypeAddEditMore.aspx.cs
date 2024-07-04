using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddEditMore : System.Web.UI.Page
{

    #region 10.0 Local Variables

    String FormName = "MST_ExpenseTypeAddEditMore";
    #endregion 10.0 Variables

    #region 11.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {

        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        #region 11.6 View State

        if (ViewState["DataTable"] == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ExpenseType");
            dt.Columns.Add("Hospital");
            dt.Columns.Add("HospitalID");
            dt.Columns.Add("Remarks");
            ViewState["DataTable"] = dt;
        }

        #endregion 11.6 View State

        if (!Page.IsPostBack)
        {

            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderAddEditMore + " Expense Type";
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

    #region 14.0 Add More Button Click Event
    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                if (txtExpenseType.Text.Trim() != string.Empty && ddlHospitalID.SelectedIndex > 0)
                {
                    Div_ShowResult.Visible = true;

                    DataTable dt = (DataTable)ViewState["DataTable"];

                    DataRow dr = dt.NewRow();
                    dr["ExpenseType"] = txtExpenseType.Text.Trim();
                    dr["Hospital"] = ddlHospitalID.SelectedItem;
                    dr["HospitalID"] = ddlHospitalID.SelectedIndex;
                    dr["Remarks"] = txtRemarks.Text.Trim();

                    dt.Rows.Add(dr);

                    rpData.DataSource = dt;
                    rpData.DataBind();
                    ClearControls();
                }
                else if (txtExpenseType.Text.Trim() == string.Empty && ddlHospitalID.SelectedIndex == 0)
                {
                    ucMessage.ShowError(CommonMessage.ErrorRequiredField("Expense Type"));
                    ucMessage1.ShowError(CommonMessage.ErrorRequiredFieldDDL("Hospital"));
                }
                else if (txtExpenseType.Text.Trim() == string.Empty)
                {
                    ucMessage.ShowError(CommonMessage.ErrorRequiredField("Expense Type"));

                }
                else if (ddlHospitalID.SelectedIndex == 0)
                {
                    ucMessage1.ShowError(CommonMessage.ErrorRequiredFieldDDL("Hospital"));
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion 14.0 Add More Button Click Event

    #region 15.0 Repeater Item Command
    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        #region 15.1 Edit Record
        if (e.CommandName == "EditRecord")
        {

            try
            {
                if (txtExpenseType.Text.Trim() == string.Empty && ddlHospitalID.SelectedIndex == 0)
                {
                    btnAddMore.Visible = false;
                    btnUpdate.Visible = true;
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    DataTable dt = (DataTable)ViewState["DataTable"];
                    txtExpenseType.Text = dt.Rows[rowIndex]["ExpenseType"].ToString();
                    ddlHospitalID.SelectedIndex = Convert.ToInt32(dt.Rows[rowIndex]["HospitalID"]);
                    txtRemarks.Text = dt.Rows[rowIndex]["Remarks"].ToString();
                    dt.Rows.RemoveAt(rowIndex);
                    ViewState["DataTable"] = dt;
                    rpData.DataSource = dt;
                    rpData.DataBind();
                    if (dt.Rows.Count == 0)
                    {
                        Div_ShowResult.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }

        }
        #endregion 15.1 Edit Record

        #region 15.2 Delete Record

        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                DataTable dt = (DataTable)ViewState["DataTable"];
                dt.Rows.RemoveAt(rowIndex);
                ViewState["DataTable"] = dt;
                rpData.DataSource = dt;
                rpData.DataBind();
                if (dt.Rows.Count == 0)
                {
                    Div_ShowResult.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }

        #endregion 15.2 Delete Record

    }

    #endregion 15.0 Repeater Item Command

    #region 16.0 Save Button Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Page.Validate();


        Div_ShowResult.Visible = false;
        MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
        MST_ExpenseTypeENT entMST_ExpenseType = new MST_ExpenseTypeENT();

        foreach (RepeaterItem Ri in rpData.Items)
        {
            try
            {

                #region 15.1.0 Parameter
                Label lblExpenseType = (Label)Ri.FindControl("lblExpenseType");
                Label lbhRemarks = (Label)Ri.FindControl("lbhRemarks");
                HiddenField hfHospitalID = (HiddenField)Ri.FindControl("hfHospitalID");
                #endregion 15.1.0 Parameter

                #region 15.2.1 Gather Data
                entMST_ExpenseType.ExpenseType = lblExpenseType.Text.Trim();
                entMST_ExpenseType.HospitalID = Convert.ToInt32(hfHospitalID.Value);
                entMST_ExpenseType.Remarks = lbhRemarks.Text.Trim();
                entMST_ExpenseType.UserID = Convert.ToInt32(Session["UserID"]);
                entMST_ExpenseType.Created = DateTime.Now;
                entMST_ExpenseType.Modified = DateTime.Now;
                #endregion 15.2.1 Gather Data

                if (balMST_ExpenseType.Insert(entMST_ExpenseType))
                {
                    ucMessage.ShowSuccess(CommonMessage.RecordSaved());

                }

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }


    }

    #endregion 16.0 Save Button Click Event

    #region 17.0 Update Button Click Event
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnAddMore.Visible = true;
        btnAddMore_Click(sender, e);
    }

    #endregion 17.0 Update Button Click Event

    #region 18.0 Clear Controls
    private void ClearControls()
    {
        txtExpenseType.Text = "";
        txtRemarks.Text = "";
        ddlHospitalID.SelectedIndex = 0;
    }
    #endregion 18.0 Clear Controls

}