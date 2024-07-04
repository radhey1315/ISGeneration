<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true"
    CodeFile="Itemissue.aspx.cs" Inherits="AdminPanel_Itemissue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="IS Solution" runat="server"></asp:Label><small><asp:Label
        ID="lblPageHeaderInfo_XXXXX" Text="" runat="server"></asp:Label></small>
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
                            <asp:Label ID="lblFormHeader" runat="server" Text="Insert Details"></asp:Label>
                        </span>
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblItemNo_XXXXX" runat="server" Text="Item No :"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtItemNo" CssClass="form-control" runat="server" PlaceHolder="Enter Item No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvItemNo" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtItemNo" ErrorMessage="Enter Item No"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblItemName" runat="server" Text="ItemName"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtItemName" CssClass="form-control" runat="server" PlaceHolder="Enter Item Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtItemName" ErrorMessage="Enter Item Name"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label2" runat="server" Text="Quntity"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtQuntity" CssClass="form-control" runat="server" PlaceHolder="Enter Quntity"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvQuntity" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtQuntity" ErrorMessage="Enter Quntity"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label1" runat="server" Text="Price"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" PlaceHolder="Enter Price"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtPrice" ErrorMessage="Enter Price"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label3" runat="server" Text="Unit"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server" PlaceHolder="Enter Unit"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtUnit" ErrorMessage="Enter Unit"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" PlaceHolder="Enter Amount"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Amount"></asp:RequiredFieldValidator>
                                </div>
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>


