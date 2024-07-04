<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true"
    CodeFile="MST_CountryAddMany.aspx.cs" Inherits="AdminPanel_Master_MST_Country_MST_CountryAddMany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Country " runat="server"></asp:Label><small><asp:Label
        ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx"
            Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlExpenseType" runat="server" NavigateUrl="~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeList.aspx"
            Text="Expense Type List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Expense Type Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMST_ExpenseType" runat="server" EnableViewState="true" UpdateMode="Conditional"
        ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />

        </Triggers>
        <ContentTemplate>

            <asp:UpdatePanel ID="upMST_ExpenseType1" runat="server" EnableViewState="true" UpdateMode="Conditional"
                ChildrenAsTriggers="false">

                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                        </div>
                    </div>

          
                </ContentTemplate>

            </asp:UpdatePanel>

            <asp:UpdatePanel ID="upApplicationFeature123" runat="server">
                <%--   <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />

            </Triggers>--%>
                <ContentTemplate>
                    <div class="portlet light" runat="server" id="Div_ShowResult" visible="false">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                                <%--<asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>--%>
                                <asp:Label ID="lblSearchHeader" Text="Insert multipal country" runat="server"></asp:Label>
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
                                                        <asp:CheckBox onchange="checkAll(this)" runat="server" ID="cbSelectAll" />
                                                    </th>

                                                    <th class="text-center">
                                                        <asp:Label ID="lblSrNo" runat="server" Text="Sr."></asp:Label>
                                                    </th>

                                                    <th>
                                                        <asp:Label ID="lbhCountryName" runat="server" Text="Country Name"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhCountryCode" runat="server" Text="Country Code"></asp:Label>
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
                                                                <asp:CheckBox ID="chkIsSelected" onclick="uckSelectAll(this)" CssClass="checkbox-group"
                                                                    runat="server" />
                                                            </td>

                                                            <td class="text-center">
                                                                <asp:Label ID="lblSrNo" runat="server"></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtCountryName" CssClass="form-control" runat="server" PlaceHolder="Enter Country Name"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvExpenseType" ControlToValidate="#" SetFocusOnError="True" Display="Dynamic" runat="server" ErrorMessage="Enter Expense Type"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCountryCode" CssClass="form-control" runat="server" PlaceHolder="Enter Country Code"></asp:TextBox>
                                                            </td>
                                                            <asp:HiddenField ID="hfCountryID" runat="server" />

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

                                        <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_Country/MST_CountryList.aspx"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>




                </ContentTemplate>
            </asp:UpdatePanel>
            <script>
                function checkAll(ele) {
                    var checkboxes = document.querySelectorAll('[id*=chkIsSelected]');

                    console.log(document.querySelectorAll('[id*=chkIsSelected]'));
                    console.log(document.querySelectorAll('[id*=cbSelectAll]'));

                    var cbSelectAll = document.querySelectorAll('[id*=cbSelectAll]')[0]; // Get the first element

                    if (cbSelectAll.checked) {
                        for (var i = 0; i < checkboxes.length; i++) {
                            checkboxes[i].checked = true;
                        }
                    }
                    else {
                        for (var i = 0; i < checkboxes.length; i++) {
                            checkboxes[i].checked = false;
                        }
                    }
                }

                function uckSelectAll(ele) {
                    var checkboxes = document.querySelectorAll('[id*=chkIsSelected]');

                    var cbSelectAll = document.querySelectorAll('[id*=cbSelectAll]')[0];

                    for (var i = 0; i < checkboxes.length; i++) {
                        if (!checkboxes[i].checked)
                            cbSelectAll.checked = false;
                    }
                }
            </script>
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
