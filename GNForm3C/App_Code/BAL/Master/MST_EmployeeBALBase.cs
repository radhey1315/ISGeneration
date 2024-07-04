using GnForm3C.ENT;
using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_EmployeeBALBase
/// </summary>
/// 

namespace GNForm3C.BAL
{
    public class MST_EmployeeBALBase
    {
        #region Local Variable
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variable


        #region Constructor
        public MST_EmployeeBALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor


        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            MST_EmployeeDALBase dalEmployee = new MST_EmployeeDALBase();
            return dalEmployee.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPk
        public MST_EmployeeENTBase SelectByPK(SqlInt32 EmployeeID)
        {
            MST_EmployeeDALBase dalEmployee = new MST_EmployeeDALBase();
            return dalEmployee.SelectByPK(EmployeeID);
        }
        #endregion SelectByPk

        public DataTable SelectShow(SqlInt32 DepartmentID)
        {
            MST_EmployeeDALBase dalMST_Employee = new MST_EmployeeDALBase();
            return dalMST_Employee.SelectShow(DepartmentID);
        }


        #endregion Select Operation

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageRecordSize, out Int32 TotalRecords, SqlString EmpName, SqlString EmpCode, SqlInt32 Department, SqlString Hobbies)
        {
            MST_EmployeeDALBase dalMST_Employee = new MST_EmployeeDALBase();
            return dalMST_Employee.SelectPage(PageOffset, PageRecordSize, out TotalRecords, EmpName, EmpCode, Department, Hobbies);
        }


        #region Delete

        public Boolean Delete(SqlInt32 EmployeeID)
        {
            MST_EmployeeDALBase dalEmployee = new MST_EmployeeDALBase();
            if (dalEmployee.Delete(EmployeeID))
            {
                return true;
            }
            else
            {
                // Message before equal sign is bal message and after equal sign is of dal message  
                Message = dalEmployee.Message;
                return false;
            }
        }


        #endregion Delete

        #region Insert
        public Boolean Insert(MST_EmployeeENTBase entEmployee)
        {
            MST_EmployeeDALBase dalEmployee = new MST_EmployeeDALBase();
            return dalEmployee.Insert(entEmployee);
        }

        #endregion Insert


        #region ComboBox

        public DataTable SelectComboBox()
        {
            MST_EmployeeDALBase dalMST_Employee = new MST_EmployeeDALBase();
            return dalMST_Employee.SelectComboBox();
        }

        public DataTable SelectView(SqlInt32 EmployeeID)
        {
            MST_EmployeeDALBase dalCountry = new MST_EmployeeDALBase();
            return dalCountry.SelectView(EmployeeID);
        }


        #endregion ComboBox
        public Boolean Update(MST_EmployeeENTBase entEmployee)
        {
            MST_EmployeeDALBase dalEmployee = new MST_EmployeeDALBase();
            return dalEmployee.Update(entEmployee);
        }

        public DataTable FillCheckboxListHobby()
        {
            MST_EmployeeDALBase dalEmployee = new MST_EmployeeDALBase();
            return dalEmployee.FillCheckboxListHobby();
        }

    }
}