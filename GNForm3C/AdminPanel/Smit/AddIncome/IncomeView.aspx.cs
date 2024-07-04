using GNForm3c.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Smit_AddIncome_IncomeView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 10.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect("~/Default.aspx");

        #endregion 10.1 Check User Login

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["IncomeID"] != null)
            {
                FillControls();
            }
        }
    }

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["IncomeID"] != null)
        {
            IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
            DataTable dtIncome = balIncomeType.SelectView(Convert.ToInt32(Request.QueryString["IncomeID"]));
            if (dtIncome != null)
            {
                foreach (DataRow dr in dtIncome.Rows)
                {

                    if (!dr["IncomeType"].Equals(DBNull.Value))
                        lblIncomeTypeID.Text = Convert.ToString(dr["IncomeType"]);

                    if (!dr["Amount"].Equals(DBNull.Value))
                        lblAmount.Text = Convert.ToString(dr["Amount"]);

                    if (!dr["IncomeDate"].Equals(DBNull.Value))
                        lblIncomeDate.Text = Convert.ToDateTime(dr["IncomeDate"]).ToString("dd-MM-yyyy");

                    if (!dr["Note"].Equals(DBNull.Value))
                        lblNote.Text = Convert.ToString(dr["Note"]);

                    if (!dr["Hospital"].Equals(DBNull.Value))
                        lblHospitalID.Text = Convert.ToString(dr["Hospital"]);

                    if (!dr["FinYearName"].Equals(DBNull.Value))
                        lblFinYearID.Text = Convert.ToString(dr["FinYearName"]);

                    if (!dr["Remarks"].Equals(DBNull.Value))
                        lblRemarks.Text = Convert.ToString(dr["Remarks"]);

                    if (!dr["UserName"].Equals(DBNull.Value))
                        lblUserID.Text = Convert.ToString(dr["UserName"]);

                    if (!dr["Created"].Equals(DBNull.Value))
                        lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString("dd-MM-yyyy HH:mm:ss tt");

                    if (!dr["Modified"].Equals(DBNull.Value))
                        lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString("dd-MM-yyyy HH:mm:ss tt");

                }
            }
        }
    }
    #endregion FillControls

}