using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Hospital_MST_HospitalViewCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 10.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 10.1 Check User Login

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["HospitalID"] != null)
            {
                FillControls();
            }
        }
    }

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["HospitalID"] != null)
        {
            MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
            DataTable dtMST_Hospital = balMST_Hospital.SelectViewCount(CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]));

            

            rpData.DataSource = dtMST_Hospital;
            rpData.DataBind();
            
        }
    }
    #endregion FillControls

}