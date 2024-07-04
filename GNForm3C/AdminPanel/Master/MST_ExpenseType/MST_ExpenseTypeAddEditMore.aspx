<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_ExpenseTypeAddEditMore.aspx.cs" Inherits="AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddEditMore" %>

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

    <asp:UpdatePanel ID="upMST_ExpenseType1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">

        <ContentTemplate>

            <asp:UpdatePanel ID="upApplicationFeature" runat="server" UpdateMode="Always">

                <ContentTemplate>
                    <div class="portlet light">
                        <div class="row">
                            <div class="col-md-12">
                                <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                                <ucMessage:ShowMessage ID="ucMessage1" runat="server" />

                                <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                            </div>
                        </div>


                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                                <span class="caption-subject font-green-sharp bold uppercase">
                                    <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                                </span>
                            </div>
                        </div>

                        <div class="portlet-body form">
                            <div role="form">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label class=" control-label">
                                                <span class="required">*</span>
                                                <asp:Label ID="lblExpenseType_XXXXX" runat="server" Text="Expense Type"></asp:Label>
                                            </label>
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">
                                                <span class="required">*</span>
                                                <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                            </label>
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">
                                                <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-plus"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtExpenseType" CssClass="form-control" runat="server" PlaceHolder="Enter Expense Type"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-plus"></i>
                                                    </span>
                                                    <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-plus"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" PlaceHolder="Enter Remarks"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:LinkButton ID="btnAddMore" runat="server" SkinID="lbtnAdd" OnClick="btnAddMore_Click"></asp:LinkButton>
                                                <asp:LinkButton ID="btnUpdate" runat="server" SkinID="lbtnUpdate" Visible="false" OnClick="btnUpdate_Click"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="form-actions">
                                    </div>


                                </div>

                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>


            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                <ContentTemplate>

                    <div class="portlet light" runat="server" id="Div_ShowResult" visible="false">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchHeader" SkinID="lblAddExpenseTypeText" runat="server"></asp:Label>
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
                                                    <th class="text-center">
                                                        <asp:Label ID="lblSrNo" runat="server" Text="Sr."></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lblExpenseType" runat="server" Text="Expense Type"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lblHospital" runat="server" Text="Hospital"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <%-- END Table Header --%>

                                            <tbody>
                                                <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr class="odd gradeX">
                                                            <td class="text-center">
                                                                <%#Container.ItemIndex+1 %>
                                                            </td>

                                                            <td class="text-center">
                                                                <asp:Label ID="lblExpenseType" runat="server" Text='<%#Eval("ExpenseType") %>'></asp:Label>
                                                            </td>

                                                            <td class="text-center">
                                                                <asp:Label ID="lblHospital" runat="server" Text='<%#Eval("Hospital") %>'></asp:Label>
                                                                <asp:HiddenField ID="hfHospitalID" runat="server" Value='<%#Eval("HospitalID") %>' />
                                                            </td>

                                                            <td class="text-center">
                                                                <asp:Label ID="lbhRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                            </td>
                                                            <asp:HiddenField ID="hfExpenseTypeID" runat="server" />
                                                            <td class="text-nowrap text-center">
                                                                <asp:LinkButton ID="lbtnEdit" runat="server"
                                                                    SkinID="lbtnEdit"
                                                                    CommandName="EditRecord"
                                                                    CommandArgument=' <%#Container.ItemIndex %>'>
                                                                </asp:LinkButton>
                                                                <%--<asp:Button SkinTD="AddMoreEdit" ID="btnEdit" runat="server" Text="Edit" CommandName="EditRecord" />--%>
                                                                <%--<asp:HyperLink ID="hlEdit" SkinID="Edit" NavigateUrl='<%# "~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeAddEdit.aspx?ExpenseType=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("ExpenseType").ToString()) %>' runat="server"></asp:HyperLink>--%>
                                                                <asp:LinkButton ID="lbtnDelete" runat="server"
                                                                    SkinID="Delete"
                                                                    OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"
                                                                    CommandName="DeleteRecord"
                                                                    CommandArgument=' <%#Container.ItemIndex %>'>
                                                                </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>

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

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddMore" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />

        </Triggers>
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


