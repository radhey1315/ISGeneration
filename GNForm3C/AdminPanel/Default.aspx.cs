using AjaxControlToolkit;
using GNForm3c.BAL;
using GNForm3C;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        #region 11.2 Set Help Text

        ucHelp.ShowHelp("Help Text will be shown here");

        #endregion 11.2 Set Help Text

        #region Dashboard Count

        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        DataTable dt = new DataTable();

        dt = balIncomeType.SelectDashboardCount();

        if (dt != null && dt.Rows.Count > 0)
        {
            lblTotalIncomeAmount.Text = dt.Rows[2].ItemArray[1].ToString();
            lblTotalExpenseAmount.Text = dt.Rows[3].ItemArray[1].ToString();
            lblHospitalCount.Text = dt.Rows[0].ItemArray[1].ToString();
            lblSalaryIncomeTypeCount.Text = dt.Rows[1].ItemArray[1].ToString();
            lblDeductionType.Text = dt.Rows[4].ItemArray[1].ToString();
        }
        #endregion Dashboard Count

        PieChart();

        fillData();

        //DataTable dt = GetData();
        //string[] x = new string[dt.Rows.Count];
        //int[] y = new int[dt.Rows.Count];
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    x[i] = dt.Rows[i][0].ToString();
        //    y[i] = Convert.ToInt32(dt.Rows[i][1]);
        //}
        //Chart2.Series[0].Points.DataBindXY(x, y);
        //Chart2.Series[0].ChartType = SeriesChartType.Pie;
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        //Chart1.Legends[0].Enabled = true;

    }
    #endregion 11.0 Page Load Event


    #region Repeater Fill
    protected void fillData()
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        DataTable dt = new DataTable();

        #region SelectAllDashBoardIncome
        dt = balIncomeType.SelectAllDashBoardRP(Convert.ToInt32(Session["UserID"]));

        if (dt != null && dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();
        }
        #endregion SelectAllDashBoardIncome

        #region SelectAllDashBoardExpense

        dt = balIncomeType.SelectAllDashBoardExpense(Convert.ToInt32(Session["UserID"]));
        if (dt != null && dt.Rows.Count > 0)
        {
            rpExpense.DataSource = dt;
            rpExpense.DataBind();
        }
        #endregion SelectAllDashBoardExpense

        #region SelectAllDashBoardrpExpenseType

        dt = balIncomeType.SelectAllDashBoardrpExpenseType(Convert.ToInt32(Session["UserID"]));
        if (dt != null && dt.Rows.Count > 0)
        {
            rpExpenseType.DataSource = dt;
            rpExpenseType.DataBind();
        }
        #endregion SelectAllDashBoardrpExpenseType

    }
    #endregion Repeater Fill


    public List <Dictionary<string, object>> PieChart()
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        DataTable dt = balIncomeType.SelectDashboardCount();

        // Convert the DataTable to a list of dictionaries
        var dataList = new List<Dictionary<string, object>>();
        foreach (DataRow row in dt.Rows)
        {
            var dataItem = new Dictionary<string, object>();
            foreach (DataColumn column in dt.Columns)
            {
                dataItem[column.ColumnName] = row[column];
            }
            dataList.Add(dataItem);
        }

        return dataList;
    }

    public string GetChartData()
    {
        List<Dictionary<string, object>> data = PieChart(); // Call your C# method to fetch data
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Serialize(data);
    }


}

