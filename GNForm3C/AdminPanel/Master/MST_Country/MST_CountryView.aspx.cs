using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Country_MST_CountryView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //#region 10.1 Check User Login

        //if (Session["CountryID"] == null)
        //    Response.Redirect(CV.LoginPageURL);

        //#endregion 10.1 Check User Login

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillControls();
            }
        }
    }



    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["CountryID"] != null)
        {
            MST_CountryBALBase balMST_Country = new MST_CountryBALBase();
            DataTable dtMST_ExpenseType = balMST_Country.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["CountryID"]));
            if (dtMST_ExpenseType != null)
            {

            }
            foreach (DataRow dr in dtMST_ExpenseType.Rows)
            {

                //if (!dr["CountryID"].Equals(DBNull.Value))
                //    lblCountryID.Text = Convert.ToInt32(dr["CountryID"]).ToString();

                if (!dr["CountryName"].Equals(DBNull.Value))
                    lblHospitalID.Text = Convert.ToString(dr["CountryName"]);

                if (!dr["CountryCode"].Equals(DBNull.Value))
                    lblRemarks.Text = Convert.ToString(dr["CountryCode"]);

                if (!dr["CreationDate"].Equals(DBNull.Value))
                    lblCreated.Text = Convert.ToDateTime(dr["CreationDate"]).ToString(CV.DefaultDateTimeFormat);

                if (!dr["ModifiedDate"].Equals(DBNull.Value))
                    lblModified.Text = Convert.ToDateTime(dr["ModifiedDate"]).ToString(CV.DefaultDateTimeFormat);

                if (!dr["Description"].Equals(DBNull.Value))
                    lblRemarks.Text = Convert.ToString(dr["Description"]);

                if (!dr["UserID"].Equals(DBNull.Value))
                    lblUserID.Text = Convert.ToInt32(dr["UserID"]).ToString();

            }
        }
    }

    #endregion FillControls
}
