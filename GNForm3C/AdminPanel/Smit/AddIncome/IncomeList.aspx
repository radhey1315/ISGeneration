<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="IncomeList.aspx.cs" Inherits="AdminPanel_Smit_AddIncome_IncomeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css"></link>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js"></script>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
        integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
        crossorigin="anonymous">
    </script>


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
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

    <!--Help Text-->
    <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->

    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <%-- END Table Header --%>
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
                                            <asp:DropDownList AutoPostBack="true" ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHospitalID_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlIncomeTypeID" CssClass="First form-control select2me" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIncomeTypeID_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" PlaceHolder="Enter Amount"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" PlaceHolder="Enter Remarks"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
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
    <%-- Table Rows --%>
    <%#Eval("Hospital") %>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ShowMessage1" runat="server" ViewStateMode="Disabled" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
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
                                            <%--<asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>--%>
                                        </label>
                                    </div>
                                    <div class="tools">
                                        <div>
                                            <asp:HyperLink SkinID="hlAddNew" CssClass="btn btn-circle btn-success " ID="hlAddNew" NavigateUrl="~/AdminPanel/Smit/AddIncome/IncomeAddEdit.aspx" runat="server"></asp:HyperLink>
                                            <%--<div class="btn-group" runat="server" id="Div_ExportOption" visible="true">
                                                <button class="btn dropdown-toggle" data-toggle="dropdown">
                                                    Export <i class="fa fa-angle-down"></i>
                                                </button>
                                                <ul class="dropdown-menu pull-right">
                                                    <li>
                                                        <asp:LinkButton ID="lbtnExportPDF" runat="server" CommandArgument="PDF">PDF</asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandArgument="Excel">Excel</asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>--%>

                                            <asp:Button ID="btnDeleteCancel" SkinID="btnCancel" runat="server" Text="Cancel" OnClick="btnDeleteCancel_Click" Visible="False" />
                                            <asp:LinkButton ID="lbtnDeleteMany" Text="Delete Many" CssClass="btn btn-sm btn-circle btn-danger" runat="server" OnClick="lbtnDeleteMany_Click" Visible="False"></asp:LinkButton>

                                        </div>
                                    </div>
                                </div>

                                <asp:Label runat="server" ID="lblSearchField" EnableViewState="">

                                    <div style="display: flex; justify-content: flex-end; align-items: center">
                                        <label for="input" style="margin-right: 5px;">Search : </label>
                                        <input type="text" id="input" class="form-control " style="width: 15%; margin: 10px 0px" />
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="lbtnDelete"
                                            OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"
                                            runat="server" SkinID="lbtnDeleteMultiple" Visible="false" OnClick="lbtnDelete_Click">
                                        </asp:LinkButton>
                                    </div>
                                </asp:Label>



                                <div class="portlet-body">
                                    <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                        <div class="col-md-12">

                                            <div style="display: flex; justify-content: space-between; align-items: center;">
                                            </div>

                                            <div id="TableContent">
                                                <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                    <%-- Table Header --%>
                                                    <thead>
                                                        <tr class="TRDark">

                                                            <asp:Label ID="lblDeleteVisible" Visible="false" EnableViewState="false" runat="server">
                                                                <th class="text-center">
                                                                    <asp:CheckBox onchange="checkAll(this)" Visible="true" runat="server" ID="cbSelectAll" /></th>
                                                            </asp:Label>

                                                            <th>
                                                                <asp:Label ID="lblHospitalID" runat="server" Text="Hospital"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lbhIncomeTypeID" runat="server" Text="Income Type"></asp:Label>
                                                            </th>
                                                            <th class="text-center">
                                                                <asp:Label ID="lbhIncomeDate" runat="server" Text="Income Date"></asp:Label>
                                                            </th>
                                                            <th class="text-right">
                                                                <asp:Label ID="lbhAmount" runat="server" Text="Amount"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label runat="server" ID="lblNote" Text="Note"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label runat="server" ID="lblRemark" Text="Remark"></asp:Label>
                                                            </th>
                                                            <th class="nosortsearch text-nowrap text-center">
                                                                <asp:Label ID="lbhSalaryIncomeTypeNames" runat="server" Text="SalaryIncomeTypeNames"></asp:Label>
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

                                                                    <% if (lblDeleteVisible.Visible)
                                                                        { %>
                                                                    <td class="text-center">
                                                                        <asp:CheckBox ID="cbkDelete" onclick="uckSelectAll(this)" CssClass="checkbox-group" Visible="true" runat="server" />
                                                                    </td>
                                                                    <% } %>
                                                                    <td>
                                                                        <asp:HyperLink ID="hlViewHospital" NavigateUrl='<%# "~/AdminPanel/Smit/AddIncome/IncomeView.aspx?IncomeID=" +(Eval("IncomeID").ToString())  %>' data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"><%#Eval("Hospital") %></asp:HyperLink>
                                                                        <asp:HiddenField runat="server" ID="hfIncomeID" Value='<%#Eval("IncomeID") %>' />
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("IncomeType") %>
                                                                    </td>
                                                                    <td class="text-center">
                                                                        <%#Eval("IncomeDate", GNForm3C.CV.DefaultDateFormatForGrid) %>
                                                                    </td>
                                                                    <td class="text-right">
                                                                        <%#Eval("Amount", GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %>
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("Note") %>
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("Remarks") %>
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("SalaryIncomeTypeNames") %>
                                                                    </td>
                                                                    <td class="text-nowrap text-center">
                                                                        <asp:HyperLink ID="hlView" SkinID="View" NavigateUrl='<%# "~/AdminPanel/Smit/AddIncome/IncomeView.aspx?IncomeID=" +(Eval("IncomeID").ToString()) %>' data-target="#viewiFrameReg" data-toggle="modal" runat="server"></asp:HyperLink>
                                                                        <asp:HyperLink ID="hlEdit" SkinID="Edit" NavigateUrl='<%# "~/AdminPanel/Smit/AddIncome/IncomeAddEdit.aspx?IncomeID=" +(Eval("IncomeID").ToString()) %>' runat="server"></asp:HyperLink>
                                                                        <asp:LinkButton ID="lbtnDelete" runat="server"
                                                                            SkinID="Delete"
                                                                            OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"
                                                                            CommandName="DeleteRecord"
                                                                            CommandArgument='<%#Eval("IncomeID") %>'>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <%-- END Table Rows --%>
                                                            </ItemTemplate>
                                                        </asp:Repeater>


                                                        <tr id="noMatchingRecord" style="display: none;">
                                                            <td colspan="7" class="text-center">No matching record found.
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                                <div id="paginationInfo" class="" style="margin-top: 10px;"></div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
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
        </Triggers>
    </asp:UpdatePanel>
    <%#Eval("Note") %>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">



    <script type="text/javascript">

        $(document).ready(function () {
            $('#input').keyup(function () {
                var searchText = $('#input').val().toLowerCase();
                var noMatchingRecord = true;

                $('#sample_1 tbody tr').each(function () {
                    var rowText = $(this).text().toLowerCase();
                    if (rowText.includes(searchText)) {
                        $(this).show();
                        noMatchingRecord = false; // Records found
                    } else {
                        $(this).hide();
                    }
                });

                if (noMatchingRecord) {
                    $('#noMatchingRecord').show(); // Show the message
                } else {
                    $('#noMatchingRecord').hide(); // Hide the message if records are found
                }
            });
        });
    </script>
</asp:Content>

