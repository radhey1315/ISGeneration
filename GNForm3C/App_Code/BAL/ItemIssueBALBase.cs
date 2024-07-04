using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemIssueBALBase
/// </summary>
public class ItemIssueBALBase
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

    public ItemIssueBALBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Boolean Insert(ItemIssueENT entItemIssue)
    {
        ItemIssueDAL dalIssue = new ItemIssueDAL();
        return dalIssue.Insert(entItemIssue);
    }
}