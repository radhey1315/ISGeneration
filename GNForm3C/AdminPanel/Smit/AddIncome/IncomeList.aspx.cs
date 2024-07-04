using GNForm3c.BAL;
using GNForm3C;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Smit_AddIncome_IncomeList : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        ucHelp.ShowHelp("Help Text will be shown here");
        if(!Page.IsPostBack)
        { 
            fillData();
            DeleteManyCancelControls();
        }

    }
    #endregion PageLoad

    #region Delete
    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (balIncomeType.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        fillData();
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }
    }
    #endregion Delete

    #region Repeater Fill

    protected void fillData()
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        DataTable dt = new DataTable();
        dt = balIncomeType.SelectAll(Convert.ToInt32(Session["UserID"]));

        if (dt != null && dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();
            Div_SearchResult.Visible = true;
            lblSearchField.Visible = true;

        }
        else
        {
            Div_SearchResult.Visible = false;
            lblSearchField.Visible = false;
        }

        CommonFillMethodsSmit.FillDropDownFinYear(ddlFinYearID);
        CommonFillMethodsSmit.FillDropDownHospital(ddlHospitalID);
        CommonFillMethodsSmit.FillDropDownIncomeType(ddlIncomeTypeID);

    }

    #endregion Repeater Fill

    #region Search

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        IncomeType entIncomeType = new IncomeType();

        if (ddlFinYearID.SelectedIndex != 0)
            entIncomeType.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

        if (ddlHospitalID.SelectedIndex != 0)
            entIncomeType.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        if (ddlIncomeTypeID.SelectedIndex != 0)
            entIncomeType.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);

        if (txtAmount.Text.Trim() != "")
            entIncomeType.Amount = Convert.ToDecimal(txtAmount.Text.Trim());

        if (txtRemarks.Text.Trim() != "")
            entIncomeType.Remarks = txtRemarks.Text.Trim().ToString();

        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        DataTable dt = new DataTable();
        dt = balIncomeType.Search(entIncomeType);


        if (dt != null && dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();
            lblSearchField.Visible = true;
            Div_SearchResult.Visible = true;

        }
        else
        {
            Div_SearchResult.Visible = false;
            lblSearchField.Visible = false;
            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }

    }

    #endregion Search

    #region Clear Search Controlls
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtAmount.Text = "";
        txtRemarks.Text = "";
        ddlFinYearID.SelectedIndex = -1;
        ddlHospitalID.SelectedIndex = -1;
        ddlIncomeTypeID.SelectedIndex = -1;
        fillData();
    }

    #endregion Clear Search Controlls

    #region ddlHospital Change Index
    protected void ddlHospitalID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHospitalID.SelectedIndex == 0)
            CommonFillMethodsSmit.FillDropDownIncomeType(ddlIncomeTypeID);
        else 
            FillDropDownIncomeTypeByHospital(Convert.ToInt32(ddlHospitalID.SelectedValue));
    }
    #endregion ddlHospital Change Index

    #region FillDropDown By Hospital
    public void FillDropDownIncomeTypeByHospital(SqlInt32 HospitalID)
    {
        CommonFillMethodsSmit.FillDropDownIncomeTypeByHospital(ddlIncomeTypeID, HospitalID);
    }
    #endregion FillDropDown By Hospital

    #region ddlIncomeTypeID Index Changed
    protected void ddlIncomeTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIncomeTypeID.SelectedIndex == 0)
        {
            ddlHospitalID.SelectedIndex = 0;
            CommonFillMethodsSmit.FillDropDownIncomeType(ddlIncomeTypeID);
        }
    }
    #endregion ddlIncomeTypeID Index Changed

    #region DeleteMany Cancel
    protected void btnDeleteCancel_Click(object sender, EventArgs e)
    {
        DeleteManyCancelControls();
    }
    #endregion DeleteMany Cancel

    #region DeleteMany Cancel controls
    protected void DeleteManyCancelControls()
    {
        lbtnDeleteMany.Visible = true;
        btnDeleteCancel.Visible = false;
        lblDeleteVisible.Visible = false;
        lbtnDelete.Visible = false;
    }
    #endregion DeleteMany Cancel controls

    #region DeleteMany Button
    protected void lbtnDeleteMany_Click(object sender, EventArgs e)
    {
        DeleteManyButtonControls();
    }
    #endregion DeleteMany Button

    #region DeleteMany Button controls
    protected void DeleteManyButtonControls()
    {
        lbtnDeleteMany.Visible = false;
        btnDeleteCancel.Visible = true;
        lblDeleteVisible.Visible = true;
        lbtnDelete.Visible = true;
    }
    #endregion DeleteMany Button controls

    #region Delete Multiple
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rpData.Items)
        {
            if(item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox cb = (CheckBox)item.FindControl("cbkDelete");
                
                if(cb.Checked)
                {
                    HiddenField hfield = (HiddenField)item.FindControl("hfIncomeID");
                    int IncomeID = Convert.ToInt32(hfield.Value);
                    IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
                    balIncomeType.Delete(Convert.ToInt32(IncomeID));
                }
            }
        }
        fillData();
        DeleteManyCancelControls();
    }
    #endregion Delete Multiple

    #region CheckBox SelectAll
    protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
    {

    }
    #endregion CheckBox SelectAll

}
