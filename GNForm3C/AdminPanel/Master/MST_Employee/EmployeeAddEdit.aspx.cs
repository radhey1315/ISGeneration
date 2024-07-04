using GNForm3C.BAL;
using GnForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C;

public partial class AdminPanel_Master_MST_Employee_EmployeeAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownList();
            FillCheckboxListHobby();
            if (Request.QueryString["EmployeeID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["EmployeeID"]));
            }
        }
      
    }

    #region FillCheckboxListHobby
    protected void FillCheckboxListHobby()
    {
        CommonFillMethodsSmit.FillCheckboxListHobby(cblHobby);
    }
    #endregion FillCheckboxListHobby

    private void FillControls(SqlInt32 EmployeeID)
    {
        MST_EmployeeENTBase entEmployee = new MST_EmployeeENTBase();
        MST_EmployeeBALBase balEmployee = new MST_EmployeeBALBase();

        entEmployee = balEmployee.SelectByPK(EmployeeID);


        if (!entEmployee.EmpName.IsNull)
        {
            txtEmployeeName.Text = entEmployee.EmpName.Value.ToString();
        }
        if (!entEmployee.EmpCode.IsNull)
        {
            txtEmployeeCode.Text = entEmployee.EmpCode.Value.ToString();
        }
        if (!entEmployee.Salary.IsNull)
        {
            txtSalary.Text = entEmployee.Salary.Value.ToString();
        }
        if (!entEmployee.Remarks.IsNull)
        {
            txtRemarks.Text = entEmployee.Remarks.Value.ToString();
        }
        if (!entEmployee.DepartmentID.IsNull)
        {
            ddlDepartmentName.SelectedValue = entEmployee.DepartmentID.ToString();
        }
        if (!entEmployee.JoiningDate.IsNull)
        {
            dtpJoiningDate.Text = entEmployee.JoiningDate.ToString();
        }
        if (entEmployee.cblHobby != null)
        {
            int i = 0;
            foreach (ListItem cblItem in cblHobby.Items)
            {
                if ((i) < entEmployee.cblHobby.Count)
                {
                    if (entEmployee.cblHobby[i].ToString() == cblItem.Value.ToString())
                    {
                        cblItem.Selected = true;
                        i++;
                    }
                }
            }
        }
    }

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListDepartmentID(ddlDepartmentName);
    }

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {

            try
            {

                #region entEmployee
                MST_EmployeeENTBase entEmployee = new MST_EmployeeENTBase();
              


                if (txtEmployeeName.Text.Trim() != "")
                {
                    entEmployee.EmpName = txtEmployeeName.Text.Trim();
                }
                if (txtEmployeeCode.Text.Trim() != "")
                {
                    entEmployee.EmpCode = txtEmployeeCode.Text.Trim();
                }
                if (ddlDepartmentName.SelectedIndex > 0)
                {
                    entEmployee.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);
                }

                if (txtSalary.Text.Trim() != "")
                {
                    entEmployee.Salary = Convert.ToInt32(txtSalary.Text.Trim());
                }

                if (dtpJoiningDate.Text.Trim() != String.Empty)
                    entEmployee.JoiningDate = Convert.ToDateTime(dtpJoiningDate.Text.Trim(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                if (txtRemarks.Text.Trim() != "")
                {
                    entEmployee.Remarks = txtRemarks.Text.Trim();
                }

                foreach (ListItem cblItem in cblHobby.Items)
                {
                    if (cblItem.Selected)
                    {
                        entEmployee.cblHobby.Add(Convert.ToInt32(cblItem.Value));
                    }
                }

                entEmployee.ModifiedDate = DateTime.Now;

                #endregion entEmployee


                MST_EmployeeBALBase balEmployee = new MST_EmployeeBALBase();

                if (Request.QueryString["EmployeeID"] == null)
                {
                    entEmployee.CreationDate = DateTime.Now;
                    if (balEmployee.Insert(entEmployee))
                    {
                        //ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        ClearControls();
                    }
                }
                else
                {
                    entEmployee.EmployeeID = Convert.ToInt32(Request.QueryString["EmployeeID"]);

                    if (balEmployee.Update(entEmployee))
                    {
                       // ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        Response.Redirect("~/AdminPanel/Master/MST_Employee/EmployeeList.aspx");
                        
                    }
                }
                    

            }

            catch (Exception ex)
            {
                //ucMessage.ShowError(ex.Message);
            }
        }
    } 
    

    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 
    private void ClearControls()
    {
        txtEmployeeName.Text = String.Empty;
        txtEmployeeCode.Text = String.Empty;
        txtSalary.Text = String.Empty;
        ddlDepartmentName.SelectedIndex = 0;
        dtpJoiningDate.Text = String.Empty;
        txtRemarks.Text = String.Empty;

        txtEmployeeName.Focus();
        foreach (ListItem cblItem in cblHobby.Items)
        {
            if (cblItem.Selected)
            {
                cblItem.Selected = false;
            }
        }
    }

    #endregion 16.0 Clear Controls 
}