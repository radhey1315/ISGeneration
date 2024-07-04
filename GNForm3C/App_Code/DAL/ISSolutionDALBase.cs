using GNForm3C.DAL;
using GnForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using GNForm3C.ENT;

/// <summary>
/// Summary description for ISSolutionDALBase
/// </summary>
public class ISSolutionDALBase : DataBaseConfig
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

    public ISSolutionDALBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #endregion Constructor


    #region Insert Operation
    public Boolean Insert(PurchaseInvoiceENT entPurchaseInvoice)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionStringForISSolution);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Purchase_Invoice_Insert");

            sqlDB.AddOutParameter(dbCMD, "@PurchaseInvoiceID", SqlDbType.Int, 4);
            sqlDB.AddInParameter(dbCMD, "@IncomeTaxPan", SqlDbType.NVarChar, entPurchaseInvoice.IncomeTaxPan);
            sqlDB.AddInParameter(dbCMD, "@InvoiceNo", SqlDbType.NVarChar, entPurchaseInvoice.InvoiceNo);
            sqlDB.AddInParameter(dbCMD, "@BankAccountNumber", SqlDbType.NVarChar, entPurchaseInvoice.BankAccountNumber);
            sqlDB.AddInParameter(dbCMD, "@BankIFSC", SqlDbType.NVarChar, entPurchaseInvoice.BankIFSC);
            sqlDB.AddInParameter(dbCMD, "@PONo", SqlDbType.NVarChar, entPurchaseInvoice.PONo);
            sqlDB.AddInParameter(dbCMD, "@PODate", SqlDbType.DateTime, entPurchaseInvoice.PODate);
            sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, entPurchaseInvoice.Date);
            sqlDB.AddInParameter(dbCMD, "@ToGSTIN", SqlDbType.NVarChar, entPurchaseInvoice.ToGSTIN);
            sqlDB.AddInParameter(dbCMD, "@CategoryOfService", SqlDbType.NVarChar, entPurchaseInvoice.CategoryOfService);
            sqlDB.AddInParameter(dbCMD, "@GSTNo", SqlDbType.NVarChar, entPurchaseInvoice.GSTNo);
            sqlDB.AddInParameter(dbCMD, "@ToAddress", SqlDbType.NVarChar, entPurchaseInvoice.ToAddress);
            sqlDB.AddInParameter(dbCMD, "@BankName", SqlDbType.NVarChar, entPurchaseInvoice.BankName);

            DataBaseHelper DBH = new DataBaseHelper();
            DBH.ExecuteNonQuery(sqlDB, dbCMD);

            entPurchaseInvoice.PurchaseInvoiceID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@PurchaseInvoiceID"].Value);

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


    #endregion Insert Operation

    #region UpdateOperation

    public Boolean Update(PurchaseInvoiceENT entPurchaseInvoice)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionStringForISSolution);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PurchaseInvoice_Update");

            sqlDB.AddInParameter(dbCMD, "@PurchaseInvoiceID", SqlDbType.Int, entPurchaseInvoice.PurchaseInvoiceID);
            sqlDB.AddInParameter(dbCMD, "@IncomeTaxPan", SqlDbType.NVarChar, entPurchaseInvoice.IncomeTaxPan);
            sqlDB.AddInParameter(dbCMD, "@PODate", SqlDbType.DateTime, entPurchaseInvoice.PODate);
            sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, entPurchaseInvoice.Date);
            sqlDB.AddInParameter(dbCMD, "@BankAccountNumber", SqlDbType.NVarChar, entPurchaseInvoice.BankAccountNumber);
            sqlDB.AddInParameter(dbCMD, "@InvoiceNo", SqlDbType.NVarChar, entPurchaseInvoice.InvoiceNo);
            sqlDB.AddInParameter(dbCMD, "@BankIFSC", SqlDbType.NVarChar, entPurchaseInvoice.BankIFSC);
            sqlDB.AddInParameter(dbCMD, "@BankName", SqlDbType.NVarChar, entPurchaseInvoice.BankName);
            sqlDB.AddInParameter(dbCMD, "@ToAddress", SqlDbType.NVarChar, entPurchaseInvoice.ToAddress);
            sqlDB.AddInParameter(dbCMD, "@GSTNo", SqlDbType.NVarChar, entPurchaseInvoice.GSTNo);
            sqlDB.AddInParameter(dbCMD, "@CategoryOfService", SqlDbType.NVarChar, entPurchaseInvoice.CategoryOfService);
            sqlDB.AddInParameter(dbCMD, "@ToGstIN", SqlDbType.NVarChar, entPurchaseInvoice.ToGSTIN);
            sqlDB.AddInParameter(dbCMD, "@PONo", SqlDbType.NVarChar, entPurchaseInvoice.PONo);

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


    public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString InvoiceNo, SqlString PONo, SqlDateTime Date, SqlDateTime PODate)
    {
        TotalRecords = 0;
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionStringForISSolution);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ISSolution_SelectPage");
            sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
            sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
            sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
            sqlDB.AddInParameter(dbCMD, "@InvoiceNo", SqlDbType.NVarChar, InvoiceNo);
            sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, Date);
            sqlDB.AddInParameter(dbCMD, "@PONo", SqlDbType.NVarChar, PONo);
            sqlDB.AddInParameter(dbCMD, "@PODate", SqlDbType.DateTime, PODate);

            DataTable dtPurchaseInvoice = new DataTable("PR_ISSolution_SelectPage");

            DataBaseHelper DBH = new DataBaseHelper();
            DBH.LoadDataTable(sqlDB, dbCMD, dtPurchaseInvoice);

            TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

            return dtPurchaseInvoice;
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

    public PurchaseInvoiceENT SelectPK(SqlInt32 PurchaseInvoiceID)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionStringForISSolution);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PurchaseInvoice_SelectPK");

            sqlDB.AddInParameter(dbCMD, "@PurchaseInvoiceID", SqlDbType.Int, PurchaseInvoiceID  );

            PurchaseInvoiceENT entISSolution = new PurchaseInvoiceENT();
            DataBaseHelper DBH = new DataBaseHelper();
            using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
            {
                while (dr.Read())
                {
                    if (!dr["PurchaseInvoiceID"].Equals(System.DBNull.Value))
                        entISSolution.PurchaseInvoiceID = Convert.ToInt32(dr["PurchaseInvoiceID"]);

                    if (!dr["IncomeTaxPan"].Equals(System.DBNull.Value))
                        entISSolution.IncomeTaxPan = Convert.ToString(dr["IncomeTaxPan"]);

                    if (!dr["InvoiceNo"].Equals(System.DBNull.Value))
                        entISSolution.InvoiceNo = Convert.ToString(dr["InvoiceNo"]);

                    if (!dr["BankAccountNumber"].Equals(System.DBNull.Value))
                        entISSolution.BankAccountNumber = Convert.ToString(dr["BankAccountNumber"]);

                    if (!dr["BankIFSC"].Equals(System.DBNull.Value))
                        entISSolution.BankIFSC = Convert.ToString(dr["BankIFSC"]);

                     if (!dr["BankName"].Equals(System.DBNull.Value))
                        entISSolution.BankName = Convert.ToString(dr["BankName"]);

                    if (!dr["ToAddress"].Equals(System.DBNull.Value))
                        entISSolution.ToAddress = Convert.ToString(dr["ToAddress"]);

                    if (!dr["GSTNo"].Equals(System.DBNull.Value))
                        entISSolution.GSTNo = Convert.ToString(dr["GSTNo"]);

                    if (!dr["CategoryOfService"].Equals(System.DBNull.Value))
                        entISSolution.CategoryOfService = Convert.ToString(dr["CategoryOfService"]);

                    if (!dr["ToGstIN"].Equals(System.DBNull.Value))
                        entISSolution.ToGSTIN = Convert.ToString(dr["ToGstIN"]);

                    if (!dr["PONo"].Equals(System.DBNull.Value))
                        entISSolution.PONo = Convert.ToString(dr["PONo"]);

                    if (!dr["Date"].Equals(System.DBNull.Value))
                        entISSolution.Date = Convert.ToDateTime(dr["Date"]);

                    if (!dr["PODate"].Equals(System.DBNull.Value))
                        entISSolution.PODate = Convert.ToDateTime(dr["PODate"]);

                }
            }
            return entISSolution;
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

}