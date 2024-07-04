using GnForm3C.ENT;
using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_StateBALBase
/// </summary>
/// 

namespace GNForm3C.BAL
{
    public class MST_StateBALBase
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
        public MST_StateBALBase()
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
            MST_StateDALBase dalState = new MST_StateDALBase();
            return dalState.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPK
        public MST_StateENTBase SelectByPK(SqlInt32 StateID)
        {
            MST_StateDALBase dalState = new MST_StateDALBase();
            return dalState.SelectByPK(StateID);
        }
        #endregion SelectByPK

        #region select Country ddl
        public DataTable SelectForCountryDDL()
        {
            MST_StateDALBase dalIncomeType = new MST_StateDALBase();
            return dalIncomeType.SelectAllCountry();
        }
        #endregion select Country ddl

        #region select view
        public DataTable SelectView(SqlInt32 StateID)
        {
            MST_StateDALBase dalIncomeType = new MST_StateDALBase();
            return dalIncomeType.SelectAllDataForView(StateID);
        }
        #endregion select view

        #region select Page
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageRecordSize, out Int32 TotalRecords, SqlString StateName, SqlString CountryName, SqlString StateCode)
        {
            MST_StateDALBase dalMST_State = new MST_StateDALBase();
            return dalMST_State.SelectPage(PageOffset, PageRecordSize, out TotalRecords, StateName, StateCode, CountryName);
        }
        #endregion select Page

        #endregion Select Operation


        #region Delete

        public Boolean Delete(SqlInt32 StateID)
        {
            MST_StateDALBase dalState = new MST_StateDALBase();
            if (dalState.Delete(StateID))
            {
                return true;
            }
            else
            {
                // Message before equal sign is bal message and after equal sign is of dal message  
                Message = dalState.Message;
                return false;
            }
        }


        #endregion Delete

        
        #region InsertOperation

        public Boolean Insert(MST_StateENTBase entState)
        {
            MST_StateDALBase dalMST_State = new MST_StateDALBase();
            if (dalMST_State.Insert(entState))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_State.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_StateENTBase entState)
        {
            MST_StateDALBase dalMST_State = new MST_StateDALBase();
            if (dalMST_State.Update(entState))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_State.Message;
                return false;
            }
        }

        #endregion UpdateOperation



       

    }
}