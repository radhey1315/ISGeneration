using GNForm3c.BAL;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
public class CommonFillMethodsSmit
{
	public CommonFillMethodsSmit()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void FillDropDownIncomeType(DropDownList ddlIncomeTypeID)
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        ddlIncomeTypeID.DataSource = balIncomeType.SelectForIncomeTypeIDDDL();
        ddlIncomeTypeID.DataValueField = "IncomeTypeID";
        ddlIncomeTypeID.DataTextField = "IncomeType";
        ddlIncomeTypeID.DataBind();
        ddlIncomeTypeID.Items.Insert(0, new ListItem("Select Income Type", "-99"));
    }

    public static void FillDropDownHospital(DropDownList ddlHospitalName)
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        ddlHospitalName.DataSource = balIncomeType.SelectForHospitalDDL();
        ddlHospitalName.DataValueField = "HospitalID";
        ddlHospitalName.DataTextField = "Hospital";
        ddlHospitalName.DataBind();
        ddlHospitalName.Items.Insert(0, new ListItem("Select Hospital", "-99"));
    }

    public static void FillDropDownFinYear(SqlString CDate, DropDownList ddlFinYear)
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        ddlFinYear.DataSource = balIncomeType.SelectddlFinYear(CDate);
        ddlFinYear.DataValueField = "FinYearID";
        ddlFinYear.DataTextField = "FinYearName";
        ddlFinYear.DataBind();
    }

    public static void FillDropDownFinYear(DropDownList ddlFinYear)
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        ddlFinYear.DataSource = balIncomeType.SelectForFinYearDDL();
        ddlFinYear.DataValueField = "FinYearID";
        ddlFinYear.DataTextField = "FinYearName";
        ddlFinYear.DataBind();
        ddlFinYear.Items.Insert(0, new ListItem("Select Year", "-99"));
    }



    public static void FillDropDownIncomeTypeByHospital(DropDownList ddlIncomeTypeID, SqlInt32 HospitalID)
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        ddlIncomeTypeID.DataSource = balIncomeType.DropDownListSelectByHospitalID(HospitalID);
        ddlIncomeTypeID.DataValueField = "IncomeTypeID";
        ddlIncomeTypeID.DataTextField = "IncomeType";
        ddlIncomeTypeID.DataBind();
        ddlIncomeTypeID.Items.Insert(0, new ListItem("Select Income Type", "-1"));
    }

    public static void FillCheckboxList(CheckBoxList cblSalary)
    {
        IncomeTypeBAL balIncomeType = new IncomeTypeBAL();
        cblSalary.DataSource = balIncomeType.FillCheckboxList();
        cblSalary.DataValueField = "SalaryIncomeTypeID";
        cblSalary.DataTextField = "SalaryIncomeTypeName";
        cblSalary.DataBind();
    }
    public static void FillCheckboxListHobby(CheckBoxList cblHobby)
    {
        MST_EmployeeBALBase balEmployee = new MST_EmployeeBALBase();
        cblHobby.DataSource = balEmployee.FillCheckboxListHobby();
        cblHobby.DataValueField = "HobbyID";
        cblHobby.DataTextField = "HobbyName";
        cblHobby.DataBind();
    }

    public static void FillDropDownList(DropDownList ddlCountryName)
    {
        MST_StateBALBase balIncomeType = new MST_StateBALBase();
        ddlCountryName.DataSource = balIncomeType.SelectForCountryDDL();
        ddlCountryName.DataValueField = "CountryID";
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, new ListItem("Select Country", "-99"));
    }
}