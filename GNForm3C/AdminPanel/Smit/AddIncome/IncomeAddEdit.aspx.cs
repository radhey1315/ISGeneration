using GNForm3c.BAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Smit_AddIncome_IncomeAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        // ucHelp.ShowHelp("Help Text will be shown here");

        if (!Page.IsPostBack)
        {
            FillDropDown();
            FillCheckboxList();
           
            if (Request.QueryString["IncomeID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["IncomeID"]));
            }
        }
    }

    #endregion Page Load

    #region btn:Save

    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region ServerSide Validation

        if (ddlIncomeTypeID.SelectedIndex == 0)
        {
            return;
        }

        if (ddlHospitalName.SelectedIndex == 0)
        {
            return;
        }

        if (ddlFinYear.SelectedIndex == -1)
        {
            return;
        }

        if (dtpIncomeDate.Text == null)
        {
            return;
        }

        if (txtAmount.Text == null)
        {
            return;
        }
        
        #endregion ServerSide Validation

        #region GatherData

        IncomeType entIncomeType = new IncomeType();

        if (ddlIncomeTypeID.SelectedIndex != 0)
            entIncomeType.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);

        if (txtAmount.Text.Trim() != "")
            entIncomeType.Amount = Convert.ToDecimal(txtAmount.Text.Trim());

        if (dtpIncomeDate.Text.Trim() != String.Empty)
            entIncomeType.IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text.Trim(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

        if (txtNote.Text.Trim() != "")
            entIncomeType.Note = txtNote.Text.Trim();


        if (ddlHospitalName.SelectedIndex != 0)
            entIncomeType.HospitalID = Convert.ToInt32(ddlHospitalName.SelectedValue);

        if (ddlFinYear.SelectedIndex != -1)
            entIncomeType.FinYearID = Convert.ToInt32(ddlFinYear.SelectedValue);

        if (txtRemark.Text.Trim() != "")
            entIncomeType.Remarks = txtRemark.Text.Trim();


        foreach (ListItem cblItem in cblSalary.Items)
        {
            if (cblItem.Selected)
            {
                entIncomeType.cblSalary.Add(Convert.ToInt32(cblItem.Value));
            }
        }


        entIncomeType.UserID = Convert.ToInt32(Session["UserID"]);

        entIncomeType.Created = DateTime.Now;
        entIncomeType.Modified = DateTime.Now;
        
        #endregion GatherData

        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        
        if(Request.QueryString["IncomeID"] == null )
        {
            if (balIncomeType.Insert(entIncomeType))
            {
                lblMess.Visible = true;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = entIncomeType.Message;
                ClearControls();
            }
            else
            {
                lblMess.Visible = true;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = entIncomeType.Message;
            }
        }
        else
        {
            entIncomeType.IncomeID = Convert.ToInt32(Request.QueryString["IncomeID"]);
            if (balIncomeType.Update(entIncomeType))
            {
                lblMess.Visible = true;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = entIncomeType.Message;
                Response.Redirect("~/AdminPanel/Smit/AddIncome/IncomeList.aspx");
            }
            else
            {
                lblMess.Visible = true;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = entIncomeType.Message;
            }
        } 

    }

    #endregion btn:Save

    #region Fill DropDown

    public void FillDropDown() 
    {
        CommonFillMethodsSmit.FillDropDownIncomeType(ddlIncomeTypeID);
        CommonFillMethodsSmit.FillDropDownHospital(ddlHospitalName);

        String date = DateTime.Now.ToString("yyyy-MM-dd");
        CommonFillMethodsSmit.FillDropDownFinYear(date, ddlFinYear);

        dtpIncomeDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        
    }

    #endregion Fill DropDown

    #region FillCheckboxList
    protected void FillCheckboxList()
    {
        CommonFillMethodsSmit.FillCheckboxList(cblSalary);
    }
    #endregion FillCheckboxList

    #region ClearControls
    private void ClearControls()
    {
        ddlIncomeTypeID.Items.Clear();
        ddlHospitalName.Items.Clear();
        ddlFinYear.Items.Clear();
        txtAmount.Text = "";
        txtNote.Text = "";
        txtRemark.Text = "";
        dtpIncomeDate.Text = "";
        FillDropDown();
        foreach (ListItem cblItem in cblSalary.Items)
        {
            if (cblItem.Selected)
            {
                cblItem.Selected = false;
            }
        }
    }
    #endregion ClearControls

    #region FillControls
    private void FillControls(SqlInt32 IncomeTypeID)
    {
        IncomeType entIncomeType = new IncomeType();
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();

        entIncomeType = balIncomeType.SelectByPK(IncomeTypeID);

        if (!entIncomeType.IncomeTypeID.IsNull)
        {
            ddlIncomeTypeID.SelectedValue = entIncomeType.IncomeTypeID.ToString();
        }

        if (!entIncomeType.HospitalID.IsNull)
        {
            ddlHospitalName.SelectedValue = entIncomeType.HospitalID.ToString();
        }

        if (!entIncomeType.FinYearID.IsNull)
        {
            ddlFinYear.SelectedValue = entIncomeType.FinYearID.ToString();
        }

        if (!entIncomeType.IncomeDate.IsNull)
        {
            dtpIncomeDate.Text = Convert.ToDateTime(entIncomeType.IncomeDate.ToString()).ToString("dd-MM-yyyy");
        }

        if (!entIncomeType.Amount.IsNull)
        {
            txtAmount.Text = entIncomeType.Amount.ToString();
        }

        if (!entIncomeType.Note.IsNull)
        {
            txtNote.Text = entIncomeType.Note.ToString();
        }

        if (!entIncomeType.Remarks.IsNull)
        {
            txtRemark.Text = entIncomeType.Remarks.ToString();
        }

        if (entIncomeType.cblSalary != null)
        {
            int i = 0;
            foreach (ListItem cblItem in cblSalary.Items)
            {
                if ((i) < entIncomeType.cblSalary.Count)
                {
                    if (entIncomeType.cblSalary[i].ToString() == cblItem.Value.ToString())
                    {
                        cblItem.Selected = true;
                        i++;
                    }
                }
            }
        }

    }
    #endregion FillControls


}