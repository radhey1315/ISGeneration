using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Runtime.Remoting.Messaging;
using GnForm3C.ENT;
using GNForm3c.BAL;
using System.ServiceModel.Channels;


public partial class AdminPanel_Master_MST_Country_MST_CountryList : System.Web.UI.Page
{

    String FormName = "MST_CountryList";
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


    #region Bind Country
    private void BindCountryData()
    {
        MST_CountryBALBase countryBAL = new MST_CountryBALBase();
        DataTable dtCountries = countryBAL.SelectAll();

        if (dtCountries.Rows.Count > 0)
        {
            rpData.DataSource = dtCountries;
            rpData.DataBind();
            Div_SearchResult.Visible = true;
       
        }
        else
        {
            Div_SearchResult.Visible = false;
     
        }
    }

    #endregion Bind Country



    #region 15.0 Search

    #region 15.2 Search Function

    private void Search(int PageNo)
    {
        #region Parameters
        SqlString CountryName = SqlString.Null;
        SqlString CountryCode = SqlString.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters

        #region Gather Data
        if (Request.QueryString["CountryCode"] != null)
        {
            if (!Page.IsPostBack)
            {
                CountryCode = CommonFunctions.DecryptBase64(Request.QueryString["CountryCode"]);
                
            }
            else
                if (txtCountryName.Text.Trim() != String.Empty)
                CountryName = txtCountryName.Text.Trim();
            if (txtCountryCode.Text.Trim() != String.Empty)
                CountryCode = txtCountryCode.Text.Trim();
        }


        else
        {
            if (txtCountryName.Text.Trim() != String.Empty)
                CountryName = txtCountryName.Text.Trim();
            if (txtCountryCode.Text.Trim() != String.Empty)
                CountryCode = txtCountryCode.Text.Trim();
        }




        #endregion Gather Data
        MST_CountryBALBase balMST_Country = new MST_CountryBALBase();

        DataTable dt = balMST_Country.SelectPage(Offset, PageRecordSize, out TotalRecords, CountryName, CountryCode);

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
            Div_ExportOption.Visible = true;
            rpData.DataSource = dt;
            rpData.DataBind();
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

    #endregion 15.0 Search


    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();

        int TotalReceivedRecord = 0;

        SqlString CountryName = SqlString.Null;
        SqlString CountryCode = SqlString.Null;

        if (txtCountryName.Text.Trim() != String.Empty)
            CountryName = txtCountryName.Text.Trim();
        Int32 Offset = 0;

        if (ViewState["CurrentPage"] != null)
            Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        MST_CountryBALBase balMST_Country = new MST_CountryBALBase();
        DataTable dtMST_Country = balMST_Country.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, CountryName, CountryCode);
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

        SqlString CountryName = SqlString.Null;
        SqlString CountryCode = SqlString.Null;

        if (txtCountryName.Text.Trim() != String.Empty)
            CountryName = txtCountryName.Text.Trim();

        Int32 Offset = 0;

        if (ViewState["CurrentPage"] != null)
            Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        MST_CountryBALBase balMST_Country = new MST_CountryBALBase();
        DataTable dtMST_Country = balMST_Country.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, CountryName, CountryCode);
        if (dtMST_Country != null && dtMST_Country.Rows.Count > 0)
        {
            Session["ExportTable"] = dtMST_Country;
            Response.Redirect("~/Default/Export.aspx?ExportType=" + ExportType);
        }
    }

    #endregion Export

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

                MST_CountryBALBase balcountry = new MST_CountryBALBase();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (balcountry.Delete(Convert.ToInt32(e.CommandArgument)))
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
                BindCountryData();

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
                        HiddenField hfield = (HiddenField)item.FindControl("hfCountryID");
                        int CountryID = Convert.ToInt32(hfield.Value);
                        MST_CountryBALBase balcountry = new MST_CountryBALBase();
                        balcountry.Delete(CountryID);
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




            BindCountryData();
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
        txtCountryName.Text = String.Empty;
        txtCountryCode.Text = String.Empty;
        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        Div_ExportOption.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

    }
    #endregion ClearControls



}