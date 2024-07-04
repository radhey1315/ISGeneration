<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="MST_HospitalViewCount.aspx.cs" Inherits="AdminPanel_Master_MST_Hospital_MST_HospitalViewCount" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
	<!-- BEGIN SAMPLE FORM PORTLET-->
	<div class="portlet light">
		<div class="portlet-title">
			<div class="caption">
				<asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
				<span class="caption-subject font-green-sharp bold uppercase">Expense Types</span>
			</div>
			<div class="tools">
				<asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
			</div>
		</div>
		<div class="portlet-body form">
		<div class="form-horizontal" role="form">
		<table class="table table-bordered table-advance table-hover">
			
                                                <tr >
                                                    <td class="TDDarkView"><asp:Label ID="lbhHospital" runat="server" Text="Hospital"></asp:Label>
                                                    </td>
                                                    <td class="TDDarkView"><asp:Label ID="lblExpenseType" runat="server" Text="Expense Type"></asp:Label>
                                                    </td>
                                                </tr>
                                           
                                            <%-- END Table Header --%>

                                            
                                                <asp:Repeater ID="rpData" runat="server">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr >
                                                            <td >
                                                            	<%#Eval("Hospital") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("ExpenseType") %>
                                                            </td>
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            
		</table>
	</div>
</div>
</div>
<!-- END SAMPLE FORM PORTLET-->
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" Runat="Server">
<script>
    $(document).keyup(function (e) {
        if (e.keyCode == 27) {;
            $("#CloseButton").trigger("click");
        }
    });
</script>
</asp:Content>


