<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_Employee_EmployeeAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" Runat="Server">
        <asp:Label ID="lblPageHeader_XXXXX" Text="Employee" runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
<span class="pull-right">
	<small>
		<asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
	</small>
</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
	<!--Help Text-->
<ucHelp:ShowHelp ID="ucHelp" runat="server" />
<!--Help Text End-->
<asp:ScriptManager ID="sm" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="upMST_Employee" runat="server" EnableViewState="true" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
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
                        <asp:Label ID="lblFormHeader" runat="server" Text="Employee Insert"></asp:Label>
                    </span>
                </div>
            </div>

            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <asp:Label ID="lblExpenseType_XXXXX" runat="server" Text="Employee Name"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmployeeName" CssClass="form-control" runat="server" PlaceHolder="Enter Employee Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvExpenseType" SetFocusOnError="True" Display="Dynamic"
                                    runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Enter New Employee Name"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <asp:Label ID="Label1" runat="server" Text="Employee Code"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmployeeCode" CssClass="form-control" runat="server" PlaceHolder="Enter Employee Code"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" Display="Dynamic"
                                    runat="server" ControlToValidate="txtEmployeeCode" ErrorMessage="Enter New Employee Code"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <asp:Label ID="lblDepartmentID_XXXXX" runat="server" Text="Department"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlDepartmentName" CssClass="form-control select2me" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlDepartmentName"  runat="server"
                                    Display="Dynamic" ControlToValidate="ddlDepartmentName" ErrorMessage="Select Department"
                                    InitialValue="-99"></asp:RequiredFieldValidator>
                              <%--  <asp:HiddenField ID="DepartmentID" runat="server" Value="<%# DepartmentID %>" />--%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <asp:Label ID="Label2" runat="server" Text="Salary"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtSalary" CssClass="form-control" runat="server" PlaceHolder="Enter Employee Code"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSalary" SetFocusOnError="True" Display="Dynamic"
                                    ValidationExpression="^[0-9]{10}$"
                                    runat="server" ControlToValidate="txtSalary" ErrorMessage="Enter Salary"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <asp:Label ID="Label3" runat="server" Text="Joining Date"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>

                                    <asp:TextBox ID="dtpJoiningDate" CssClass="form-control" runat="server" placeholder="Joining Date"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dtpJoiningDate"
                                    ErrorMessage="Enter Joining Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine"
                                    PlaceHolder="Enter Remarks"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">&nbsp;&nbsp;</span>
                                <asp:Label ID="lblHobby" runat="server" Text="Hobbies :"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:CheckBoxList ID="cblHobby" runat="server" RepeatDirection="vertical">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                    <div class="form-actions">
                        <div class="row">
                            <div class="col-md-offset-3 col-md-6">
                                <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                      
                                <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_Employee/EmployeeList.aspx"></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

