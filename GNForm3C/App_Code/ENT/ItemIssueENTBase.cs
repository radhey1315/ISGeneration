using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseInvoiceENTBase
/// </summary>
public class ItemIssueENTBase
{
    #region Properties

    protected SqlInt32 _ItemIssueID;
    public SqlInt32 ItemIssueID
    {
        get
        {
            return _ItemIssueID;
        }
        set
        {
            _ItemIssueID = value;
        }
    }

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

    protected SqlDecimal _Price;
    public SqlDecimal Price
    {
        get
        {
            return _Price;
        }
        set
        {
            _Price = value;
        }
    }
    protected SqlString _ItemName;
    public SqlString ItemName
    {
        get
        {
            return _ItemName;
        }
        set
        {
            _ItemName = value;
        }
    }

    protected SqlString _ItemNo;
    public SqlString ItemNo
    {
        get
        {
            return _ItemNo;
        }
        set
        {
            _ItemNo = value;
        }
    }

    protected SqlString _Unit;
    public SqlString Unit
    {
        get
        {
            return _Unit;
        }
        set
        {
            _Unit = value;
        }
    }


    protected SqlInt32 _Quntity;
    public SqlInt32 Quntity
    {
        get
        {
            return _Quntity;
        }
        set
        {
            _Quntity = value;
        }
    }
    #endregion Properties

    #region Constructor

    public ItemIssueENTBase()
    {

    }

    #endregion Constructor


}
