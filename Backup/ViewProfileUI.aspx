<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="ViewProfileUI.aspx.cs" Inherits="SMS.UI.ViewProfileUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="page-content" style="min-height: 344px;">
                <div class="content-header content-header-media">
                    <div class="header-section">
                        <img class="pull-right img-circle" alt="Avatar" src="./img/avg.png">
                        <h1>
                            <asp:Label runat="server" ID="lblUserName" Text="Anik Islam Abhi" />
                            <br>
                        </h1>
                    </div>
                    <img class="animation-pulseSlow" alt="header image" src="img/ban.png" />
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-5">
                        <div class="block">
                            <div class="block-title">
                                <div class="block-options pull-right">
                                    <a title="" data-toggle="tooltip" class="btn btn-alt btn-sm btn-default" href="EditProfileUI.aspx"
                                        data-original-title="Edit Profile"><i class="gi gi-pencil"></i></a>
                                </div>
                                <h2>
                                    About <strong>
                                        <asp:Label runat="server" ID="lbluserTitle" Text="Anik Islam Abhi"></asp:Label></strong>
                                    <small>• </small>
                                </h2>
                            </div>
                            <table class="table table-borderless table-striped">
                                <tbody>
                                    <tr>
                                        <td style="width: 20%;">
                                            <strong>Address</strong>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Email</strong>
                                        </td>
                                        <td>
                                            <a href="javascript:void(0)">
                                                <asp:Label runat="server" ID="lblEmail"></asp:Label></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Phone</strong>
                                        </td>
                                        <td>
                                            <a href="javascript:void(0)">
                                                <asp:Label runat="server" ID="lblPhone"></asp:Label></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>District</strong>
                                        </td>
                                        <td>
                                            <strong>
                                                <asp:Label runat="server" ID="lblDistrict"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Postal Code</strong>
                                        </td>
                                        <td>
                                            <strong>
                                                <asp:Label runat="server" ID="lblPostalCode"></asp:Label></strong>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-7">
                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left themed-background-fire animation-fadeIn" href="./page_ready_inbox.php.html">
                                    <i class="gi gi-envelope"></i></a>
                                <h3 class="widget-content text-right animation-pullDown">
                                    <strong>
                                        <asp:Label runat="server" ID="lblMsgCount"></asp:Label>
                                        Messages</strong> <small>Message Balance</small>
                                </h3>
                            </div>
                        </div>
                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left themed-background-spring animation-fadeIn" href="./page_comp_charts.php.html">
                                    <i class="gi gi-usd"></i></a>
                                <h3 class="widget-content text-right animation-pullDown">
                                    <strong>৳
                                        <asp:Label runat="server" ID="lblMoneyBalance" Text="250"></asp:Label></strong><br>
                                    <small>Money Spent</small>
                                </h3>
                            </div>
                        </div>
                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left themed-background-autumn animation-fadeIn" href="./page_ready_article.php.html">
                                    <i class="fa fa-file-text"></i></a>
                                <h3 class="widget-content text-right animation-pullDown">
                                    <strong>
                                        <asp:Label runat="server" ID="lblContact" Text="250"></asp:Label></strong><br>
                                    <small>Total Contacts</small>
                                </h3>
                            </div>
                        </div>
                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left themed-background-amethyst animation-fadeIn" href="./page_ready_article.php.html">
                                    <i class="gi gi-wallet"></i></a>
                                <h3 class="widget-content text-right animation-pullDown">
                                    <strong>
                                        <asp:Label runat="server" ID="lblMsgSent" Text="250"></asp:Label>
                                        Messages</strong><br>
                                    <small>Total Sent Messages</small>
                                </h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
