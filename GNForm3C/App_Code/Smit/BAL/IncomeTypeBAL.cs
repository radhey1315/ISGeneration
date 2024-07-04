using GNForm3C;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for IncomeTypeBAL
/// </summary>

namespace GNForm3c.BAL
{
    public class IncomeTypeBAL
    {
        #region Constructor
        public IncomeTypeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert

        public Boolean Insert(IncomeType entIncomeType)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            if (dalIncomeType.Insert(entIncomeType))
                return true;
            else
            {
                return false;
            }
        }

        #endregion Insert

        #region Update

        public Boolean Update(IncomeType entIncomeType)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            if (dalIncomeType.Update(entIncomeType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Update

        #region Delete

        public Boolean Delete(SqlInt32 IncomeID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            if (dalIncomeType.Delete(IncomeID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Delete

        #region DropDownList IncomeType
        public DataTable SelectForIncomeTypeIDDDL()
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAll();
        }
        #endregion DropDownList IncomeType

        #region DropDownList Hospital

        public DataTable SelectForHospitalDDL()
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAllHospital();
        }
        
        #endregion DropDownList Hospital

        #region DropDownList FinYear

        public DataTable SelectForFinYearDDL()
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAllFinYear();
        }

        #endregion DropDownList FinYear

        #region SelectByPK
        public IncomeType SelectByPK(SqlInt32 IncomeTypeID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectByPK(IncomeTypeID);
        }
        #endregion SelectByPK

        #region SelectAll
        
        public DataTable SelectAll(SqlInt32 UserID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAllData(UserID);
        }

        public DataTable SelectView(SqlInt32 IncomeID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAllDataForView(IncomeID);
        }

        public DataTable SelectAllDashBoardRP(SqlInt32 UserID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAllDashBoardRP(UserID);
        }

        #endregion SelectAll

        #region DropDownList FinYear

        public DataTable SelectddlFinYear(SqlString CDate)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectFinYear(CDate);
        }

        #endregion DropDownList FinYear

        #region FillDropDownByHospitalID
        public DataTable DropDownListSelectByHospitalID(SqlInt32 HospitalID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.FillDDLByHospitalID(HospitalID);
        }
        #endregion FillDropDownByHospitalID

        #region Search
        public DataTable Search(IncomeType entIncomeType)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.Search(entIncomeType);
        }

        #endregion Search

        #region FillCheckboxList
        public DataTable FillCheckboxList()
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.FillCheckboxList();
        }
        #endregion FillCheckboxList

        #region Dashboard Count

        public DataTable SelectDashboardCount()
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectDashboardCount();
        }

        #endregion Dashboard Count

        #region SelectAllDashBoardExpense
        public DataTable SelectAllDashBoardExpense(int UserID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAllDashBoardExpense(UserID);
        }
        #endregion SelectAllDashBoardExpense

        public DataTable SelectAllDashBoardrpExpenseType(int UserID)
        {
            IncomeTypeDAL dalIncomeType = new IncomeTypeDAL();
            return dalIncomeType.SelectAllDashBoardrpExpenseType(UserID);
        }
    }
}