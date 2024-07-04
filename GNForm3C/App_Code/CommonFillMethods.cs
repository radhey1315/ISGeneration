using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using System.Data.SqlTypes;
using GNForm3C.ENT;

namespace GNForm3C
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
        }
        public static void FillDropDownListTransactionID(DropDownList ddl)
        {
            ACC_TransactionBAL balACC_Transaction = new ACC_TransactionBAL();
            ddl.DataSource = balACC_Transaction.SelectComboBox();
            ddl.DataValueField = "TransactionID";
            ddl.DataTextField = "Patient";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Transaction", "-99"));
        }
        public static void FillDropDownListExpenseTypeID(DropDownList ddl)
        {
            MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
            ddl.DataSource = balMST_ExpenseType.SelectComboBox();
            ddl.DataValueField = "ExpenseTypeID";
            ddl.DataTextField = "ExpenseType";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Expense Type", "-99"));
        }
        public static void FillDropDownListExpenseTypeIDByFinYearID(DropDownList ddl, SqlInt32 FinYearID, SqlInt32 HospitalID)
        {
            MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
            ddl.DataSource = balMST_ExpenseType.SelectComboBoxByFinYearID(FinYearID, HospitalID);
            ddl.DataValueField = "ExpenseTypeID";
            ddl.DataTextField = "ExpenseType";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Expense Type", "-99"));
        }
        public static void FillDropDownListFinYearID(DropDownList ddl)
        {
            MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
            ddl.DataSource = balMST_FinYear.SelectComboBox();
            ddl.DataValueField = "FinYearID";
            ddl.DataTextField = "FinYearName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        }
        public static void FillDropDownListFinYearIDByHospitalID(DropDownList ddl, SqlInt32 HospitalID)
        {
            MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
            ddl.DataSource = balMST_FinYear.SelectComboBoxByHospitalID(HospitalID);
            ddl.DataValueField = "FinYearID";
            ddl.DataTextField = "FinYearName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        }
        public static void FillDropDownListExpenseFinYearIDByHospitalID(DropDownList ddl, SqlInt32 HospitalID)
        {
            MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
            ddl.DataSource = balMST_FinYear.SelectExpenseComboBoxByHospitalID(HospitalID);
            ddl.DataValueField = "FinYearID";
            ddl.DataTextField = "FinYearName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        }
        public static void FillDropDownListHospitalID(DropDownList ddl)
        {
            MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
            ddl.DataSource = balMST_Hospital.SelectComboBox();
            ddl.DataValueField = "HospitalID";
            ddl.DataTextField = "Hospital";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Shop", "-99"));
        }
        public static void FillDropDownListDepartmentID(DropDownList ddl)
        {
            MST_EmployeeBALBase balEmployee = new MST_EmployeeBALBase();
            ddl.DataSource = balEmployee.SelectComboBox();
            ddl.DataValueField = "DepartmentID";
            ddl.DataTextField = "DepartmentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Department", "-99"));
        }
        public static void FillDropDownListIncomeTypeID(DropDownList ddl)
        {
            MST_IncomeTypeBAL balMST_IncomeType = new MST_IncomeTypeBAL();
            ddl.DataSource = balMST_IncomeType.SelectComboBox();
            ddl.DataValueField = "IncomeTypeID";
            ddl.DataTextField = "IncomeType";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Income Type", "-99"));
        }
        public static void FillDropDownListIncomeTypeIDByFinYearID(DropDownList ddl, SqlInt32 FinYearID, SqlInt32 HospitalID)
        {
            MST_IncomeTypeBAL balMST_IncomeType = new MST_IncomeTypeBAL();
            ddl.DataSource = balMST_IncomeType.SelectComboBoxByFinYearID(FinYearID, HospitalID);
            ddl.DataValueField = "IncomeTypeID";
            ddl.DataTextField = "IncomeType";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Income Type", "-99"));
        }
        public static void FillDropDownListReceiptTypeID(DropDownList ddl)
        {
            MST_ReceiptTypeBAL balMST_ReceiptType = new MST_ReceiptTypeBAL();
            ddl.DataSource = balMST_ReceiptType.SelectComboBox();
            ddl.DataValueField = "ReceiptTypeID";
            ddl.DataTextField = "ReceiptTypeName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Receipt Type", "-99"));
        }
        public static void FillDropDownListSubTreatmentID(DropDownList ddl)
        {
            MST_SubTreatmentBAL balMST_SubTreatment = new MST_SubTreatmentBAL();
            ddl.DataSource = balMST_SubTreatment.SelectComboBox();
            ddl.DataValueField = "SubTreatmentID";
            ddl.DataTextField = "SubTreatmentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Sub Treatment", "-99"));
        }
        public static void FillDropDownListTreatmentID(DropDownList ddl)
        {
            MST_TreatmentBAL balMST_Treatment = new MST_TreatmentBAL();
            ddl.DataSource = balMST_Treatment.SelectComboBox();
            ddl.DataValueField = "TreatmentID";
            ddl.DataTextField = "Treatment";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Treatment", "-99"));
        }
        public static void FillDropDownListUserID(DropDownList ddl)
        {
            SEC_UserBAL balSEC_User = new SEC_UserBAL();
            ddl.DataSource = balSEC_User.SelectComboBox();
            ddl.DataValueField = "UserID";
            ddl.DataTextField = "UserName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select User", "-99"));
        }
    }
}
