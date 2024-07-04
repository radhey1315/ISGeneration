using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IncomeType
/// </summary>

namespace GNForm3C.ENT
{
    public class IncomeType
    {
        #region Constructor
        public IncomeType()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        #endregion Constructor

        #region Message

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

        #endregion Message

        #region IncomeID

        protected SqlInt32 _IncomeID;

        public SqlInt32 IncomeID
        {
            get
            {
                return _IncomeID;
            }
            set
            {
                _IncomeID = value;
            }
        }
        
        #endregion IncomeID

        #region IncomeTypeID

        protected SqlInt32 _IncomeTypeID;

        public SqlInt32 IncomeTypeID
        {
            get
            {
                return _IncomeTypeID;
            }
            set
            {
                _IncomeTypeID = value;
            }
        }
        
        #endregion IncomeTypeID

        #region Amount

        protected SqlDecimal _Amount;

        public SqlDecimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }

        #endregion Amount

        #region IncomeDate

        protected SqlDateTime _IncomeDate;

        public SqlDateTime IncomeDate
        {
            get
            {
                return _IncomeDate;
            }
            set
            {
                _IncomeDate = value;
            }
        }

        #endregion Amount

        #region Note

        protected SqlString _Note;

        public SqlString Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }

        #endregion Note

        #region HospitalID

        protected SqlInt32 _HospitalID;

        public SqlInt32 HospitalID
        {
            get
            {
                return _HospitalID;
            }
            set
            {
                _HospitalID = value;
            }
        }

        #endregion HospitalID

        #region FinYearID

        protected SqlInt32 _FinYearID;

        public SqlInt32 FinYearID
        {
            get
            {
                return _FinYearID;
            }
            set
            {
                _FinYearID = value;
            }
        }

        #endregion FinYearID

        #region Remarks

        protected SqlString _Remarks;

        public SqlString Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }

        #endregion Remarks

        #region UserID

        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        #endregion UserID

        #region Created

        protected DateTime _Created;

        public DateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                _Created = value;
            }
        }

        #endregion Created

        #region Modified

        protected DateTime _Modified;

        public DateTime Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                _Modified = value;
            }
        }

        #endregion Modified

        #region cblSalary
        
        protected List<int> _cblSalary = new List<int>();

        public List<int> cblSalary
        {
            get
            {
                return _cblSalary;
            }
            set
            {
                _cblSalary = value;
            }
        }

        #endregion cblSalary


    }
}