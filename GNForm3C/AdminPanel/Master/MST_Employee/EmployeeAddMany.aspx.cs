using GNForm3C.BAL;
using GnForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Employee_EmployeeAddMany : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "MST_EmployeeAddMany";

    #endregion 10.0 Variables

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["DepartmentID"] != null)
            {
                btnShow_Click(sender, e);
            }



            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderAddMany + " Employee";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 11.4 Set Control Default Value

            #region 11.5 Set Help Text

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.5 Set Help Text

        }

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        #region Parameters
        SqlInt32 DepartmentID = SqlInt32.Null;
        #endregion Parameters


        // gather data load karavana bakii che !

        #region Gather Data
        if (Request.QueryString["DepartmentID"] != null)
        {
            if (!Page.IsPostBack)
            {
                DepartmentID = CommonFunctions.DecryptBase64Int32(Request.QueryString["DepartmentID"]);

            }
            else
                if (ddlDepartmentName.SelectedIndex > 0)
                DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);
        }
        else
        {
            if (ddlDepartmentName.SelectedIndex > 0)
                DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);
        }
        #endregion Gather Data

        #region Show Repeater 

        DataTable dtBlank = new DataTable();

        for (int i = 0; i < 10; i++)
        {
            DataRow dtRow = dtBlank.NewRow();
            dtBlank.Rows.Add(dtRow);
        }

        rpData.DataSource = dtBlank;
        rpData.DataBind();


        MST_EmployeeBALBase balMST_ExpenseType = new MST_EmployeeBALBase();
        DataTable dt = balMST_ExpenseType.SelectShow(DepartmentID);


        if (Request.QueryString["DepartmentID"] != null)
            ddlDepartmentName.SelectedValue = Convert.ToString(dt.Rows[0]["DepartmentID"]);
        foreach (DataRow dtRow in dt.Rows)
        {
            foreach (RepeaterItem Ri in rpData.Items)
            {
                TextBox txtEmployeeName = (TextBox)Ri.FindControl("txtEmployeeName");
                TextBox txtEmployeeCode = (TextBox)Ri.FindControl("txtEmployeeCode");
                TextBox txtSalary = (TextBox)Ri.FindControl("txtSalary");
                TextBox dtpJoiningDate = (TextBox)Ri.FindControl("dtpJoiningDate");
                HiddenField hfEmployeeID = (HiddenField)Ri.FindControl("hfEmployeeID");
                CheckBox chkIsSelected = (CheckBox)Ri.FindControl("chkIsSelected");

                if (hfEmployeeID.Value == string.Empty)
                {
                    if (!dtRow["EmpName"].Equals(DBNull.Value))
                    {
                        txtEmployeeName.Text = dtRow["EmpName"].ToString();
                        txtEmployeeCode.Text = dtRow["EmpCode"].ToString();
                        txtSalary.Text = dtRow["Salary"].ToString();
                        dtpJoiningDate.Text = dtRow["JoiningDate"].ToString();
                        hfEmployeeID.Value = dtRow["EmployeeID"].ToString();
                        chkIsSelected.Checked = true;
                    }
                    break;
                }
            }
        }

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

    #region 12.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 
    #region 12.0 Fill dropdown
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListDepartmentID(ddlDepartmentName);
    }
    #endregion 12.0 Fill dropdown 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {

            SqlInt32 DepartmentID = SqlInt32.Null;

            if (ddlDepartmentName.SelectedIndex > 0)
                DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);
            MST_EmployeeBALBase balMST_Employee = new MST_EmployeeBALBase();


            bool FiledFill = false;
          
            bool privious = true;

            foreach (RepeaterItem Ri in rpData.Items)
            {
                CheckBox chkIsSelected = (CheckBox)Ri.FindControl("chkIsSelected");
                if(chkIsSelected.Checked )
                {
                    FiledFill = true;
                }
                if (chkIsSelected.Checked && !privious)
                {
                    ucMessage.ShowError("Insert above employee details");
                    return;
                }
                privious = chkIsSelected.Checked;

                MST_EmployeeENTBase entMST_Employee = new MST_EmployeeENTBase();

                #region 15.1.0 Parameter
                TextBox txtEmployeeName = (TextBox)Ri.FindControl("txtEmployeeName");
                TextBox txtEmployeeCode = (TextBox)Ri.FindControl("txtEmployeeCode");
                TextBox txtSalary = (TextBox)Ri.FindControl("txtSalary");
                HiddenField hfEmployeeID = (HiddenField)Ri.FindControl("hfEmployeeID");
                TextBox dtpJoiningDate = (TextBox)Ri.FindControl("dtpJoiningDate");
             
                #endregion 15.1.0 Parameter

                #region 15.2.1 Gather Data
                if (chkIsSelected.Checked)
                {
                    entMST_Employee.EmpName = txtEmployeeName.Text.Trim();
                    entMST_Employee.EmpCode = txtEmployeeCode.Text.Trim();
                    entMST_Employee.Salary = Convert.ToInt32(txtSalary.Text.Trim());
                    entMST_Employee.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);
                    entMST_Employee.JoiningDate = Convert.ToDateTime(dtpJoiningDate.Text.Trim());
                    entMST_Employee.CreationDate = DateTime.Now;
                    entMST_Employee.ModifiedDate = DateTime.Now;

                    if (txtEmployeeName.Text.Trim() == string.Empty)
                    {
                        ucMessage.ShowError("Enter Employee Name");
                        return;
                    }
                    if (txtEmployeeCode.Text.Trim() == string.Empty)
                    {
                        ucMessage.ShowError("Enter Employee Code");
                        return;
                    }
                
                }
                else
                {
                    continue;
                }
                #endregion 15.2.1 Gather Data
               
            }

            foreach (RepeaterItem Ri in rpData.Items)
            {
                try
                {
                    MST_EmployeeENTBase entMST_Employee = new MST_EmployeeENTBase();

                    #region 15.1.0 Parameter
                    TextBox txtEmployeeName = (TextBox)Ri.FindControl("txtEmployeeName");
                    TextBox txtEmployeeCode = (TextBox)Ri.FindControl("txtEmployeeCode");
                    TextBox txtSalary = (TextBox)Ri.FindControl("txtSalary");
                    HiddenField hfEmployeeID = (HiddenField)Ri.FindControl("hfEmployeeID");
                    TextBox dtpJoiningDate = (TextBox)Ri.FindControl("dtpJoiningDate");
                    CheckBox chkIsSelected = (CheckBox)Ri.FindControl("chkIsSelected");
                    #endregion 15.1.0 Parameter

                    #region 15.2.1 Gather Data
                    if (chkIsSelected.Checked)
                    {
                        entMST_Employee.EmpName = txtEmployeeName.Text.Trim();
                        entMST_Employee.EmpCode = txtEmployeeCode.Text.Trim();
                        entMST_Employee.Salary = Convert.ToInt32(txtSalary.Text.Trim());
                        entMST_Employee.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);
                        entMST_Employee.JoiningDate = Convert.ToDateTime(dtpJoiningDate.Text.Trim());
                        entMST_Employee.CreationDate = DateTime.Now;
                        entMST_Employee.ModifiedDate = DateTime.Now;
                    }
                    else
                    {
                        continue;
                    }
                    #endregion 15.2.1 Gather Data


                    if (txtEmployeeName.Text.Trim() != string.Empty && txtEmployeeCode.Text.Trim() != string.Empty && txtSalary.Text.Trim() != string.Empty && dtpJoiningDate.Text.Trim() != string.Empty)
                    {
                        if (chkIsSelected.Checked)
                        {
                            if (balMST_Employee.Insert(entMST_Employee))
                            {
                                ucMessage.ShowSuccess("Employee Save Successfully");
                            }

                        }
                    }
                    else
                    {
                        ucMessage.ShowError("Enter Row With Employee Name & Employee Code & Salary & Joining Date");
                        break;
                    }

                }

                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }
            }

            if (!FiledFill)
            {
                ucMessage.ShowError("Insert Atleast 1 Employee Detail");
            }
        

        }
    }

    #region 16.0 Clear Controls
    private void ClearControls()
    {
        ddlDepartmentName.SelectedIndex = 0;
    }
    #endregion 16.0 Clear Controls
}