<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_ExpenseTypeAddMany.aspx.cs" Inherits="AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddMany"
    Title="Add Many Expense Type" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Expense Type " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
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
        <asp:HyperLink ID="hlExpenseType" runat="server" NavigateUrl="~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeList.aspx" Text="Expense Type List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Expense Type Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMST_ExpenseType" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />

        </Triggers>
        <ContentTemplate>
            <asp:UpdatePanel ID="upMST_ExpenseType1" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

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
                                        <label class="col-md-3 control-label">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                            <asp:HyperLink ID="HyperLink1" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeList.aspx"></asp:HyperLink>
                                        </div>
                                    </div>
                                   </div>

                            </div>
                        </div>
                    </label>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="upApplicationFeature" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />

                </Triggers>
                <ContentTemplate>
                    <div class="portlet light" runat="server" id="Div_ShowResult" visible="false">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse pull-right"></a>
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="TableContent">
                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                            <%-- Table Header --%>
                                            <thead>
                                                <tr class="TRDark">
                                                    <th class="text-center" style="width:30px">
                                                        <asp:Label ID="lblIsSelected" runat="server" Text="IsSelected?"></asp:Label>
                                                    </th>
                                                
                                                     <th class="text-center">
                                                        <asp:Label ID="lblSrNo" runat="server" Text="Sr."></asp:Label>
                                                    </th>
                                                    
                                                    <th>
                                                        <asp:Label ID="lbhExpenseType" runat="server" Text="Expense Type"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
                                                    </th>
                                                   </tr>
                                            </thead>
                                            <%-- END Table Header --%>

                                            <tbody>
                                                <asp:Repeater ID="rpData" runat="server">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr class="odd gradeX">
                                                            <td class="text-center">
                                                                <asp:checkbox ID="chkIsSelected" runat="server" />
                                                            </td>
                                                            <td class="text-center">
                                                                <asp:Label ID="lblSrNo" runat="server"></asp:Label>
                                                            </td>
                                                            
                                                            <td>
                                                                <asp:TextBox ID="txtExpenseType" CssClass="form-control" runat="server" PlaceHolder="Enter Expense Type"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvExpenseType" ControlToValidate="#" SetFocusOnError="True" Display="Dynamic" runat="server" ErrorMessage="Enter Expense Type"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" PlaceHolder="Enter Remarks"></asp:TextBox>
                                                            </td>
                                                            <asp:HiddenField ID="hfExpenseTypeID" runat="server" />
                                                            
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <%--<asp:Repeater ID="rpBlank" runat="server">
                                                    <ItemTemplate>
                                                       
                                                        <tr class="odd gradeX">
                                                            <td class="text-center">
                                                                <asp:Label ID="lblSrNo" runat="server" ></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtExpenseTypeBlank" CssClass="form-control" runat="server" PlaceHolder="Enter Expense Type"></asp:TextBox>
                                                                
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarksBlank" CssClass="form-control" runat="server" PlaceHolder="Enter Remarks"></asp:TextBox>
                                                            </td>
                                                            
                                                        </tr>
                                                       
                                                    </ItemTemplate>
                                                </asp:Repeater>--%>
                                            </tbody>
                                        </table>
                                    </div>

                                </div>
                            </div>


                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-9">
                                        <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                        <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeList.aspx"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>




                </ContentTemplate>
            </asp:UpdatePanel>

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

