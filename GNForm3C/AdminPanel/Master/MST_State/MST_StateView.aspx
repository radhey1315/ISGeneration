<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master"
    AutoEventWireup="true" CodeFile="MST_StateView.aspx.cs" Inherits="AdminPanel_Master_MST_State_MST_StateView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">

    <!-- BEGIN SAMPLE FORM PORTLET-->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server">
                </asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">State View</span>
            </div>
            <div class="tools">
                <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static">
                </asp:HyperLink>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <table class="table table-bordered table-advance table-hover">
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblCountryName_XXXx" Text="Country Name" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCountryName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblHospitalID_XXXXX" Text="Statet Name" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblHospitalID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblRemarks_XXXXX" Text="State Code" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblCreated_XXXXX" Text="Created" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCreated" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblModified_XXXXX" Text="Modified" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblModified" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblDescription_XXXX" Text="Description" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </div>
    <!-- END SAMPLE FORM PORTLET-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                ;
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content>

