using GNForm3C.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ItemIssueDALBase
/// </summary>
public class ItemIssueDALBase : DataBaseConfig
{


    public ItemIssueDALBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Insert Operation
    public Boolean Insert(ItemIssueENT entItemIssue)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionStringForISSolution);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Item_Issues_Insert");

            sqlDB.AddOutParameter(dbCMD,"@ItemIssueID", SqlDbType.Int, 4);
            sqlDB.AddInParameter(dbCMD, "@PurchaseInvoiceID", SqlDbType.Int, entItemIssue.PurchaseInvoiceID);
            sqlDB.AddInParameter(dbCMD, "@ItemName", SqlDbType.NVarChar, entItemIssue.ItemName);
            sqlDB.AddInParameter(dbCMD, "@ItemNo", SqlDbType.NVarChar, entItemIssue.ItemNo);
            sqlDB.AddInParameter(dbCMD, "@Quntity", SqlDbType.Int, entItemIssue.Quntity);
            sqlDB.AddInParameter(dbCMD, "@Unit", SqlDbType.NVarChar, entItemIssue.Unit);
            sqlDB.AddInParameter(dbCMD, "@Price", SqlDbType.Decimal, entItemIssue.Price);
            sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entItemIssue.Amount);

            DataBaseHelper DBH = new DataBaseHelper();
            DBH.ExecuteNonQuery(sqlDB, dbCMD);

            entItemIssue.ItemIssueID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ItemIssueID"].Value);

            return true;
        }
        catch (SqlException sqlex)
        {
           // Message = SQLDataExceptionMessage(sqlex);
            if (SQLDataExceptionHandler(sqlex))
                throw;
            return false;
        }
        catch (Exception ex)
        {
           // Message = ExceptionMessage(ex);
            if (ExceptionHandler(ex))
                throw;
            return false;
        }

    }


    #endregion Insert Operation

}