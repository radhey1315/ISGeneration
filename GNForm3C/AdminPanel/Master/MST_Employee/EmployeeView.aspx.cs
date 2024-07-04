using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Employee_EmployeeView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmployeeID"] != null)
            {
                FillControls();
            }
        }
    }

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["EmployeeID"] != null)
        {
            MST_EmployeeBALBase balMST_Employee = new MST_EmployeeBALBase();
            DataTable dtMST_ExpenseType = balMST_Employee.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["EmployeeID"]));
            if (dtMST_ExpenseType != null)
            {

            }
            foreach (DataRow dr in dtMST_ExpenseType.Rows)
            {

                //if (!dr["EmployeeID"].Equals(DBNull.Value))
                //    lblEmployeeID.Text = Convert.ToInt32(dr["EmployeeID"]).ToString();

                if (!dr["EmpName"].Equals(DBNull.Value))
                    lblEmployeeName.Text = Convert.ToString(dr["EmpName"]);

                if (!dr["EmpCode"].Equals(DBNull.Value))
                    lblEmployeeCode.Text = Convert.ToString(dr["EmpCode"]);

                if (!dr["CreationDate"].Equals(DBNull.Value))
                    lblCreated.Text = Convert.ToDateTime(dr["CreationDate"]).ToString(CV.DefaultDateTimeFormat);

                if (!dr["ModifiedDate"].Equals(DBNull.Value))
                    lblModified.Text = Convert.ToDateTime(dr["ModifiedDate"]).ToString(CV.DefaultDateTimeFormat);

                if (!dr["Remarks"].Equals(DBNull.Value))
                    Label2.Text = Convert.ToString(dr["Remarks"]);

                if (!dr["UserID"].Equals(DBNull.Value))
                    lblUserID.Text = Convert.ToInt32(dr["UserID"]).ToString();
               
                if (!dr["JoiningDate"].Equals(DBNull.Value))
                    Label4.Text = Convert.ToString(dr["JoiningDate"]);

                if (!dr["DepartmentName"].Equals(DBNull.Value))
                    Label6.Text = Convert.ToString(dr["DepartmentName"]);


            }
        }
    }

    #endregion FillControls
}