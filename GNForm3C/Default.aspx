<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" /> 

    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />

    <!-- BEGIN GLOBAL MANDATORY STYLES -->

    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/font-awesome/css/font-awesome.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/simple-line-icons/simple-line-icons.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap/css/bootstrap.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />

    <!-- END GLOBAL MANDATORY STYLES -->

    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="<%=ResolveClientUrl("~/Default/assets/global/css/components.min.css?V=2_20200225") %>" rel="stylesheet" id="style_components" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/css/plugins.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->

    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="<%=ResolveClientUrl("~/Default/assets/layouts/layout/css/layout.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/layouts/layout/css/themes/light2.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" id="style_color" />
    <link href="<%=ResolveClientUrl("~/Default/assets/layouts/layout/css/custom.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
</head>
<body style="background-color: transparent; background-image: url(./Default/img/bg1.jpg); background-repeat: no-repeat; background-size:cover;">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top: 14em; margin-left: 17em;">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="portlet dark">
                        <div class="portlet-title" style="padding:1em;">
                            <div class="caption">
                                <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                                <span class="caption-subject font-green-sharp bold uppercase">
                                    <asp:Label ID="lblFormHeader" runat="server" Text="Login"></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div class="form-horizontal" role="form">
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="col-md-3 control-label" style="color:white;">

                                            <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                                        </label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" PlaceHolder="Enter UserName"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvUserName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter UserName"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-1"></div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label" style="color:white;">
                                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                        </label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" PlaceHolder="Enter Password" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-1"></div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-3 col-md-3">

                                            <asp:LinkButton runat="server" ID="lbtnLogin" CssClass="btn col-md-12 btn-success" OnClick="lbtnLogin_Click">
                                Login&nbsp;&nbsp;<i class="fa fa-arrow-circle-right"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>
    </form>
</body>
</html>
