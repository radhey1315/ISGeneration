<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true"
    CodeFile="MST_StateAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_State_MST_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="State" runat="server"></asp:Label><small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
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
    <asp:UpdatePanel ID="upMST_State" runat="server" EnableViewState="true" UpdateMode="Conditional"
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
                            <asp:Label ID="lblFormHeader" runat="server" Text="State Insert"></asp:Label>
                        </span>
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">

                            <div class="form-group">
                                <label class="col-md-4 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblCountryID" runat="server" Text="Country Name"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlCountryName" CssClass="form-control select2me"  runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server"
                                        Display="Dynamic" ControlToValidate="ddlCountryName" ErrorMessage="Select Country Name"
                                        InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>      


                            <div class="form-group">
                                <label class="col-md-4 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblExpenseType_XXXXX" runat="server" Text="State Name"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtStateName" CssClass="form-control" runat="server" PlaceHolder="Enter State Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvExpenseType" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtStateName" ErrorMessage="Enter New State Name"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-4 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label1" runat="server" Text="State Code"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtStateCode" CssClass="form-control" runat="server" PlaceHolder="Enter State Code"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtStateCode" ErrorMessage="Enter New State Code"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-md-4 control-label">
                                    <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Description"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine"
                                        PlaceHolder="Enter Description"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-4 col-md-5">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_State/MST_StateList.aspx"></asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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

