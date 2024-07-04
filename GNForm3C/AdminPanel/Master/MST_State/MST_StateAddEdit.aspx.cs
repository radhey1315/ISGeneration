using GNForm3C.BAL;
using GnForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_State_MST_StateAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["StateID"] != null)
            {
               
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            else
            {

            }
            if (Request.QueryString["CountryID"] != null)
            {
                
                FillControlsByCountry(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            else
            {

            }
        }
    }
    private void FillControlsByCountry(SqlInt32 CountryID)
    {
        MST_CountryENTBase entCountry = new MST_CountryENTBase();
        MST_CountryBALBase balCountry = new MST_CountryBALBase();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryID.IsNull)
        {
            
            ddlCountryName.SelectedValue = entCountry.CountryID.ToString();
            ddlCountryName.Enabled = false;
        }

    }


    private void FillControls(SqlInt32 StateID)
    {
        MST_StateENTBase entState = new MST_StateENTBase();
        MST_StateBALBase balState = new MST_StateBALBase();

        entState = balState.SelectByPK(StateID);


        if (!entState.StateName.IsNull)
        {
            txtStateName.Text = entState.StateName.Value.ToString();
        }
        if (!entState.StateCode.IsNull)
        {
            txtStateCode.Text = entState.StateCode.Value.ToString();
        }
        if (!entState.Description.IsNull)
        {
            txtDescription.Text = entState.Description.Value.ToString();
        }
        if (!entState.CountryID.IsNull)
        {
            ddlCountryName.SelectedValue = entState.CountryID.ToString();
        }

    }

    #region Fill DropDown

    public void FillDropDownList()
    {

        CommonFillMethodsSmit.FillDropDownList(ddlCountryName);

    }

    //protected MST_StateENTBase GetEntMST_State()
    //{
    //    return entState;
    //}

    #endregion Fill DropDown

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region entState

        MST_StateENTBase entState = new MST_StateENTBase();
       
        if (txtStateName.Text.Trim() != "")
        {
            entState.StateName = txtStateName.Text.Trim();
        }
        if (txtStateCode.Text.Trim() != "")
        {
            entState.StateCode = txtStateCode.Text.Trim();
        }
        if (txtDescription.Text.Trim() != "")
        {
            entState.Description = txtDescription.Text.Trim();
        }
        if (ddlCountryName.SelectedIndex == 0)
        {
            return;
        }
        else
        {
            entState.CountryID = Convert.ToInt32(ddlCountryName.SelectedValue);
        }

        #endregion entState

        MST_StateBALBase balState = new MST_StateBALBase();
        if (Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                ClearControls();
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Add Successful" + "');", true);


            }
           
        }
        else
        {
           entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (balState.Update(entState))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Master/MST_State/MST_StateList.aspx");
            }
            
        }
        #endregion 15.0 Save Button Event 

       
    
    }

    #region 16.0 Clear Controls 
    private void ClearControls()
    {
        txtStateName.Text = String.Empty;
        txtStateCode.Text = String.Empty;
        txtDescription.Text= String.Empty;
     
        txtStateName.Focus();
    }
    #endregion 16.0 Clear Controls 
}




