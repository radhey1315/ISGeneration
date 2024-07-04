<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_ExpenseAddEdit.aspx.cs" Inherits="AdminPanel_Account_ACC_Expense_ACC_ExpenseAddEdit"
    Title="Expense AddEdit" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Expense " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Account" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlExpense" runat="server" NavigateUrl="~/AdminPanel/Account/ACC_Expense/ACC_ExpenseList.aspx" Text="Expense List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Expense Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upACC_Expense" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                        <span class="caption-subject font-green-sharp bold uppercase">
                            <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                        </span>
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Shop Name"></asp:Label>
                                </label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2  control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblFinYearID_XXXXX" runat="server" Text="Fin Year"></asp:Label>
                                </label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvFinYearID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYearID" ErrorMessage="Select Fin Year" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblExpenseTypeID_XXXXX" runat="server" Text="Expense Type"></asp:Label>
                                </label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlExpenseTypeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvExpenseTypeID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlExpenseTypeID" ErrorMessage="Select Expense Type" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblAmount_XXXXX" runat="server" Text="Amount"></asp:Label>
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Amount"></asp:TextBox>
                                    <asp:CompareValidator ID="cvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Valid Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="rfvAmount" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Amount"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblExpenseDate_XXXXX" runat="server" Text="Expense Date"></asp:Label>
                                </label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpExpenseDate" CssClass="form-control" runat="server" placeholder="Expense Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvExpenseDate" runat="server" ControlToValidate="dtpExpenseDate" ErrorMessage="Enter Expense Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%--<div class="form-group">
                                
                            </div>--%>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <asp:Label ID="lblNote_XXXXX" runat="server" Text="Note"></asp:Label>
                                </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNote" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="Enter Note"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="Enter Remarks"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-2 col-md-9">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_Expense/ACC_ExpenseList.aspx"></asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text="Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
