using GNForm3C.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using GnForm3C.ENT;
using GNForm3C.ENT;

/// <summary>
/// Summary description for MST_EmployeeDALBase
/// </summary>
/// 

namespace GNForm3C.DAL
{
    public class MST_EmployeeDALBase : DataBaseConfig
    {
        #region Properties

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

        #endregion Properties

        #region Constructor
        public MST_EmployeeDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region SelectOperation
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_Employee_SelectAll";
                        cmd.Parameters.AddWithValue("UserID", 4);
                        #endregion Prepare Command 

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = cmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }


        #region SelectPage
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageRecordSize, out Int32 TotalRecords, SqlString EmpName, SqlString EmpCode, SqlInt32 Department, SqlString Hobbies)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Employee_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageRecordSize", SqlDbType.Int, PageRecordSize);
                sqlDB.AddInParameter(dbCMD, "@EmpName", SqlDbType.VarChar, EmpName);
                sqlDB.AddInParameter(dbCMD, "@EmpCode", SqlDbType.VarChar, EmpCode);
                sqlDB.AddInParameter(dbCMD, "@Department", SqlDbType.Int, Department);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@Hobbies", SqlDbType.VarChar, Hobbies);

                DataTable dtEmployee = new DataTable("PR_Employee_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtEmployee);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtEmployee;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion SelectPage

        #region Select View
        public DataTable SelectView(SqlInt32 EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Employee_SelectView");

                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, EmployeeID);

                DataTable dtMST_Country = new DataTable("PR_Employee_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Country);

                return dtMST_Country;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion Select View


        #region select by pk

        public MST_EmployeeENTBase SelectByPK(SqlInt32 EmployeeID)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_Employee_SelectByPK";
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        MST_EmployeeENTBase entEmployee = new MST_EmployeeENTBase();
                        using (SqlDataReader objSDR = cmd.ExecuteReader())
                        {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["EmployeeID"].Equals(System.DBNull.Value))
                                    {
                                        entEmployee.EmployeeID = Convert.ToInt32(objSDR["EmployeeID"]);
                                    }
                                    if (!objSDR["EmpName"].Equals(DBNull.Value))
                                    {
                                        entEmployee.EmpName = Convert.ToString(objSDR["EmpName"]);
                                    }

                                    if (!objSDR["EmpCode"].Equals(DBNull.Value))
                                    {
                                        entEmployee.EmpCode = Convert.ToString(objSDR["EmpCode"]);
                                    }
                                    if (!objSDR["Salary"].Equals(DBNull.Value))
                                    {
                                        entEmployee.Salary = Convert.ToInt32(objSDR["Salary"]);
                                    }
                                    if (!objSDR["Remarks"].Equals(DBNull.Value))
                                    {
                                        entEmployee.Remarks = Convert.ToString(objSDR["Remarks"]);
                                    }
                                    if (!objSDR["JoiningDate"].Equals(DBNull.Value))
                                    {
                                        entEmployee.JoiningDate = Convert.ToDateTime(objSDR["JoiningDate"]);
                                    }
                                    if (!objSDR["DepartmentID"].Equals(DBNull.Value))
                                    {
                                        entEmployee.DepartmentID = Convert.ToInt32(objSDR["DepartmentID"]);
                                    }
                                    if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    {
                                        entEmployee.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                    }
                                    if (!objSDR["ModifiedDate"].Equals(DBNull.Value))
                                    {
                                        entEmployee.ModifiedDate = Convert.ToDateTime(objSDR["ModifiedDate"]);
                                    }
                                    break;

                                }
                            }
                        
                            int i = 0;
                            using (SqlDataReader objSDR = cmd.ExecuteReader())
                            {
                                while (objSDR.Read())
                                {
                                    entEmployee.cblHobby.Add(i);
                                    if (!objSDR["HobbyID"].Equals(DBNull.Value))
                                    {
                                        entEmployee.cblHobby[i] = Convert.ToInt32(objSDR["HobbyID"].ToString());
                                        i++;
                                    }
                                }
                            }
                            return entEmployee;
                        }
                    

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion select by pk

        #region Select show
        public DataTable SelectShow(SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Employee_SelectShow");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);


                DataTable dtMST_ExpenseType = new DataTable("PR_Employee_SelectShow");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ExpenseType);


                return dtMST_ExpenseType;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion Select show


        #endregion SelectOperation

        #region Delete Operation

        public Boolean Delete(SqlInt32 EmployeeID)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Salary Type wise Record Delete
                        if (!EmployeeID.IsNull)
                        {
                            SqlDatabase sqlDb = new SqlDatabase(myConnectionString);
                            DbCommand dbCmd = sqlDb.GetStoredProcCommand("PR_MST_EmployeeWiseHobby_Delete_SV");
                            DataBaseHelper DBH = new DataBaseHelper();

                            sqlDb.AddInParameter(dbCmd, "EmployeeID", DbType.Int32, EmployeeID);
                            DBH.ExecuteNonQuery(sqlDb, dbCmd);
                        }
                        #endregion Salary Type wise Record Delete


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_Employee_DeleteByPK";
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        cmd.ExecuteNonQuery();

                        return true;

                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion Delete Operation

        #region Insert Operation
        public Boolean Insert(MST_EmployeeENTBase entEmployee)
        {

            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Employee_Insert");

            #region Prepare Command
          
            sqlDB.AddOutParameter(dbCMD, "EmployeeID", SqlDbType.Int, 4);
            sqlDB.AddInParameter(dbCMD, "DepartmentID", SqlDbType.Int, entEmployee.DepartmentID);
            sqlDB.AddInParameter(dbCMD, "Salary", SqlDbType.Int, entEmployee.Salary);
            sqlDB.AddInParameter(dbCMD, "JoiningDate", SqlDbType.DateTime, entEmployee.JoiningDate);
            sqlDB.AddInParameter(dbCMD, "EmpName", SqlDbType.NVarChar, entEmployee.EmpName);
            sqlDB.AddInParameter(dbCMD, "EmpCode", SqlDbType.NVarChar, entEmployee.EmpCode);


            if (entEmployee.Remarks != "")
                sqlDB.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, entEmployee.Remarks);
            else
                sqlDB.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, null);


            // sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, entEmployee.UserID);
            sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, entEmployee.CreationDate);
            sqlDB.AddInParameter(dbCMD, "ModifiedDate", SqlDbType.DateTime, entEmployee.ModifiedDate);


            #endregion Prepare Command

            #region ExecuteInsert
            DataBaseHelper DBH = new DataBaseHelper();

            DBH.ExecuteNonQuery(sqlDB, dbCMD);
            entEmployee.EmployeeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@EmployeeID"].Value);
            EmployeeWiseHobby(entEmployee);
            return true;

            #endregion ExecuteInsert

        }

        #endregion Insert Operation

        #region EmployeewiseHobby

        public Boolean EmployeeWiseHobby(MST_EmployeeENTBase entEmployee)
        {
            try
            {

                if (HttpContext.Current.Request.QueryString["EmployeeID"] != null)
                {
                    SqlDatabase sqlDb = new SqlDatabase(myConnectionString);
                    DbCommand dbCmd = sqlDb.GetStoredProcCommand("PR_MST_EmployeewiseHobby_Delete_SV");
                    DataBaseHelper DBH = new DataBaseHelper();

                    sqlDb.AddInParameter(dbCmd, "EmployeeID", DbType.Int32, entEmployee.EmployeeID);
                    DBH.ExecuteNonQuery(sqlDb, dbCmd);
                }

                for (int i = 0; i < entEmployee.cblHobby.Count; i++)
                {
                    SqlDatabase sqlDb = new SqlDatabase(myConnectionString);
                    DbCommand dbCmd = sqlDb.GetStoredProcCommand("PR_EmployeewiseHobby_Insert_SV");
                    DataBaseHelper DBH = new DataBaseHelper();

                    sqlDb.AddInParameter(dbCmd, "EmployeeID", SqlDbType.Int, entEmployee.EmployeeID);
                    sqlDb.AddInParameter(dbCmd, "HobbyID", SqlDbType.Int, Convert.ToInt32(entEmployee.cblHobby[i]));

                    DBH.ExecuteNonQuery(sqlDb, dbCmd);

                }

                return true;
            }
            catch (Exception e)
            {
                entEmployee.Message = e.Message;
                return false;
            }
        }

        #endregion EmployeewiseHobby

        #region update

        public Boolean Update(MST_EmployeeENTBase entEmployee)
        {

            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Employee_UpdateByPK");

            sqlDB.AddInParameter(dbCMD, "EmployeeID", SqlDbType.Int, 4);

            sqlDB.AddInParameter(dbCMD, "DepartmentID", SqlDbType.Int, entEmployee.DepartmentID);
            sqlDB.AddInParameter(dbCMD, "Salary", SqlDbType.Int, entEmployee.Salary);
            sqlDB.AddInParameter(dbCMD, "JoiningDate", SqlDbType.DateTime, entEmployee.JoiningDate);
            sqlDB.AddInParameter(dbCMD, "ModifiedDate", SqlDbType.DateTime, entEmployee.ModifiedDate);
            sqlDB.AddInParameter(dbCMD, "EmpName", SqlDbType.NVarChar, entEmployee.EmpName);
            sqlDB.AddInParameter(dbCMD, "EmpCode", SqlDbType.NVarChar, entEmployee.EmpCode);


            if (entEmployee.Remarks != "")
                sqlDB.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, entEmployee.Remarks);
            else
                sqlDB.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, null);


          

            DataBaseHelper DBH = new DataBaseHelper();

            DBH.ExecuteNonQuery(sqlDB, dbCMD);
            EmployeeWiseHobby(entEmployee);
            return true;


        }

        #endregion update

        #region Select Comobo box
        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Department_SelectComboBox");


                DataTable dtMST_Employee = new DataTable("PR_Department_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Employee);

                return dtMST_Employee;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion Select Comobo box


        #region FillCheckboxList
        public DataTable FillCheckboxListHobby()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_MST_Hobby_FillCombobox_SV";
                        #endregion Prepare Command

                        #region ReadData and SetControls

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and SetControls

                    }
                    catch (SqlException sqlEx)
                    {
                        Message = sqlEx.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
            }
        }

        #endregion FillCheckboxList
    }
} 


