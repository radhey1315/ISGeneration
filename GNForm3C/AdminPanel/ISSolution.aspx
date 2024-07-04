<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true"
    CodeFile="ISSolution.aspx.cs" Inherits="AdminPanel_ISSolution" %>

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
                                    <asp:Label ID="lblAddress_XXXXX" runat="server" Text="Address :"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" PlaceHolder="Enter Address"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAddress" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtAddress" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblGSTIN" runat="server" Text="GSTIN"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtGSTIN" CssClass="form-control" runat="server" PlaceHolder="Enter GSTIN Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtGSTIN" ErrorMessage="Enter GSTIN Number"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label2" runat="server" Text="INVOICE NO."></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtInvoiceNo" CssClass="form-control" runat="server" PlaceHolder="Enter Invoice Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvInvoiceNo" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtInvoiceNo" ErrorMessage="Enter Invoice Number"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>

                                        <asp:TextBox ID="dtpDate" CssClass="form-control" runat="server" placeholder=" Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dtpDate"
                                        ErrorMessage="Enter  Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label1" runat="server" Text="PO NO."></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPONo" CssClass="form-control" runat="server" PlaceHolder="Enter PO Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtPONo" ErrorMessage="Enter PO Number"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label4" runat="server" Text="PO Date"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>

                                        <asp:TextBox ID="dtpPODate" CssClass="form-control" runat="server" placeholder="PO Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dtpDate"
                                        ErrorMessage="Enter  Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label5" runat="server" Text="Our Income Tax PAN"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtIncomeTaxPAN" CssClass="form-control" runat="server" PlaceHolder="Enter Income Tax PAN"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtIncomeTaxPAN" ErrorMessage="Enter Income Tax PAN"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label6" runat="server" Text="Our GST No."></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtGSTNo" CssClass="form-control" runat="server" PlaceHolder="Enter GST No."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtGSTNo" ErrorMessage="Enter GST No."></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label9" runat="server" Text="Bank Name"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBankName" CssClass="form-control" runat="server" PlaceHolder="Enter Bank Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtBankName" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label7" runat="server" Text="Bank A/C No."></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBankACNo" CssClass="form-control" runat="server" PlaceHolder="Enter Bank A/C No."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtBankACNo" ErrorMessage="Enter Bank A/C No."></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label8" runat="server" Text="Bank IFSC"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBankIFSC" CssClass="form-control" runat="server" PlaceHolder="Enter Bank IFSC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" SetFocusOnError="True" Display="Dynamic"
                                        runat="server" ControlToValidate="txtBankIFSC" ErrorMessage="Enter Bank IFSC"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-2 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label10" runat="server" Text="Our Category of Service"></asp:Label>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtCategoryOfService" CssClass="form-control" runat="server" PlaceHolder="Our Category Of Service"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" SetFocusOnError="True"
                                        Display="Dynamic"
                                        runat="server" ControlToValidate="txtCategoryOfService" ErrorMessage="Enter Category of Service"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-6">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnBlue" Text="Save & Next"  OnClick="btnSave_Click" />

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

