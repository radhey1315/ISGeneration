using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_EmployeeENTBase
/// </summary>
/// 

namespace GnForm3C.ENT
{
    public class MST_EmployeeENTBase
    {
        public MST_EmployeeENTBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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

        protected SqlInt32 _EmployeeID;
        public SqlInt32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }


        protected SqlString _EmpName;
        public SqlString EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                _EmpName = value;
            }
        }

        protected SqlString _EmpCode;
        public SqlString EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                _EmpCode = value;
            }
        }

        protected SqlInt32 _DepartmentID;
        public SqlInt32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }

        protected SqlInt32 _Salary;
        public SqlInt32 Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
            }
        }

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

        protected SqlDateTime _JoiningDate;
        public SqlDateTime JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }

        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                _CreationDate = value;
            }
        }

        protected SqlDateTime _ModifiedDate;
        public SqlDateTime ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
            }
        }

        protected SqlString _DepartmentName;
        public SqlString DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        #region cblHobby

        protected List<int> _cblHobby = new List<int>();

        public List<int> cblHobby
        {
            get
            {
                return _cblHobby;
            }
            set
            {
                _cblHobby = value;
            }
        }

        #endregion cblHobby

    }
}