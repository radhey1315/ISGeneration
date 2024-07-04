using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using GnForm3C.ENT;
using System.Runtime.Remoting.Messaging;

public partial class AdminPanel_Master_MST_Country_MST_CountryAddEdit : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //FillDropDownList();

            if (Request.QueryString["CountryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            else
            {
              
            }
        }
    }

   
   

    private void FillControls(SqlInt32 CountryID)
    {
        MST_CountryENTBase entCountry = new MST_CountryENTBase();
        MST_CountryBALBase balCountry = new MST_CountryBALBase();

        entCountry = balCountry.SelectByPK(CountryID);


        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.Value.ToString();
        }
        if (!entCountry.CountryCode.IsNull)
        {
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
        }
    }

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region entCountry
        MST_CountryENTBase entCountry = new MST_CountryENTBase();


        if (txtCountryName.Text.Trim() != "")
        {
            entCountry.CountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            entCountry.CountryCode = txtCountryCode.Text.Trim();
        }
        #endregion entCountry

        MST_CountryBALBase balCountry = new MST_CountryBALBase();

        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {

                ClearControls();



                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Add Successful" + "');", true);

               
            }
            else
            {
               
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Add Successful" + "');", true);

            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);

            if (balCountry.Update(entCountry))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Master/MST_Country/MST_CountryList.aspx");
            }
            else
            {
               // lblMessage.Text = "Data Not Updated";
               // divMessage.Visible = true;
            }
        }


    }

    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 
    private void ClearControls()
    {
        txtCountryName.Text = String.Empty;
        txtCountryCode.Text = String.Empty;
        txtCountryName.Focus();
    }

    #endregion 16.0 Clear Controls 
}