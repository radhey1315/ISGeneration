using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GnForm3C.ENT;

public partial class AdminPanel_Master_MST_Country_MST_CountryAddMany : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "MST_CountryAddMany";

    #endregion 10.0 Variables

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {

            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.5 Set Help Text

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.5 Set Help Text

            #region Parameters
            SqlInt32 CountryID = SqlInt32.Null;
            #endregion Parameters



            #region Show Repeater 

            DataTable dtBlank = new DataTable();

            for (int i = 0; i < 10; i++)
            {
                DataRow dtRow = dtBlank.NewRow();
                dtBlank.Rows.Add(dtRow);
            }

            rpData.DataSource = dtBlank;
            rpData.DataBind();


            MST_ExpenseTypeBAL balMST_Country = new MST_ExpenseTypeBAL();
            DataTable dt = balMST_Country.SelectShow(CountryID);

            int count = 1;
            foreach (RepeaterItem Ri in rpData.Items)
            {
                Label lblSrNo = (Label)Ri.FindControl("lblSrNo");
                lblSrNo.Text = count.ToString();
                count++;
            }

            Div_ShowResult.Visible = true;

            #endregion Show Repeater 


        }

    }

    #region 12.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();


        MST_CountryBALBase balMST_Country = new MST_CountryBALBase();
        MST_CountryENTBase entMST_Country = new MST_CountryENTBase();

     
        foreach (RepeaterItem Ri in rpData.Items)
        {
            try
            {
                #region 15.1.0 Parameter
                TextBox txtCountryName = (TextBox)Ri.FindControl("txtCountryName");
                TextBox txtCountryCode = (TextBox)Ri.FindControl("txtCountryCode");
                HiddenField hfCountryID = (HiddenField)Ri.FindControl("hfCountryID");
                CheckBox chkIsSelected = (CheckBox)Ri.FindControl("chkIsSelected");
                #endregion 15.1.0 Parameter

                #region 15.2.1 Gather Data
                entMST_Country.CountryName = txtCountryName.Text.Trim();
              
                entMST_Country.CountryCode = txtCountryCode.Text.Trim();
               
                #endregion 15.2.1 Gather Data

                if (txtCountryName.Text.Trim() != string.Empty && txtCountryCode.Text.Trim() != string.Empty)
                {
                        if (chkIsSelected.Checked)
                        {
                            if (balMST_Country.Insert(entMST_Country))
                            {
                                ucMessage.ShowSuccess(CommonMessage.RecordSaved());

                            }
                           
                        }
                }
                else
                {
                    ucMessage.ShowError("Enter All Row With Country Name & Country Code");
                    break;
                }
               
            }
 
            catch (Exception ex)
            {
                 ucMessage.ShowError(ex.Message);
            }
        }
    }
}
