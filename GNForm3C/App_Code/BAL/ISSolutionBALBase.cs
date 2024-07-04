using GNForm3C.DAL;
using GnForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using System.Data;
using GNForm3C.ENT;

/// <summary>
/// Summary description for ISSolutionBALBase
/// </summary>
public class ISSolutionBALBase
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

    public ISSolutionBALBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #endregion Constructor

   
    #region Insert
    public Boolean Insert(PurchaseInvoiceENT entPurchaseInvoice)
    {
        ISSolutionDAL dalPurchase = new ISSolutionDAL();
        return dalPurchase.Insert(entPurchaseInvoice);
    }
    public Boolean Update(PurchaseInvoiceENT entPurchaseInvoice)
    {
        ISSolutionDAL dalPurchase = new ISSolutionDAL();
        return dalPurchase.Update(entPurchaseInvoice);
    }


    #endregion Insert


    #region Select Operation


    #region SelectByPk
    public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString InvoiceNo, SqlString PONo,SqlDateTime Date, SqlDateTime PODate)
    {
        ISSolutionDAL dalISSolution = new ISSolutionDAL();
        return dalISSolution.SelectPage(PageOffset, PageSize, out TotalRecords, InvoiceNo, PONo, Date, PODate);
    }

    public PurchaseInvoiceENT SelectPK(SqlInt32 PurchaseInvoiceID)
    {
        ISSolutionDAL dalISSolution = new ISSolutionDAL();
        return dalISSolution.SelectPK(PurchaseInvoiceID);
    }
    #endregion SelectByPk

    #endregion Select Operation


    //public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageRecordSize, out Int32 TotalRecords, SqlString CountryName, SqlString CountryCode)
    //{
    //    MST_CountryDALBase dalMST_Country = new MST_CountryDALBase();
    //    return dalMST_Country.SelectPage(PageOffset, PageRecordSize, out TotalRecords, CountryName, CountryCode);
    //}


    //public DataTable SelectView(SqlInt32 CountryID)
    //{
    //    MST_CountryDALBase dalCountry = new MST_CountryDALBase();
    //    return dalCountry.SelectView(CountryID);
    //}

    #region ComboBox

    //public DataTable SelectComboBox()
    //{
    //    MST_CountryDALBase dalMST_Hospital = new MST_CountryDALBase();
    //    return dalMST_Hospital.SelectComboBox();
    //}

    #endregion ComboBox

}