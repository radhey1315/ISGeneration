<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AdminPanel_Default" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Dashboard" runat="server"></asp:Label>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!-- BEGIN PAGE CONTENT BODY -->

    <div class="row">

        <div class="col-lg-7 col-md-7">

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 ">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-green-sharp">
                                <span data-counter="counterup" data-value="7800">
                                    <asp:HyperLink runat="server" ID="hlIncomeAmount" CssClass="font-green-sharp" NavigateUrl="~/AdminPanel/Smit/AddIncome/IncomeList.aspx">
                                        <asp:Label runat="server" ID="lblTotalIncomeAmount"></asp:Label>
                                    </asp:HyperLink>
                                </span>
                                <small class="font-green-sharp">₹</small>
                            </h3>
                            <small>TOTAL Income</small>
                        </div>
                        <div class="icon">
                            <i class="icon-pie-chart"></i>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 ">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-red-haze">
                                <span data-counter="counterup" data-value="1349">
                                    <asp:HyperLink runat="server" ID="hlExpense" CssClass="font-red-haze" NavigateUrl="~/AdminPanel/Account/ACC_Expense/ACC_ExpenseList.aspx">
                                        <asp:Label runat="server" ID="lblTotalExpenseAmount"></asp:Label>
                                    </asp:HyperLink>
                                </span>
                                <small class="font-red-haze">₹</small>
                            </h3>
                            <small>Total Expense</small>
                        </div>
                        <div class="icon">
                            <i class="icon-basket"></i>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="margin-top: 25px">
                <div class="dashboard-stat2 ">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-blue-sharp">
                                <span data-counter="counterup" data-value="567">
                                    <asp:HyperLink runat="server" ID="HyperLink1" CssClass="font-blue-sharp" NavigateUrl="~/AdminPanel/Master/MST_Hospital/MST_HospitalList.aspx" >
                                        <asp:Label runat="server" ID="lblHospitalCount"></asp:Label>
                                    </asp:HyperLink>
                                </span>
                            </h3>
                            <small>Shops</small>
                        </div>
                        <div class="icon">
                            <i class="icon-like"></i>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="margin-top: 25px">
                <div class="dashboard-stat2 ">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-purple-soft">
                                <span data-counter="counterup" data-value="276">
                                    <asp:Label runat="server" ID="lblSalaryIncomeTypeCount"></asp:Label></span>
                            </h3>
                            <small>Salary Type</small>
                        </div>
                        <div class="icon">
                            <i class="icon-user"></i>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="margin-top: 25px">
                <div class="dashboard-stat2 ">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-blue-sharp">
                                <span data-counter="counterup" data-value="567">
                                    <asp:Label runat="server" ID="lblDeductionType" Text=""></asp:Label></span>
                            </h3>
                            <small>Deduction Types </small>
                        </div>
                        <div class="icon">
                            <i class="fa fa-clipboard icon"></i>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="margin-top: 25px">
                <div class="dashboard-stat2 ">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-blue-sharp">
                                <span data-counter="counterup" data-value="567">
                                    <asp:Label runat="server" ID="Label4" Text="0"></asp:Label></span>
                            </h3>
                            <small>Items </small>
                        </div>
                        <div class="icon">
                            <i class="fa fa-file icon"></i>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="col-md-5">
            <div class="dashboard-stat2 ">
                <div class="display">
                    <canvas id="employeeCountChart" style="max-height: 305px; max-width: 1000px;"></canvas>
                </div>
            </div>
        </div>



        <div class="col-lg-6 col-xs-12 col-sm-12" style="margin-top: 20px">
            <div class="portlet light ">
                <div class="portlet-title">
                    <div class="caption">
                        <span class="caption-subject bold uppercase font-dark font-green-sharp">Top 10 Recent Income</span>
                    </div>
                    <div class="actions">
                        <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <%--<div id="dashboard_amchart_1" class="CSSAnimationChart"></div>--%>
                    <div id="TableContent">
                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                            <%-- Table Header --%>
                            <thead>
                                <tr class="TRDark">
                                    <th>
                                        <asp:Label runat="server" Text="Sr. No."></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblHospitalID" runat="server" Text="Shop"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhIncomeTypeID" runat="server" Text="Income Type"></asp:Label>
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
                                        <asp:Label ID="lbhSalaryIncomeTypeNames" runat="server" Text="Salary Income Type Names"></asp:Label>
                                    </th>

                                </tr>
                            </thead>
                            <%-- END Table Header --%>

                            <tbody>
                                <asp:Repeater ID="rpData" runat="server">
                                    <ItemTemplate>
                                        <%-- Table Rows --%>
                                        <tr class="odd gradeX">
                                            <td class="font-blue-dark bold font-lg">
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="hlViewHospital" NavigateUrl='<%# "~/AdminPanel/Smit/AddIncome/IncomeView.aspx?IncomeID=" +(Eval("IncomeID").ToString())  %>' data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"><%#Eval("Hospital") %></asp:HyperLink>
                                            </td>
                                            <td>
                                                <%#Eval("IncomeType") %>
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

        <div class="col-md-6 col-sm-6" style="margin-top: 20px">
            <!-- BEGIN PORTLET-->
            <div class="portlet light ">
                <div class="portlet-title tabbable-line">
                    <div class="caption">
                        <i class="icon-globe font-dark hide"></i>
                        <span class="caption-subject bold uppercase font-red-haze">Recent Expenses</span>
                    </div>
                    <div class="actions">
                        <a class="btn btn-crcle btn-icon-only btn-dfault " disabled="true" href="#" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body" style="max-height: 179px; overflow-y: auto;">
                    <!--BEGIN TABS-->
                    <div class="portlet-body">
                        <%--<div id="dashboard_amchart_1" class="CSSAnimationChart"></div>--%>
                        <div id="TableContent2">
                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_2">
                                <%-- Table Header --%>
                                <thead>
                                    <tr class="TRDark">
                                        <th>
                                            <asp:Label runat="server" Text="Sr. No."></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="lblExpenseType" runat="server" Text="ExpenseType"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="lblHospital" runat="server" Text="SHOP"></asp:Label>
                                        </th>
                                        <th class="text-right">
                                            <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" ID="lblNotes" Text="Note"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" ID="lblRemarks" Text="Remarks"></asp:Label>
                                        </th>
                                    </tr>
                                </thead>
                                <%-- END Table Header --%>

                                <tbody>
                                    <asp:Repeater ID="rpExpense" runat="server">
                                        <ItemTemplate>
                                            <%-- Table Rows --%>
                                            <tr class="odd gradeX">
                                                <td class="font-blue-dark bold font-lg">
                                                    <%# Container.ItemIndex + 1 %>
                                                </td>
                                                <td>
                                                    <%#Eval("ExpenseType") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Hospital") %>
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
                                            </tr>
                                            <%-- END Table Rows --%>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                    <%--<tr id="noMatchingRecord" style="display: none;">
                                    <td colspan="7" class="text-center">No matching record found.
                                    </td>
                                </tr>--%>
                                </tbody>
                            </table>

                            <%--<div id="paginationInfo" class="" style="margin-top: 10px;"></div>--%>
                        </div>
                    </div>
                    <!--END TABS-->
                </div>
            </div>
            <!-- END PORTLET-->
        </div>

        <div class="col-md-6 col-sm-6" style="margin-top: 20px">
            <!-- BEGIN PORTLET-->
            <div class="portlet light ">
                <div class="portlet-title tabbable-line">
                    <div class="caption">
                        <i class="icon-globe font-dark hide"></i>
                        <span class="caption-subject bold uppercase font-blue-sharp">Expense Type Category</span>
                    </div>
                    <div class="actions">
                        <a class="btn btn-crcle btn-icon-only btn-dfault " disabled="true" href="#" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body" style="max-height: 300px; overflow-y: auto;">
                    <!--BEGIN TABS-->
                    <div class="portlet-body">
                        <%--<div id="dashboard_amchart_1" class="CSSAnimationChart"></div>--%>
                        <div id="TableContent3">
                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_3">
                                <%-- Table Header --%>
                                <thead>
                                    <tr class="TRDark">
                                        <th>
                                            <asp:Label runat="server" Text="Sr. No."></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="lblExpenseTypeDB" runat="server" Text="ExpenseType"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="lblHospitalDB" runat="server" Text="SHOP"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" ID="lblRemar" Text="Remarks"></asp:Label>
                                        </th>
                                        <th class="text-center">
                                            <asp:Label runat="server" ID="lblDate" Text="Date"></asp:Label>
                                        </th>

                                    </tr>
                                </thead>
                                <%-- END Table Header --%>

                                <tbody>
                                    <asp:Repeater ID="rpExpenseType" runat="server">
                                        <ItemTemplate>
                                            <%-- Table Rows --%>
                                            <tr class="odd gradeX">
                                                <td class="font-blue-dark bold font-lg">
                                                    <%# Container.ItemIndex + 1 %>
                                                </td>
                                                <td>
                                                    <%#Eval("ExpenseType") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Hospital") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Remarks") %>
                                                </td>
                                                <td class="text-center">
                                                    <%#Eval("Created", GNForm3C.CV.DefaultDateFormatForGrid) %>
                                                </td>
                                            </tr>
                                            <%-- END Table Rows --%>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                    <%--<tr id="noMatchingRecord" style="display: none;">
                                    <td colspan="7" class="text-center">No matching record found.
                                    </td>
                                </tr>--%>
                                </tbody>
                            </table>

                            <%--<div id="paginationInfo" class="" style="margin-top: 10px;"></div>--%>
                        </div>
                    </div>
                    <!--END TABS-->
                </div>
            </div>
            <!-- END PORTLET-->
        </div>

        <div class="col-md-12 col-sm-12" style="margin-top: 20px">
            <!-- BEGIN PORTLET-->
            <div class="portlet light ">

                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-equalizer font-dark hide"></i>
                        <span class="icon-action-redo font-green-sharp"></span>
                        <span class="caption-subject font-dark bold uppercase font-green-sharp">Quick Links</span>
                    </div>
                    <div class="tools">
                        <a href="#" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>

                <div class="portlet-body" style="max-height: 263px; overflow-y: auto;">
                    <!--BEGIN TABS-->
                    <div class="portlet-body">
                        <%--<div id="dashboard_amchart_1" class="CSSAnimationChart"></div>--%>
                        <div id="TableContent5">
                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_5">
                                <%-- Table Header --%>
                                <thead>
                                    <tr class="TRDark">
                                        <th>
                                            <asp:Label runat="server" Text="Sr. No."></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label2" runat="server" Text="Descriptipn"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" Text="Sample"></asp:Label>
                                        </th>
                                    </tr>
                                </thead>
                                <%-- END Table Header --%>

                               
                            </table>

                            <%--<div id="paginationInfo" class="" style="margin-top: 10px;"></div>--%>
                        </div>
                    </div>
                    <!--END TABS-->
                </div>
            </div>
            <!-- END PORTLET-->
        </div>



    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>



    <script>
        $(".scroller").slimScroll({
            height: "290px", // Set the desired height
            alwaysVisible: true, // Keeps the scrollbar visible
        });

        var tableBody = document.getElementById("table-body");

        // Loop through the table rows and add serial numbers
        for (var i = 0; i < tableBody.rows.length; i++) {
            var serialNumberCell = tableBody.rows[i].cells[0];
            serialNumberCell.textContent = i + 1;
        }

        //KK


        $(document).ready(function () {
            var data = <%= GetChartData() %>;

            var labels = data.slice(2, 4).map(function (item) {
                return item['Category'];
            });

            var values = data.slice(2, 4).map(function (item) {
                return item['Value'];
            });

            // Create a bar chart
            var ctx = document.getElementById('employeeCountChart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Employee Count',
                        data: values,
                        backgroundColor: [
                            'rgba(255, 99, 132)',
                            'rgba(255, 159, 64)',
                            'rgba(255, 205, 86)',
                            'rgba(75, 192, 192)',
                            'rgba(54, 162, 235)',
                            'rgba(153, 102, 255)',
                            'rgba(201, 203, 207)',
                            'rgba(75, 192, 192)'],

                        borderWidth: 0
                    }]
                }
            });
        });



    </script>
</asp:Content>

