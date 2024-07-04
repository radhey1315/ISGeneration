<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="IncomeAddEdit.aspx.cs" Inherits="AdminPanel_Smit_AddIncome_IncomeAddEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Smit Income"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Master"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="ExpenseType"></asp:Label>
    </li>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->

    <asp:Label runat="server" ID="lblMess" Visible="false">
        <div class="portlet light">
            <div class="caption">
                <asp:Label ID="lblMessage" runat="server" Visible="true" EnableViewState="False"></asp:Label>
            </div>
        </div>
    </asp:Label>

    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
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
                    <asp:Label ID="lblFormHeader" runat="server" Text="Add Income"></asp:Label>
                </span>
            </div>
        </div>

        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <div class="form-body">
                    <div class="form-group">

                        <div class="col-md-6">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto; margin-right: 28px">
                                <span class="required">*</span>
                                <asp:Label ID="lblFinYear" runat="server" Text="Fin. Year"></asp:Label>
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlFinYear" CssClass="form-control select2me" runat="server" Enabled="False"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYear" ErrorMessage="Select Financial Year" InitialValue="-99"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto">
                                <span class="required">*</span>
                                <asp:Label ID="lblHospitalID" runat="server" Text="Hospital Name"></asp:Label>
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlHospitalName" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalName" ErrorMessage="Select Hospital Name" InitialValue="-99"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="col-md-6" style="margin-top: 15px">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto;">
                                <span class="required">*</span>
                                <asp:Label ID="lblIncomeTypeName" runat="server" Text="Income Type"></asp:Label>
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlIncomeTypeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlIncomeTypeID" ErrorMessage="Select Income Type" InitialValue="-99"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="col-md-6" style="margin-top: 15px">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto; margin-right: 15px">
                                <span class="required">*</span>
                                <asp:Label ID="lblIncomeDate" runat="server" Text="Income Date"></asp:Label>
                            </label>
                            <div class="col-md-9">
                                <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                    <asp:TextBox ID="dtpIncomeDate" CssClass="form-control" runat="server" placeholder="Income Date"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator ID="rfvIncomeDate" runat="server" ControlToValidate="dtpIncomeDate" ErrorMessage="Enter Income Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="col-md-6" style="margin-top: 15px">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto; margin-right: 30px">
                                <span class="required">*</span>
                                <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" placeholder="Enter Amount"></asp:TextBox>
                                <asp:CompareValidator ID="cvAmount" runat="server" ErrorMessage="Numbers Only" Operator="DataTypeCheck" ControlToValidate="txtAmount" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Amount" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="col-md-6" style="margin-top: 15px">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto; margin-right: 65px">
                                <span class="required">&nbsp;&nbsp;</span>
                                <asp:Label ID="lblNote" runat="server" Text="Note"></asp:Label>
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtNote" CssClass="form-control" runat="server" placeholder="Note"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6" style="margin-top: 15px">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto; margin-right: 33px">
                                <span class="required">&nbsp;&nbsp;</span>
                                <asp:Label ID="lblRemark" runat="server" Text="Remark"></asp:Label>
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" Placeholder="Enter Remarks" Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6" style="margin-top: 15px">
                            <label class="col-md-2 control-label" style="text-align: left; width: auto; margin-right: 23px">
                                <span class="required">&nbsp;&nbsp;</span>
                                <asp:Label ID="Label1" runat="server" Text="Salary Deduct"></asp:Label>
                            </label>
                                <asp:CheckBoxList ID="cblSalary" runat="server"  RepeatDirection="vertical" >
                                </asp:CheckBoxList>
                        </div>

                    </div>

                </div>

                <div class="form-actions">
                    <div class="row">
                        <div class="col-md-offset-1 col-md-9" style="margin-left: 14rem">
                            <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                            <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/smit/AddIncome/IncomeList.aspx"></asp:HyperLink>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

