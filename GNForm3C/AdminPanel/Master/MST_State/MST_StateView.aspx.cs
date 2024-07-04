using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_State_MST_StateView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["StateID"] != null)
            {
                FillControls();
            }
        }
    }

    private void FillControls()
    {
        if (Request.QueryString["StateID"] != null)
        {
            MST_StateBALBase balState = new MST_StateBALBase();
            DataTable dtMST_State = balState.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["StateID"]));
            if (dtMST_State != null)
            {

            }
            foreach (DataRow dr in dtMST_State.Rows)
            {

                //if (!dr["CountryID"].Equals(DBNull.Value))
                //    lblCountryID.Text = Convert.ToInt32(dr["CountryID"]).ToString();

                if (!dr["StateName"].Equals(DBNull.Value))
                    lblHospitalID.Text = Convert.ToString(dr["StateName"]);

                if (!dr["StateCode"].Equals(DBNull.Value))
                    lblRemarks.Text = Convert.ToString(dr["StateCode"]);

                if (!dr["CreationDate"].Equals(DBNull.Value))
                    lblCreated.Text = Convert.ToDateTime(dr["CreationDate"]).ToString(CV.DefaultDateTimeFormat);

                if (!dr["ModifiedDate"].Equals(DBNull.Value))
                    lblModified.Text = Convert.ToDateTime(dr["ModifiedDate"]).ToString(CV.DefaultDateTimeFormat);

                if (!dr["Description"].Equals(DBNull.Value))
                    lblDescription.Text = Convert.ToString(dr["Description"]);

                if (!dr["CountryName"].Equals(DBNull.Value))
                    lblCountryName.Text = Convert.ToString(dr["CountryName"]);

            }
        }
    }
}