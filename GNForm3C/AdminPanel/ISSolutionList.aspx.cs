using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;

public partial class AdminPanel_ISSolutionList : System.Web.UI.Page
{ 
    #region 11.0 Variables
	
    String FormName = "";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
	Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;
	
    #endregion 11.0 Variables

    #region 12.0 Page Load Event
	
    protected void Page_Load(object sender, EventArgs e)
    {
		#region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login
	
        if (!Page.IsPostBack)
        {                      
          
            lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            Search(1);
        }
    }

    #endregion 12.0 Page Load Event

    private void Search(int PageNo)
    {
        #region Parameters

        SqlString InvoiceNo = SqlString.Null;
        SqlString PONo = SqlString.Null;
        SqlDateTime Date = SqlDateTime.Null;
        SqlDateTime PODate = SqlDateTime.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters

        #region Gather Data

        if (txtInvoiceNo.Text.Trim() != String.Empty)
            InvoiceNo = Convert.ToString(txtInvoiceNo.Text.Trim());

        if (txtPONo.Text.Trim() != String.Empty)
            PONo = Convert.ToString(txtPONo.Text.Trim());

        if (dptDate.Text.Trim() != String.Empty)
            Date = Convert.ToDateTime(dptDate.Text.Trim());

        if (dptPODate.Text.Trim() != String.Empty)
            PODate = Convert.ToDateTime(dptPODate.Text.Trim());

        #endregion Gather Data

        ISSolutionBAL balISSolution = new ISSolutionBAL();

        DataTable dt = balISSolution.SelectPage(Offset, PageRecordSize, out TotalRecords, InvoiceNo, PONo, Date, PODate);

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

            //lbtnExportExcel.Visible = true;
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
           // lbtnExportExcel.Visible = false;

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

    #region 13.0 FillLabels 
    private void FillLabels(String FormName)
	{
	}
	#endregion 

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event	
    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {                    
                    if (balACC_Expense.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

                        if (ViewState["CurrentPage"] != null)
                        {
                            int Count = rpData.Items.Count;

                            if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
                                ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
                           // Search(Convert.ToInt32(ViewState["CurrentPage"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }
    }
    #endregion 16.1 Item Command Event    

    #endregion 16.0 Repeater Events

    #region ItemDataBound Event
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

    #endregion ItemDataBound Event

    #region PageChange Event

    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

    }
    #endregion PageChange Event

    #region 20.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
		ClearControls();
    }
	
    #endregion 20.0 Cancel Button Event

    #region 21.0 ddlPageSize Selected Index Changed Event

    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
       // Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    protected void ddlPageSizeTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
       // Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    #endregion 21.0 ddlPageSize Selected Index Changed Event

	#region 22.0 ClearControls

    private void ClearControls()
    {
		//ddlExpenseTypeID.Items.Clear();
  //      ddlExpenseTypeID.Items.Insert(0, new ListItem("Select Expense Type", "-99"));
		//txtAmount.Text = String.Empty;
		//dtpExpenseDate.Text = String.Empty;
		//ddlHospitalID.SelectedIndex = 0;
  //      ddlFinYearID.Items.Clear();
  //      ddlFinYearID.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
		//CommonFunctions.BindEmptyRepeater(rpData);
  //     		Div_SearchResult.Visible = false;
  //      	Div_ExportOption.Visible = false;
  //      	lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
  //      	lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls
    
}

