using GnForm3C;
using GNForm3C.DAL;
using GNForm3C.ENT;

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for IncomeTypeDAL
/// </summary>

namespace GNForm3C
{

    public class IncomeTypeDAL : DataBaseConfig
    {

        #region Constructor
        public IncomeTypeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local Variables

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


        #endregion Local Variables

        #region Insert Operation

        public Boolean Insert(IncomeType entIncomeType)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_Insert");

                #region Prepare Command
                //objCmd.CommandType = CommandType.StoredProcedure;
                //objCmd.CommandText = "PR_ACC_Income_Insert";
                //objCmd.Parameters.AddWithValue("IncomeID", entIncomeType.IncomeID).Direction = ParameterDirection.Output;

                sqlDB.AddOutParameter(dbCMD, "IncomeID", SqlDbType.Int, 4);

                sqlDB.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, entIncomeType.IncomeTypeID);
                sqlDB.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, entIncomeType.Amount);
                sqlDB.AddInParameter(dbCMD, "IncomeDate", SqlDbType.DateTime, entIncomeType.IncomeDate);

                if (entIncomeType.Note != "")
                    sqlDB.AddInParameter(dbCMD, "Note", SqlDbType.NVarChar, entIncomeType.Note);
                else
                    sqlDB.AddInParameter(dbCMD, "Note", SqlDbType.NVarChar, null);


                sqlDB.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, entIncomeType.HospitalID);
                sqlDB.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, entIncomeType.FinYearID);

                if (entIncomeType.Remarks != "")
                    sqlDB.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, entIncomeType.Remarks);
                else
                    sqlDB.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, null);


                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, entIncomeType.UserID);
                sqlDB.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, entIncomeType.Created);
                sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, entIncomeType.Modified);


                #endregion Prepare Command

                #region ExecuteInsert
                DataBaseHelper DBH = new DataBaseHelper();
                        
                DBH.ExecuteNonQuery(sqlDB, dbCMD);
                entIncomeType.Message = "Inserted Successfully.......";

                entIncomeType.IncomeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@IncomeID"].Value);
                IncomeTypewiseSalary(entIncomeType);

                return true;
                #endregion ExecuteInsert
            }
            catch (Exception e)
            {
                entIncomeType.Message = e.Message;
                return false;
            }
            finally
            {
                //objConn.Close();
            }

        }

        #endregion Insert Operation

        #region IncomeTypewiseSalary

        public Boolean IncomeTypewiseSalary(IncomeType entIncomeType)
        {
            try
            {

                if (HttpContext.Current.Request.QueryString["IncomeID"] != null)
                {
                    SqlDatabase sqlDb = new SqlDatabase(myConnectionString);
                    DbCommand dbCmd = sqlDb.GetStoredProcCommand("PR_IncomeTypewiseSalary_Delete_SV");
                    DataBaseHelper DBH = new DataBaseHelper();

                    sqlDb.AddInParameter(dbCmd, "IncomeID", DbType.Int32, entIncomeType.IncomeID);
                    DBH.ExecuteNonQuery(sqlDb, dbCmd);
                }

                for (int i = 0; i < entIncomeType.cblSalary.Count; i++)
                {
                    SqlDatabase sqlDb = new SqlDatabase(myConnectionString);
                    DbCommand dbCmd = sqlDb.GetStoredProcCommand("PR_IncomeTypewiseSalary_Insert_SV");
                    DataBaseHelper DBH = new DataBaseHelper();

                    sqlDb.AddInParameter(dbCmd, "IncomeID", SqlDbType.Int, entIncomeType.IncomeID);
                    sqlDb.AddInParameter(dbCmd, "SalaryIncomeTypeID", SqlDbType.Int, Convert.ToInt32(entIncomeType.cblSalary[i]));

                    DBH.ExecuteNonQuery(sqlDb, dbCmd);

                }

                return true;
            }
            catch (Exception e)
            {
                entIncomeType.Message = e.Message;
                return false;
            }
        }

        #endregion IncomeTypewiseSalary

        #region Update Operation

        public Boolean Update(IncomeType entIncomeType)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ACC_Income_Update_SV";
                        objCmd.Parameters.AddWithValue("IncomeID", entIncomeType.IncomeID);
                        objCmd.Parameters.AddWithValue("IncomeTypeID", entIncomeType.IncomeTypeID);
                        objCmd.Parameters.AddWithValue("Amount", entIncomeType.Amount);
                        objCmd.Parameters.AddWithValue("IncomeDate", entIncomeType.IncomeDate);

                        if (entIncomeType.Note != "")
                            objCmd.Parameters.AddWithValue("Note", entIncomeType.Note);
                        else
                            objCmd.Parameters.AddWithValue("Note", null);


                        objCmd.Parameters.AddWithValue("HospitalID", entIncomeType.HospitalID);
                        objCmd.Parameters.AddWithValue("FinYearID", entIncomeType.FinYearID);

                        if (entIncomeType.Remarks != "")
                            objCmd.Parameters.AddWithValue("Remarks", entIncomeType.Remarks);
                        else
                            objCmd.Parameters.AddWithValue("Remarks", null);


                        objCmd.Parameters.AddWithValue("UserID", entIncomeType.UserID);
                        objCmd.Parameters.AddWithValue("Modified", entIncomeType.Modified);


                        #endregion Prepare Command

                        #region ExecuteInsert
                        objCmd.ExecuteNonQuery();
                        entIncomeType.Message = "Updated Successfully.......";

                        IncomeTypewiseSalary(entIncomeType);

                        return true;
                        #endregion ExecuteInsert
                    }
                    catch (Exception e)
                    {
                        entIncomeType.Message = e.Message;
                        return false;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }

            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 IncomeID)
        {
            using (SqlConnection objConn = new SqlConnection(myConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Salary Type wise Record Delete
                        if (!IncomeID.IsNull)
                        {
                            SqlDatabase sqlDb = new SqlDatabase(myConnectionString);
                            DbCommand dbCmd = sqlDb.GetStoredProcCommand("PR_IncomeTypewiseSalary_Delete_SV");
                            DataBaseHelper DBH = new DataBaseHelper();

                            sqlDb.AddInParameter(dbCmd, "IncomeID", DbType.Int32, IncomeID);
                            DBH.ExecuteNonQuery(sqlDb, dbCmd);
                        }
                        #endregion Salary Type wise Record Delete


                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ACC_Income_Delete";
                        objCmd.Parameters.AddWithValue("@IncomeID", IncomeID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;

                    }
                    catch (SqlException sqlEx)
                    {
                        Message = sqlEx.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
            }
        }

        #endregion Delete Operation

        #region Select Operation

        #region Dashboard Count

        public DataTable SelectDashboardCount()
        {
            try
            {
                #region Prepare Command

                SqlDatabase sqlDb = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDb.GetStoredProcCommand("PR_DashBoard_CountData");

                #endregion Prepare Command

                #region ReadData and SetControls

                DataTable dt = new DataTable();

                using (IDataReader objSDR = sqlDb.ExecuteReader(dbCMD))
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
        }

        #endregion Dashboard Count

        #region SelectAllData
        public DataTable SelectAllData(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_ACC_Income_SelectView_SV";
                        objCmd.Parameters.AddWithValue("UserID", 4);
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
        #endregion SelectAllData

        #region SelectForDropDownList IncomeType
        public DataTable SelectAll()
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
                        objCmd.CommandText = "PR_MST_IncomeType_SelectComboBox";
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
        #endregion SelectForDropDownList IncomeType

        #region SelectForDropDownList Hospital

        public DataTable SelectAllHospital()
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
                        objCmd.CommandText = "PR_MST_Hospital_SelectComboBox";
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

        #endregion SelectForDropDownList Hospital

        #region SelectForDropDownList FinYear

        public DataTable SelectAllFinYear()
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
                        objCmd.CommandText = "PR_MST_FinYear_SelectComboBox";
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

        #endregion SelectForDropDownList FinYear

        #region SelectByPK

        public IncomeType SelectByPK(SqlInt32 IncomeID)
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
                        objCmd.CommandText = "PR_ACC_Income_SelectPK";
                        objCmd.Parameters.AddWithValue("@IncomeID", IncomeID);
                        #endregion Prepare Command

                        #region ReadData and SetControls
                        IncomeType entIncomeType = new IncomeType();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["IncomeID"].Equals(DBNull.Value))
                                    entIncomeType.IncomeID = Convert.ToInt32(objSDR["IncomeID"]);

                                if (!objSDR["IncomeTypeID"].Equals(DBNull.Value))
                                    entIncomeType.IncomeTypeID = Convert.ToInt32(objSDR["IncomeTypeID"]);

                                if (!objSDR["Amount"].Equals(DBNull.Value))
                                    entIncomeType.Amount = Convert.ToDecimal(objSDR["Amount"]);

                                if (!objSDR["IncomeDate"].Equals(DBNull.Value))
                                    entIncomeType.IncomeDate = Convert.ToDateTime(objSDR["IncomeDate"]);

                                if (!objSDR["Note"].Equals(DBNull.Value))
                                    entIncomeType.Note = Convert.ToString(objSDR["Note"]);

                                if (!objSDR["HospitalID"].Equals(DBNull.Value))
                                    entIncomeType.HospitalID = Convert.ToInt32(objSDR["HospitalID"]);

                                if (!objSDR["FinYearID"].Equals(DBNull.Value))
                                    entIncomeType.FinYearID = Convert.ToInt32(objSDR["FinYearID"]);

                                if (!objSDR["Remarks"].Equals(DBNull.Value))
                                    entIncomeType.Remarks = Convert.ToString(objSDR["Remarks"]);

                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entIncomeType.UserID = Convert.ToInt32(objSDR["UserID"]);

                                if (!objSDR["Modified"].Equals(DBNull.Value))
                                    entIncomeType.Modified = Convert.ToDateTime(objSDR["Modified"]);

                                break;
                            }
                        }

                        int i = 0;
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                entIncomeType.cblSalary.Add(i);
                                if (!objSDR["SalaryTypeIncomeID"].Equals(DBNull.Value))
                                {
                                    entIncomeType.cblSalary[i] = Convert.ToInt32(objSDR["SalaryTypeIncomeID"].ToString());
                                    i++;
                                }
                            }
                        }
                        return entIncomeType;
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

        #endregion SelectByPK

        #region SelectAllData for View
        public DataTable SelectAllDataForView(SqlInt32 IncomeID)
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
                        objCmd.CommandText = "PR_ACC_Income_SelectView";
                        objCmd.Parameters.AddWithValue("IncomeID", IncomeID);
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


        #region SelectAllDashBoardRP
        public DataTable SelectAllDashBoardRP(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_ACC_Income_SelectTop10_SV";
                        objCmd.Parameters.AddWithValue("@UserID", UserID );
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
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;

                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
            }
        }
        #endregion SelectAllDashBoardRP

        #region Fin Year

        public DataTable SelectFinYear(SqlString date)
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
                        objCmd.CommandText = "PR_FinYear_GetCurrentFinYear_SV";
                        objCmd.Parameters.AddWithValue("Date", date);
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
                        Message = ex.Message;
                        return null;

                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
            }
        }

        #endregion Fin Year

        #region Search

        public DataTable Search(IncomeType entIncomeType)
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
                        objCmd.CommandText = "PR_Income_Search_SV";
                        objCmd.Parameters.AddWithValue("FinYearID", entIncomeType.FinYearID);
                        objCmd.Parameters.AddWithValue("HospitalID", entIncomeType.HospitalID);
                        objCmd.Parameters.AddWithValue("IncomeTypeID", entIncomeType.IncomeTypeID);
                        objCmd.Parameters.AddWithValue("Amount", entIncomeType.Amount);
                        objCmd.Parameters.AddWithValue("Remarks", entIncomeType.Remarks);
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

        #endregion Search

        #region FillDDLByHospitalID

        public DataTable FillDDLByHospitalID(SqlInt32 HospitalID)
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
                        objCmd.CommandText = "PR_IncomeType_FillDDLByHospitalID_SV";
                        objCmd.Parameters.AddWithValue("@HospitalID", HospitalID);
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

        #endregion FillDDLByHospitalID

        #endregion Select Operation

        #region FillCheckboxList
        public DataTable FillCheckboxList()
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
                        objCmd.CommandText = "PR_SalaryIncomeType_FillCombobox_SV";
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

        #region SelectAllDashBoardExpense
        public DataTable SelectAllDashBoardExpense(Int32 UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDb.GetStoredProcCommand("PR_Expense_SelectAllDashBoard_SV");
                sqlDb.AddInParameter(dbCMD, "UserID", DbType.Int32, UserID);

                DataTable dt = new DataTable();
                using (IDataReader objSDR = sqlDb.ExecuteReader(dbCMD))
                {
                    dt.Load(objSDR);
                }

                return dt;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion SelectAllDashBoardExpense

        #region SelectAllDashBoardrpExpenseType

        public DataTable SelectAllDashBoardrpExpenseType(Int32 UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDb.GetStoredProcCommand("PR_MST_ExpenseType_SelectAllDashboard_SV");

                sqlDb.AddInParameter(dbCMD, "UserID", DbType.Int32, UserID);
                DataTable dt = new DataTable();

                using (IDataReader objSDR = sqlDb.ExecuteReader(dbCMD))
                {
                    dt.Load(objSDR);
                }

                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion SelectAllDashBoardrpExpenseType

    }
}