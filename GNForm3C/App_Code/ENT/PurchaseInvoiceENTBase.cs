using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseInvoiceENTBase
/// </summary>
public abstract class PurchaseInvoiceENTBase 
{
    #region Properties
    protected SqlInt32 _PurchaseInvoiceID;
    public SqlInt32 PurchaseInvoiceID
    {
        get
        {
            return _PurchaseInvoiceID;
        }
        set
        {
            _PurchaseInvoiceID = value;
        }
    }

    protected SqlDecimal _TotalAmountValue;
    public SqlDecimal TotalAmountValue
    {
        get
        {
            return _TotalAmountValue;
        }
        set
        {
            _TotalAmountValue = value;
        }
    }

    protected SqlDateTime _Date;
    public SqlDateTime Date
    {
        get
        {
            return _Date;
        }
        set
        {
            _Date = value;
        }
    }

    protected SqlDateTime _PODate;
    public SqlDateTime PODate
    {
        get
        {
            return _PODate;
        }
        set
        {
            _PODate = value;
        }
    }

    protected SqlDateTime _ReceivedDate;
    public SqlDateTime ReceivedDate
    {
        get
        {
            return _ReceivedDate;
        }
        set
        {
            _ReceivedDate = value;
        }
    }

    protected SqlString _InvoiceNo;
    public SqlString InvoiceNo
    {
        get
        {
            return _InvoiceNo;
        }
        set
        {
            _InvoiceNo = value;
        }
    }
    protected SqlString _BillNo;
    public SqlString BillNo
    {
        get
        {
            return _BillNo;
        }
        set
        {
            _BillNo = value;
        }
    }

    protected SqlString _ToAddress;
    public SqlString ToAddress
    {
        get
        {
            return _ToAddress;
        }
        set
        {
            _ToAddress = value;
        }
    }

  
    protected SqlString _PONo;
    public SqlString PONo
    {
        get
        {
            return _PONo;
        }
        set
        {
            _PONo = value;
        }
    }
    protected SqlString _ToGSTIN;
    public SqlString ToGSTIN
    {
        get
        {
            return _ToGSTIN;
        }
        set
        {
            _ToGSTIN = value;
        }
    }
    protected SqlString _IncomeTaxPan;
    public SqlString IncomeTaxPan
    {
        get
        {
            return _IncomeTaxPan;
        }
        set
        {
            _IncomeTaxPan = value;
        }
    }
    protected SqlString _GSTNo;
    public SqlString GSTNo
    {
        get
        {
            return _GSTNo;
        }
        set
        {
            _GSTNo = value;
        }
    }

    protected SqlString _BankAccountNumber;
    public SqlString BankAccountNumber
    {
        get
        {
            return _BankAccountNumber;
        }
        set
        {
            _BankAccountNumber = value;
        }
    }

    protected SqlString _BankName;
    public SqlString BankName
    {
        get
        {
            return _BankName;
        }
        set
        {
            _BankName = value;
        }
    }

    protected SqlString _BankIFSC;
    public SqlString BankIFSC
    {
        get
        {
            return _BankIFSC;
        }
        set
        {
            _BankIFSC = value;
        }
    }

    protected SqlString _CategoryOfService;
    public SqlString CategoryOfService
    {
        get
        {
            return _CategoryOfService;
        }
        set
        {
            _CategoryOfService = value;
        }
    }

    protected SqlDecimal _CGSTPPercentage;
    public SqlDecimal CGSTPPercentage
    {
        get
        {
            return _CGSTPPercentage;
        }
        set
        {
            _CGSTPPercentage = value;
        }
    }

    protected SqlDecimal _CGSTAmount;
    public SqlDecimal CGSTAmount
    {
        get
        {
            return _CGSTAmount;
        }
        set
        {
            _CGSTAmount = value;
        }
    }

    protected SqlDecimal _SGSTPercentage;
    public SqlDecimal SGSTPercentage
    {
        get
        {
            return _SGSTPercentage;
        }
        set
        {
            _SGSTPercentage = value;
        }
    }

    protected SqlDecimal _SGSTAmount;
    public SqlDecimal SGSTAmount
    {
        get
        {
            return _SGSTAmount;
        }
        set
        {
            _SGSTAmount = value;
        }
    }

    protected SqlDecimal _TotalAssetValue;
    public SqlDecimal TotalAssetValue
    {
        get
        {
            return _TotalAssetValue;
        }
        set
        {
            _TotalAssetValue = value;
        }
    }

    protected SqlDecimal _DiscountPercentage;
    public SqlDecimal DiscountPercentage
    {
        get
        {
            return _DiscountPercentage;
        }
        set
        {
            _DiscountPercentage = value;
        }
    }

    protected SqlDecimal _DiscountAmount;
    public SqlDecimal DiscountAmount
    {
        get
        {
            return _DiscountAmount;
        }
        set
        {
            _DiscountAmount = value;
        }
    }

    protected SqlDecimal _NetPayableValue;
    public SqlDecimal NetPayableValue
    {
        get
        {
            return _NetPayableValue;
        }
        set
        {
            _NetPayableValue = value;
        }
    }

    protected SqlDecimal _ReceivedAmount;
    public SqlDecimal ReceivedAmount
    {
        get
        {
            return _ReceivedAmount;
        }
        set
        {
            _ReceivedAmount = value;
        }
    }
    #endregion Properties

    #region Constructor

    public PurchaseInvoiceENTBase()
    {

    }

    #endregion Constructor

  
}
