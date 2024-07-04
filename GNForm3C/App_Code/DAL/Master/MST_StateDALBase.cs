using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;
using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using GnForm3C.ENT;

/// <summary>
/// Summary description for MST_StateDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public class MST_StateDALBase : DataBaseConfig
    {



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


        public MST_StateDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {
                    try
                    {
                      
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_MST_State_SelectAll";
                     

                      
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = cmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                   
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


        public Boolean Delete(SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_MST_State_DeleteByPK";
                        cmd.Parameters.AddWithValue("@StateID", StateID);

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


        public DataTable SelectAllCountry()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                      
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_MST_Country_SelectComboBox";
                      

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                     

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


        public Boolean Insert(MST_StateENTBase entState)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_State_Insert");

             
                //objCmd.CommandType = CommandType.StoredProcedure;
                //objCmd.CommandText = "PR_ACC_Income_Insert";
                //objCmd.Parameters.AddWithValue("IncomeID", entState.IncomeID).Direction = ParameterDirection.Output;

                sqlDB.AddOutParameter(dbCMD, "StateID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.VarChar, entState.StateName);
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, entState.StateCode);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, entState.CountryID);
                if (entState.Description != "")
                    sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, entState.Description);
                else
                    sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, null);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entState.StateID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@StateID"].Value);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #region UpdateOperation

        public Boolean Update(MST_StateENTBase entState)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_State_Update");
                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, entState.StateID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.VarChar, entState.StateName);
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, entState.StateCode);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, entState.CountryID);
                if (entState.Description != "")
                    sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, entState.Description);
                else
                    sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, null);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion UpdateOperation


        public MST_StateENTBase SelectByPK(SqlInt32 StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_State_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);

                MST_StateENTBase entState = new MST_StateENTBase();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                         if (!dr["StateID"].Equals(System.DBNull.Value))
                           entState.StateID = Convert.ToInt32(dr["StateID"]);

                        if (!dr["StateName"].Equals(System.DBNull.Value))
                            entState.StateName = Convert.ToString(dr["StateName"]);
                        if (!dr["StateCode"].Equals(System.DBNull.Value))
                            entState.StateCode = Convert.ToString(dr["StateCode"]);

                        if (!dr["CountryID"].Equals(System.DBNull.Value))
                            entState.CountryID = Convert.ToInt32(dr["CountryID"]);

                        if (!dr["Description"].Equals(System.DBNull.Value))
                            entState.Description = Convert.ToString(dr["Description"]);


                    }
                }
                return entState;
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



        #region SelectAllData for View
        public DataTable SelectAllDataForView(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_MST_State_SelectView";
                        objCmd.Parameters.AddWithValue("StateID", StateID);
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
        #endregion SelectAllData for View


        #region SelectPage
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageRecordSize, out Int32 TotalRecords, SqlString StateName, SqlString CountryName, SqlString StateCode)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_State_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageRecordSize", SqlDbType.Int, PageRecordSize);
                sqlDB.AddInParameter(dbCMD, "@StateName", SqlDbType.VarChar, StateName);
                sqlDB.AddInParameter(dbCMD, "@CountryName", SqlDbType.VarChar, CountryName);
                sqlDB.AddInParameter(dbCMD, "@StateCode", SqlDbType.VarChar, StateCode);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

                DataTable dtMST_State = new DataTable("PR_MST_State_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_State);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtMST_State;
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

    }
}