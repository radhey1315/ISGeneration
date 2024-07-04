using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_State_MST_StateList : System.Web.UI.Page
{

    String FormName = "MST_StateList";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        if (!Page.IsPostBack)
        {
            Search(1);
            CommonFunctions.GetDropDownPageSize(ddlPageSizeBottom);
            ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
        }
    }
    #endregion Page Load

    #region search button
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }
    #endregion search button

    #region fill label
    private void FillLabels(String FormName)
    {
    }
    #endregion fill label

    #region 15.2 Search Function

    private void Search(int PageNo)
    {
        #region Parameters
        SqlString StateName = SqlString.Null;
        SqlString CountryName = SqlString.Null;
        SqlString StateCode = SqlString.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters

        #region Gather Data
        if (Request.QueryString["StateCode"] != null)
        {
            if (!Page.IsPostBack)
            {
                StateCode = CommonFunctions.DecryptBase64(Request.QueryString["StateCode"]);

            }
            else
            {
                if (txtStateName.Text.Trim() != String.Empty)
                { StateName = txtStateName.Text.Trim(); }
                if (txtStateCode.Text.Trim() != String.Empty)
                { StateCode = txtStateCode.Text.Trim(); }
                if (txtCountryName.Text.Trim() != String.Empty)
                { CountryName = txtCountryName.Text.Trim(); }
            }
        }
        


        else
        {
            if (txtCountryName.Text.Trim() != String.Empty)
                CountryName = txtCountryName.Text.Trim();
            if (txtStateName.Text.Trim() != String.Empty)
                StateName = txtStateName.Text.Trim();
            if (txtStateCode.Text.Trim() != String.Empty)
                StateCode = txtStateCode.Text.Trim();
            
        }


        #endregion Gather Data
        MST_StateBALBase balMST_State = new MST_StateBALBase();

        DataTable dt = balMST_State.SelectPage(Offset, PageRecordSize, out TotalRecords, StateName, StateCode , CountryName );

        if (PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));

        if (dt != null && dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();
            Div_SearchResult.Visible = true;
            Div_ExportOption.Visible = true;
            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;

            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            lblRecordInfoBottom.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
            lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);

            lbtnExportExcel.Visible = true;
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
            lbtnExportExcel.Visible = false;

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

    #region Bind State data
    private void BindStateData()
    {
        MST_StateBALBase stateBAL = new MST_StateBALBase();
        DataTable dtState = stateBAL.SelectAll();

        if (dtState.Rows.Count > 0)
        {
            rpData.DataSource = dtState;
            rpData.DataBind();
            Div_SearchResult.Visible = true;

        }
        else
        {
            Div_SearchResult.Visible = false;

        }
    }

    #endregion Bind State data

    #region page size bottom
    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }
    #endregion page size bottom

    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();

        int TotalReceivedRecord = 0;

        SqlString StateName = SqlString.Null;
        SqlString StateCode = SqlString.Null;
        SqlString CountryName = SqlString.Null;

        if (txtStateName.Text.Trim() != String.Empty)
            StateName = txtStateName.Text.Trim();
        Int32 Offset = 0;

        if (ViewState["CurrentPage"] != null)
            Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        MST_StateBALBase balMST_Country = new MST_StateBALBase();
        DataTable dtMST_Country = balMST_Country.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, StateName, StateCode ,CountryName);
        if (dtMST_Country != null && dtMST_Country.Rows.Count > 0)
        {
            Session["ExportTable"] = dtMST_Country;
            Response.Redirect("~/Default/Export.aspx?ExportType=" + ExportType);
        }
    }




    protected void lbtnExportExcel_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();

        int TotalReceivedRecord = 0;

        SqlString StateName = SqlString.Null;
        SqlString StateCode = SqlString.Null;
        SqlString CountryName = SqlString.Null;

        if (txtStateName.Text.Trim() != String.Empty)
            StateName = txtStateName.Text.Trim();

        Int32 Offset = 0;

        if (ViewState["CurrentPage"] != null)
            Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        MST_StateBALBase balMST_Country = new MST_StateBALBase();
        DataTable dtMST_Country = balMST_Country.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, StateName, StateCode ,CountryName);
        if (dtMST_Country != null && dtMST_Country.Rows.Count > 0)
        {
            Session["ExportTable"] = dtMST_Country;
            Response.Redirect("~/Default/Export.aspx?ExportType=" + ExportType);
        }
    }
    #endregion Export

    #region page change 
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

    #endregion page change 

    #region rp Pagination
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

    #endregion rp Pagination

    #region rpData with Delete Button
    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {
            try
            {

                MST_StateBALBase balState = new MST_StateBALBase();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (balState.Delete(Convert.ToInt32(e.CommandArgument)))
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
                BindStateData();

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }

    }
    #endregion rpData with Delete Button

    #region button clear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    #endregion button clear

    #region Delete Many 
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
                        HiddenField hfield = (HiddenField)item.FindControl("hfStateID");
                        int StateID = Convert.ToInt32(hfield.Value);
                        MST_StateBALBase balcountry = new MST_StateBALBase();
                        balcountry.Delete(StateID);
                    }
                }
            }
            if (!check) 
            {
                ucMessage.ShowError("Delete Atleast 1 Record");
            }
            else
            {
                ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
            }
                        
                   


            BindStateData();
        }
        catch (Exception ex)
        {
            ucMessage.ShowError(ex.Message.ToString());
        }
    }
    #endregion Delete Many

    #region Clear Controls
    private void ClearControls()
    {
        txtStateName.Text = String.Empty;
        txtStateCode.Text = String.Empty;
        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        Div_ExportOption.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

    }

    #endregion Clear Controls

}