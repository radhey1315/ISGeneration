using GNForm3C.BAL;
using GnForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using GNForm3C.ENT;

public partial class AdminPanel_ISSolution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 
        }

    }


    #region 14.0 FillControls By PK  

    private void FillControls()
    {
        if (Request.QueryString["PurchaseInvoiceID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Invoice";
            ISSolutionBAL balISSolution = new ISSolutionBAL();
            PurchaseInvoiceENT entISSolution = new PurchaseInvoiceENT();

            entISSolution = balISSolution.SelectPK(Convert.ToInt32(Request.QueryString["PurchaseInvoiceID"]));

            if (!entISSolution.IncomeTaxPan.IsNull)
                txtIncomeTaxPAN.Text = entISSolution.IncomeTaxPan.Value.ToString();

            if (!entISSolution.ToAddress.IsNull)
                txtAddress.Text = entISSolution.ToAddress.Value.ToString();

            if (!entISSolution.ToGSTIN.IsNull)
                txtGSTIN.Text = entISSolution.ToGSTIN.Value.ToString();

            if (!entISSolution.InvoiceNo.IsNull)
                txtInvoiceNo.Text = entISSolution.InvoiceNo.Value.ToString();

            if (!entISSolution.Date.IsNull)
                dtpDate.Text = entISSolution.Date.Value.ToString(CV.DefaultDateFormat);

            if (!entISSolution.PONo.IsNull)
                txtPONo.Text = entISSolution.PONo.Value.ToString();

            if (!entISSolution.PODate.IsNull)
                dtpPODate.Text = entISSolution.PODate.Value.ToString();

            if (!entISSolution.GSTNo.IsNull)
                txtGSTNo.Text = entISSolution.GSTNo.Value.ToString();

            if (!entISSolution.BankName.IsNull)
                txtBankName.Text = entISSolution.BankName.Value.ToString();

            if (!entISSolution.BankAccountNumber.IsNull)
                txtBankACNo.Text = entISSolution.BankAccountNumber.Value.ToString();

            if (!entISSolution.BankIFSC.IsNull)
                txtBankIFSC.Text = entISSolution.BankIFSC.Value.ToString();

            if (!entISSolution.CategoryOfService.IsNull)
                txtCategoryOfService.Text = entISSolution.CategoryOfService.Value.ToString();



        }
    }

    #endregion 14.0 FillControls By PK 



    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {

            try
            {

                #region entPurchaseInvoice
                PurchaseInvoiceENT entPurchaseInvoice = new PurchaseInvoiceENT();
                SqlInt32 PurchaseInvoiceID = SqlInt32.Null;


                if (txtAddress.Text.Trim() != "")
                {
                    entPurchaseInvoice.ToAddress = txtAddress.Text.Trim();
                }
                if (txtGSTIN.Text.Trim() != "")
                {
                    entPurchaseInvoice.ToGSTIN = txtGSTIN.Text.Trim();
                }

                if (txtInvoiceNo.Text.Trim() != "")
                {
                    entPurchaseInvoice.InvoiceNo = txtInvoiceNo.Text.Trim();
                }

                if (dtpDate.Text.Trim() != String.Empty)
                    entPurchaseInvoice.Date = Convert.ToDateTime(dtpDate.Text.Trim());

                if (dtpPODate.Text.Trim() != String.Empty)
                    entPurchaseInvoice.PODate = Convert.ToDateTime(dtpPODate.Text.Trim());

                if (txtPONo.Text.Trim() != "")
                {
                    entPurchaseInvoice.PONo = txtPONo.Text.Trim();
                }

                if (txtBankIFSC.Text.Trim() != "")
                {
                    entPurchaseInvoice.BankIFSC = txtBankIFSC.Text.Trim();
                }

                if (txtBankACNo.Text.Trim() != "")
                {
                    entPurchaseInvoice.BankAccountNumber = txtBankACNo.Text.Trim();
                }
                if (txtBankName.Text.Trim() != "")
                {
                    entPurchaseInvoice.BankName = txtBankName.Text.Trim();
                }
                if (txtCategoryOfService.Text.Trim() != "")
                {
                    entPurchaseInvoice.CategoryOfService = txtCategoryOfService.Text.Trim();
                }
                if (txtGSTNo.Text.Trim() != "")
                {
                    entPurchaseInvoice.GSTNo = txtGSTNo.Text.Trim();
                }
                if (txtIncomeTaxPAN.Text.Trim() != "")
                {
                    entPurchaseInvoice.IncomeTaxPan = txtIncomeTaxPAN.Text.Trim();
                }

                #endregion entPurchaseInvoice

                ISSolutionBAL balPurchaseInvoice = new ISSolutionBAL();

                if (Request.QueryString["PurchaseInvoiceID"] == null)
                {
                    if (balPurchaseInvoice.Insert(entPurchaseInvoice))
                    {
                        Response.Redirect("~/AdminPanel/Itemissue.aspx?PurchaseInvoiceID=" + entPurchaseInvoice.PurchaseInvoiceID);
                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        ClearControls();
                    }
                }
                else
                {
                    entPurchaseInvoice.PurchaseInvoiceID = Convert.ToInt32(Request.QueryString["PurchaseInvoiceID"]);

                    if (balPurchaseInvoice.Update(entPurchaseInvoice))
                    {
                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        Response.Redirect("~/AdminPanel/Itemissue.aspx?PurchaseInvoiceID=" + entPurchaseInvoice.PurchaseInvoiceID);

                    }
                }


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
        txtAddress.Text = String.Empty;
        txtGSTIN.Text = String.Empty;
        txtIncomeTaxPAN.Text = String.Empty;
        txtInvoiceNo.Text = String.Empty;
        txtGSTNo.Text = String.Empty;
        txtBankACNo.Text = String.Empty;
        txtBankIFSC.Text = String.Empty;
        txtBankName.Text = String.Empty;
        txtCategoryOfService.Text = String.Empty;
        txtPONo.Text = String.Empty;
        dtpPODate.Text = String.Empty;
        dtpDate.Text = String.Empty;

        txtAddress.Focus();

    }

    #endregion 16.0 Clear Controls 
}
