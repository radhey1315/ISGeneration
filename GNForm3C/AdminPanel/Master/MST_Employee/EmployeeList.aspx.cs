using GnForm3C.ENT;
using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Employee_EmployeeList : System.Web.UI.Page
{
    String FormName = "MST_EmployeeList";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    #region Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        if (!Page.IsPostBack)
        {
            Search(1);
            FillDropDownList();
            CommonFunctions.GetDropDownPageSize(ddlPageSizeBottom);
            ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
        }

    }
    #endregion Page Load event

    #region 13.0 FillLabels 

    private void FillLabels(String FormName)
    {
    }

    #endregion

    
    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    #endregion 15.1 Button Search Click Event
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListDepartmentID(ddlDepartmentName);
    }
    #region Bind Employee
    private void BindEmployeeData()
    {
        MST_EmployeeBALBase EmployeeBAL = new MST_EmployeeBALBase();
        DataTable dt = new DataTable();
        dt = EmployeeBAL.SelectAll();

        if (dt != null && dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();
            Div_SearchResult.Visible = true;
            

        }
        else
        {
            Div_SearchResult.Visible = false;

        }
        FillDropDownList(); 
    }

    #endregion Bind Employee

    #region 15.0 Search

    #region 15.2 Search Function

    private void Search(int PageNo)
    {
        #region Parameters
        SqlString EmpName = SqlString.Null;
        SqlString EmpCode = SqlString.Null;
        SqlInt32 Department = SqlInt32.Null;
        SqlString Hobbies = SqlString.Null;


        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters
        MST_EmployeeENTBase entMST_Employee = new MST_EmployeeENTBase();
        #region Gather Data
        if (Request.QueryString["EmpCode"] != null)
        {
            

            if (!Page.IsPostBack)
            {
                EmpCode = CommonFunctions.DecryptBase64(Request.QueryString["EmpCode"]);

            }
            else
            if (txtEmployeeName.Text.Trim() != String.Empty)
                        EmpName = txtEmployeeName.Text.Trim();
            if (txtEmployeeCode.Text.Trim() != String.Empty)
                        EmpCode = txtEmployeeCode.Text.Trim();
            if (ddlDepartmentName.SelectedIndex >0)
                     Department = Convert.ToInt32(ddlDepartmentName.SelectedValue);
        }


        else
        {
            if (txtEmployeeName.Text.Trim() != String.Empty)
                    EmpName = txtEmployeeName.Text.Trim();
            if (txtEmployeeCode.Text.Trim() != String.Empty)
                    EmpCode = txtEmployeeCode.Text.Trim();
            if (ddlDepartmentName.SelectedIndex > 0)
                     Department = Convert.ToInt32(ddlDepartmentName.SelectedValue);
        }

        #endregion Gather Data
        MST_EmployeeBALBase balMST_Employee = new MST_EmployeeBALBase();

        DataTable dt = balMST_Employee.SelectPage(Offset, PageRecordSize, out TotalRecords, EmpName, EmpCode, Department,Hobbies);

        if (PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
           // Div_ExportOption.Visible = true;
            rpData.DataSource = dt;
            rpData.DataBind();
            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;

            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            lblRecordInfoBottom.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
            lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);

        //    lbtnExportExcel.Visible = true;
            if (TotalRecords <= CV.SmallestPageSize)
            {
                Div_Pagination.Visible = false;
                Div_GoToPageNo.Visible = false;
                Div_PageSize.Visible = false;
            }
            else
            {
                Div_Pagination.Visible = true;
                Div_GoToPageNo.Visible = true;
                Div_PageSize.Visible = true;
            }
        }

        else if (TotalPages < PageNo && TotalPages > 0)
            Search(TotalPages);

        else
        {
            Div_SearchResult.Visible = false;
         //   lbtnExportExcel.Visible = false;

            ViewState["TotalPages"] = 0;
            ViewState["CurrentPage"] = 1;

            rpData.DataSource = null;
            rpData.DataBind();

            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

            CommonFunctions.BindPageList(0, 0, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
    }
    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region pagination
    protected void rpPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lb = (LinkButton)e.Item.FindControl("lbtnPageNo");
            HtmlGenericControl hgc = (HtmlGenericControl)e.Item.FindControl("liPageNo");
            if (Convert.ToInt32(ViewState["CurrentPage"]) == Convert.ToInt32(lb.CommandArgument))
            {
                hgc.Attributes["class"] = CSSClass.PaginationButtonActive;
                lb.Enabled = false;
            }
            else
                hgc.Attributes["class"] = CSSClass.PaginationButton;
        }
    }
    #endregion pagination

    #region Page Change
    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")
            Search(Value);

        else if (Name == "PreviousPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);

        else if (Name == "NextPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);

        else if (Name == "LastPage")
            Search(Convert.ToInt32(ViewState["TotalPages"]));

        else if (Name == "GoPageNo")
        {
            if (txtPageNo.Text.Trim() == String.Empty)
            {
                ucMessage.ShowError(CommonMessage.ErrorRequiredField("Page No"));
                return;
            }
            else
            {
                Value = Convert.ToInt32(txtPageNo.Text);
                if (Value > Convert.ToInt32(ViewState["TotalPages"]))
                {
                    ucMessage.ShowError(CommonMessage.ErrorInvalidField("Page No"));
                    return;
                }
                Search(Value);
            }
        }
    }
    #endregion Page Change

    #region 21.0 ddlPageSize Selected Index Changed Event

    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }


    #endregion 21.0 ddlPageSize Selected Index Changed Event

    #region Clear button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    #endregion Clear button

    #region rpData_ItemComman
    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {
            try
            {

                MST_EmployeeBALBase balEmployee = new MST_EmployeeBALBase();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (balEmployee.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

                        if (ViewState["CurrentPage"] != null)
                        {
                            int Count = rpData.Items.Count;

                            if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
                                ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
                            Search(Convert.ToInt32(ViewState["CurrentPage"]));
                        }
                    }
                }
              BindEmployeeData();

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }

    }
    #endregion rpData_ItemComman

    #region Delete Button
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            bool check = false;

            foreach (RepeaterItem item in rpData.Items)
            {

                CheckBox cb = (CheckBox)item.FindControl("cbkDelete");

                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    if (cb.Checked)
                    {
                        check = true;
                        HiddenField hfield = (HiddenField)item.FindControl("hfEmployeeID");
                        int EmployeeID = Convert.ToInt32(hfield.Value);
                        MST_EmployeeBALBase balEmployee = new MST_EmployeeBALBase();
                        balEmployee.Delete(EmployeeID);
                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                    }
                }
            }
            if (!check)
            {
                ucMessage.ShowError("Delete Atleast 1 Record");
            }
            BindEmployeeData();
        }
        catch (Exception ex)
        {
            ucMessage.ShowError(ex.Message.ToString());
        }
    }
    #endregion Delete Button

    #region ClearControls
    private void ClearControls()
    {
        txtEmployeeName.Text = String.Empty;
        txtEmployeeCode.Text = String.Empty;
        ddlDepartmentName.SelectedIndex = 0;
        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
       // Div_ExportOption.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

    }
    #endregion ClearControls

}