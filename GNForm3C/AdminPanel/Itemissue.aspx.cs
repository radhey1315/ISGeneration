using GNForm3C;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Itemissue : System.Web.UI.Page
{
    #region 11.0 Page Load Event 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["PurchaseInvoiceID"] != null)
            {
                
            }
        }
    }

    #endregion 11.0 Page Load Event

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {

            try
            {
                #region entItemIssue
                SqlInt32 PurchaseInvoiceID = SqlInt32.Null;

                ItemIssueENT entItemIssue = new ItemIssueENT();

                if (txtItemNo.Text.Trim() != "")
                {
                    entItemIssue.ItemNo = txtItemNo.Text.Trim();
                }

                if (Request.QueryString["PurchaseInvoiceID"] != null)
                {
                    PurchaseInvoiceID = Convert.ToInt32(Request.QueryString["PurchaseInvoiceID"]);
                    entItemIssue.PurchaseInvoiceID = PurchaseInvoiceID;
                }

                if (txtItemName.Text.Trim() != "")
                {
                    entItemIssue.ItemName = txtItemName.Text.Trim();
                }

                if (txtQuntity.Text.Trim() != "")
                {
                    entItemIssue.Quntity = Convert.ToInt32(txtQuntity.Text.Trim());
                }

                if (txtPrice.Text.Trim() != "")
                {
                    entItemIssue.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                }

                if (txtUnit.Text.Trim() != "")
                {
                    entItemIssue.Unit = txtUnit.Text.Trim();
                }

                if (txtAmount.Text.Trim() != "")
                {
                    entItemIssue.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                }


                #endregion entPurchaseInvoice

                ItemissueBAL balItemIssue = new ItemissueBAL();

                //    if (Request.QueryString["PurchaseInvoiceID"] == null)
                //       {
                if (balItemIssue.Insert(entItemIssue))
                {
                    ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                    ClearControls();
                }
                //      }
                //  else
                //  {
                // entPurchaseInvoice.PurchaseInvoiceID = Convert.ToInt32(Request.QueryString["PurchaseInvoiceID"]);
                //
                // if (balPurchaseInvoice.Update(entPurchaseInvoice))
                // {
                //     ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                //     Response.Redirect("~/AdminPanel/Master/MST_Employee/EmployeeList.aspx");
                //
                // }
                //   }

            
            }

            catch (Exception ex)
            {
                 ucMessage.ShowError(ex.Message);
            }
        }
    }


    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 
    private void ClearControls()
    {
        txtItemNo.Text = String.Empty;
        txtItemName.Text = String.Empty;
        txtQuntity.Text = String.Empty;
        txtPrice.Text = String.Empty;
        txtUnit.Text = String.Empty;
        txtAmount.Text = String.Empty;
    }

    #endregion 16.0 Clear Controls 
}