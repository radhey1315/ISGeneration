<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true"
    CodeFile="MST_StateList.aspx.cs" Inherits="AdminPanel_Master_MST_State_MST_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblStateName" runat="server" Text="State"></asp:Label>
    <small>
        <asp:Label ID="lblMaster" runat="server" Text="Master"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="HyperLink1" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
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
    <li class="active">
        <asp:Label ID="LabelStateName" runat="server" Text="State"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                        <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse pull-right"></a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div role="form">
                        <div class="form-body">
                            <div class="row">

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtStateName" CssClass="First form-control" runat="server" PlaceHolder="Enter State Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <%--<asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>--%>
                                            <asp:TextBox ID="txtStateCode" CssClass="First form-control" runat="server" PlaceHolder="Enter State Code"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtCountryName" CssClass="First form-control" runat="server" PlaceHolder="Enter Country Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
                                    <%-- <asp:Button ID="Button1" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
<asp:Button ID="Button2" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" /> --%>
                                    <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>

    <%-- List --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                <label class="control-label">&nbsp;</label>
                                <label class="control-label pull-right">
                                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                                </label>
                            </div>
                            <div class="tools">
                                <div>
                                    <%-- <asp:HyperLink SkinID="hlAddMore" ID="hlAddEditMore" NavigateUrl="~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeAddEditMore.aspx"
                                      runat="server"></asp:HyperLink>--%>

                                    <asp:LinkButton SkinID="hlDeleteMany" runat="server" ID="btnDeleteMany" OnClick="lbtnDelete_Click"
                                        OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"></asp:LinkButton>
                                    <%----%>

                                    <asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Master/MST_State/MST_StateAddEdit.aspx"
                                        runat="server"></asp:HyperLink>

                                    <div class="btn-group" runat="server" id="Div_ExportOption" visible="true">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Export <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right">
                                            <li>
                                                <asp:LinkButton ID="lbtnExportPDF" runat="server" CommandArgument="PDF" OnClick="lbtnExport_Click">PDF</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandArgument="Excel">Excel</asp:LinkButton>
                                                <%--OnClick="lbtnExport_Click"--%>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                <div class="col-md-12">
                                    <div id="TableContent">
                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                            <%-- Table Header --%>
                                            <thead>
                                                <tr class="TRDark">

                                                    <th class="text-center">
                                                        <asp:CheckBox onchange="checkAll(this)" runat="server" ID="cbSelectAll" />
                                                    </th>

                                                    <th>
                                                        <asp:Label ID="lbhCountryName" runat="server" Text="Country Name"></asp:Label>
                                                    </th>


                                                    <th>
                                                        <asp:Label ID="lbhStateName" runat="server" Text="State Name"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhStateCode" runat="server" Text="State Code"></asp:Label>
                                                    </th>

                                                    <th class="nosortsearch text-nowrap text-center">
                                                        <asp:Label ID="lbhAction" runat="server" Text="Action"></asp:Label>
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
                                                                <asp:CheckBox ID="cbkDelete" onclick="uckSelectAll(this)" CssClass="checkbox-group"
                                                                    runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="hflCountryName" Text='<%#Eval("CountryName")%>' Value='<%#Eval("CountryName") %>'
                                                                    NavigateUrl='<%# "~/AdminPanel/Master/MST_Country/MST_CountryView.aspx?CountryID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("CountryID").ToString()) %>'
                                                                    data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"></asp:HyperLink>

                                                            </td>
                                                            <td>
                                                                <%#Eval("StateName") %>
                                                                <asp:HiddenField runat="server" ID="hfStateID" Value='<%#Eval("StateID") %>' Visible="false" />
                                                            </td>

                                                            <td>
                                                                <%#Eval("StateCode") %>
                                                            </td>

                                                            <td class="text-nowrap text-center">

                                                                <asp:HyperLink ID="hlView" SkinID="View" NavigateUrl='<%# "~/AdminPanel/Master/MST_State/MST_StateView.aspx?StateID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("StateID").ToString()) %>'
                                                                    data-target="#viewiFrameReg" data-toggle="modal" runat="server"></asp:HyperLink>

                                                                <asp:HyperLink ID="AddData" title="Edit Record" runat="server" Text="Edit" CssClass="btn btn-xs btn-circle blue-soft tooltips"
                                                                    data-html="true" data-toggle="tooltip" data-placement="bottom"
                                                                    NavigateUrl='<%# "~/AdminPanel/Master/MST_State/MST_StateAddEdit.aspx?StateID=" + Eval("StateID")%>'>  <i class="fa fa-edit"></i> </asp:HyperLink>
                                                                <asp:LinkButton ID="lbtnDelete" runat="server"
                                                                    SkinID="Delete"
                                                                    OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"
                                                                    CommandName="DeleteRecord"
                                                                    CommandArgument='<%#Eval("StateID") %>'>
                                                                </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </tbody>
                                        </table>
                                    </div>
                                    <%-- Pagination --%>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">
                                                <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server"></asp:Label></label>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="dataTables_paginate paging_simple_numbers" runat="server" id="Div_Pagination">
                                                <ul class="pagination">
                                                    <li class="paginate_button previous disabled" id="liFirstPage" runat="server">
                                                        <asp:LinkButton ID="lbtnFirstPage" Enabled="false" OnClick="PageChange_Click" CommandName="FirstPage"
                                                            CommandArgument="1" runat="server"><i class="fa fa-angle-double-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="paginate_button previous disabled" id="liPrevious" runat="server">
                                                        <asp:LinkButton ID="lbtnPrevious" Enabled="false" OnClick="PageChange_Click" CommandArgument="1"
                                                            CommandName="PreviousPage" runat="server"><i class="fa fa-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <asp:Repeater ID="rpPagination" runat="server" OnItemDataBound="rpPagination_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li>
                                                                <li class="paginate_button" id="liPageNo" runat="server">
                                                                    <asp:LinkButton ID="lbtnPageNo" runat="server" OnClick="PageChange_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageNo")%>'
                                                                        CommandName="PageNo"><%# DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton>
                                                                </li>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li class="paginate_button next disabled" id="liNext" runat="server">
                                                        <asp:LinkButton ID="lbtnNext" Enabled="false" OnClick="PageChange_Click" CommandArgument="1"
                                                            CommandName="NextPage" runat="server"><i class="fa fa-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="paginate_button previous disabled" id="liLastPage" runat="server">
                                                        <asp:LinkButton ID="lbtnLastPage" Enabled="false" OnClick="PageChange_Click" CommandName="LastPage"
                                                            CommandArgument="-99" runat="server"><i class="fa fa-angle-double-right"></i></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-md-3 pull-right">
                                            <div class="btn-group" runat="server" id="Div_GoToPageNo">
                                                <asp:TextBox ID="txtPageNo" placeholder="Page No" onkeypress="return IsNumeric(event)"
                                                    runat="server" CssClass="pagination-panel-input form-control input-xsmall input-inline col-md-4"
                                                    MaxLength="9"></asp:TextBox>
                                                <asp:LinkButton ID="lbtnGoToPageNo" runat="server" CssClass="btn btn-default input-inline col-md-4"
                                                    CommandName="GoPageNo" CommandArgument="0" OnClick="PageChange_Click">Go</asp:LinkButton>
                                            </div>
                                            <div class="btn-group pull-right" runat="server" id="Div_PageSize">
                                                <label class="control-label">Page Size</label>
                                                <asp:DropDownList ID="ddlPageSizeBottom" AutoPostBack="true" CssClass="form-control input-xsmall"
                                                    runat="server" OnSelectedIndexChanged="ddlPageSizeBottom_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                    <%-- END Pagination --%>
                                </div>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                </div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        var table = $('#sample_1').DataTable({
                            "order": [], // Disable initial sorting
                            "paging": true, // Enable pagination
                            "searching": true, // Enable DataTables' search feature
                        });

                        // Add custom search functionality
                        $('#input').keyup(function () {
                            table.search(this.value).draw();
                        });
                    });


                    function checkAll(ele) {
                        var checkboxes = document.querySelectorAll('[id*=cbkDelete]');

                        console.log(document.querySelectorAll('[id*=cbkDelete]'));
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
                        var checkboxes = document.querySelectorAll('[id*=cbkDelete]');

                        var cbSelectAll = document.querySelectorAll('[id*=cbSelectAll]')[0];

                        for (var i = 0; i < checkboxes.length; i++) {
                            if (!checkboxes[i].checked)
                                cbSelectAll.checked = false;
                        }
                    }

                </script>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
            <asp:PostBackTrigger ControlID="lbtnExportExcel" />
            <asp:PostBackTrigger ControlID="lbtnExportPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- END List --%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>

        $(window).keydown(function (e) {
            GNWebKeyEvents(e.keyCode, '<%=hlAddNew.ClientID%>', '<%=btnSearch.ClientID%>');
        });

        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);
    </script>
</asp:Content>

