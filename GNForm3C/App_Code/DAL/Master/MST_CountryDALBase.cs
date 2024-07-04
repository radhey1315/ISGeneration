using GNForm3C.DAL;
using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using GnForm3C;
using GnForm3C.ENT;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for MST_CountryDALBase
/// </summary> 
/// 
namespace GNForm3C.DAL
{
    public class MST_CountryDALBase : DataBaseConfig
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

        public  MST_CountryDALBase()
        {

        }

        #endregion Constructor


        #region Insert Operation
        public Boolean Insert(MST_CountryENTBase entCountry)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_MST_Country_Insert";

                    cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entCountry.CountryID;
                    cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = entCountry.CountryName;
                    cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = entCountry.CountryCode;

                    //if (Request.QueryString["CountryID"] == null)
                    //{
                    //    cmd.CommandText = "PR_Country_InsertAll";
                    //   // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Add Successful" + "');", true);

                    //}
                    //else
                    //{
                    //    cmd.CommandText = "PR_Country_UpdateByPK";
                    //  //  ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Add Successful" + "');", true);

                    //}
                    cmd.ExecuteNonQuery();
                    objConn.Close();
                    return true;


                }

                //catch (SqlException sqlex)
                //{
                //    Message = sqlex.InnerException.Message;
                //    return false;
                //}

                //catch (Exception ex)
                //{
                //   Message = ex.InnerException.Message;
                //    return false;
                //}

                //finally
                //{
                //    if (objConn.State == ConnectionState.Open)
                //        objConn.Close();
                //}

            }
        }

        #endregion Insert Operation

        #region update

        public Boolean Update(MST_CountryENTBase entCountry)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {

                objConn.Open();
                try
                {


                    using (SqlCommand cmd = objConn.CreateCommand())
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_MST_Country_UpdateByPK";

                        cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entCountry.CountryID;
                        cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = entCountry.CountryName;
                        cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = entCountry.CountryCode;


                        cmd.ExecuteNonQuery();
                        objConn.Close();
                        return true;

                    }
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

        #endregion update


        #region Delete Operation

        public Boolean Delete(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_MST_Country_DeleteByPK";
                        cmd.Parameters.AddWithValue("@CountryID", CountryID);
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


        #region select by pk

        public MST_CountryENTBase SelectByPK(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand cmd = objConn.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_MST_Country_SelectByPK";
                        cmd.Parameters.AddWithValue("@CountryID", CountryID);

                        MST_CountryENTBase entCountry = new MST_CountryENTBase();
                        using (SqlDataReader objSDR = cmd.ExecuteReader())
                        {
                            if (objSDR.HasRows == true)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["CountryID"].Equals(System.DBNull.Value))
                                    { 
                                        entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                    }
                                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                                    {
                                        entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);
                                    }

                                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                    {
                                        entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);
                                    }

                                }
                            }
                            return entCountry;
                        }
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
                        cmd.CommandText = "PR_MST_Country_SelectAll";
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageRecordSize, out Int32 TotalRecords, SqlString CountryName, SqlString CountryCode)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Country_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageRecordSize", SqlDbType.Int, PageRecordSize);
                sqlDB.AddInParameter(dbCMD, "@CountryName", SqlDbType.VarChar, CountryName);
                sqlDB.AddInParameter(dbCMD, "@CountryCode", SqlDbType.VarChar, CountryCode);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

                DataTable dtMST_Country = new DataTable("PR_MST_Country_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Country);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

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

        #endregion SelectPage

        #region Select View
        public DataTable SelectView(SqlInt32 CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Country_SelectView");

                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);

                DataTable dtMST_Country = new DataTable("PR_MST_Country_SelectView");

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

        #region ComboBox

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Country_SelectComboBox");

                DataTable dtMST_Hospital = new DataTable("PR_MST_Country_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

                return dtMST_Hospital;
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

        #endregion ComboBox


        #endregion SelectOperation

    }
}