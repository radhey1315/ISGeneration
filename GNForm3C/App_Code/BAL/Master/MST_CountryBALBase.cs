using GnForm3C.ENT;
using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

// <summary>
// Summary description for MST_CountryBALBase
// </summary>

namespace GNForm3C.BAL
{
    public class MST_CountryBALBase
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

        public MST_CountryBALBase()
        {

        }


        #endregion Constructor

        #region Delete

        public Boolean Delete(SqlInt32 CountryID)
        {
            MST_CountryDALBase dalCountry = new MST_CountryDALBase();
            if (dalCountry.Delete(CountryID))
            {
                return true;
            }
            else
            {
                // Message before equal sign is bal message and after equal sign is of dal message  
                Message = dalCountry.Message;
                return false;
            }
        }


        #endregion Delete


        #region Insert
        public Boolean Insert(MST_CountryENTBase entCountry)
        {
            MST_CountryDALBase dalCountry = new MST_CountryDALBase();
            return dalCountry.Insert(entCountry);
        }
        public Boolean Update(MST_CountryENTBase entCountry)
        {
            MST_CountryDALBase dalCountry = new MST_CountryDALBase();
            return dalCountry.Update(entCountry);
        }


        #endregion Insert


        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            MST_CountryDALBase dalCountry = new MST_CountryDALBase();
            return dalCountry.SelectAll();
        }
        #endregion SelectAll


        #region SelectByPk
        public MST_CountryENTBase SelectByPK(SqlInt32 CountryID)
        {
            MST_CountryDALBase dalCountry = new MST_CountryDALBase();
            return dalCountry.SelectByPK(CountryID);
        }
        #endregion SelectByPk

        #endregion Select Operation


        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageRecordSize, out Int32 TotalRecords, SqlString CountryName, SqlString CountryCode)
        {
            MST_CountryDALBase dalMST_Country = new MST_CountryDALBase();
            return dalMST_Country.SelectPage(PageOffset, PageRecordSize, out TotalRecords, CountryName, CountryCode);
        }


        public DataTable SelectView(SqlInt32 CountryID)
        {
            MST_CountryDALBase dalCountry = new MST_CountryDALBase();
            return dalCountry.SelectView(CountryID);
        }

        #region ComboBox

        public DataTable SelectComboBox()
        {
            MST_CountryDALBase dalMST_Hospital = new MST_CountryDALBase();
            return dalMST_Hospital.SelectComboBox();
        }

        #endregion ComboBox

    }
}
