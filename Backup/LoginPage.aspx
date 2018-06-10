<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SMS.UI.LoginPage" %>

<!DOCTYPE html>
<!--[if IE 8]>         <html class="no-js lt-ie9"> </html><![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head runat="server">
    <!--  -->
    <!--  -->
    <meta charset="utf-8" />
    <title>SMS on BD</title>
    <meta name="description" content="ProUI is a Responsive Admin Dashboard Template created by pixelcave and published on Themeforest. This is the demo of ProUI! You need to purchase a license for legal use!" />
    <meta name="author" content="pixelcave" />
    <meta name="robots" content="noindex, nofollow" />
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0" />
    <link rel="shortcut icon" href="./img/favicon.ico" />
    <link rel="apple-touch-icon" href="./img/icon57.png" sizes="57x57" />
    <link rel="apple-touch-icon" href="./img/icon72.png" sizes="72x72" />
    <link rel="apple-touch-icon" href="./img/icon76.png" sizes="76x76" />
    <link rel="apple-touch-icon" href="./img/icon114.png" sizes="114x114" />
    <link rel="apple-touch-icon" href="./img/icon120.png" sizes="120x120" />
    <link rel="apple-touch-icon" href="./img/icon144.png" sizes="144x144" />
    <link rel="apple-touch-icon" href="./img/icon152.png" sizes="152x152" />
    <link rel="stylesheet" href="./panel_css/bootstrap.min.css" />
    <link rel="stylesheet" href="./panel_css/plugins.css" />
    <link rel="stylesheet" href="./panel_css/main.css" />
    <link rel="stylesheet" href="./panel_css/themes.css" />
    <script src="./js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="login-background">
                <img src="img/msg.jpg" alt="Login Background" class="animation-pulseSlow" />
            </div>
            <div id="login-container" class="animation-fadeIn">
                <div class="login-title text-center">
                    <h1>
                        <i>
                            <img src="img/logo.png" alt="logo" /></i><br />
                        <small>Please <strong>Login</strong> or <strong>Register</strong></small></h1>
                </div>
                <div class="block remove-margin">
                    <div id="form-login" class="form-horizontal form-bordered form-control-borderless" />
                    <div class="form-group">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="hi hi-user"></i></span>
                                <asp:TextBox ID="txtName" class="form-control input-lg" placeholder="User Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                                <asp:TextBox ID="txtPass" class="form-control input-lg" TextMode="Password" placeholder="Password"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-actions">
                        <div class="col-xs-4">
                            <!--
                    <label class="switch switch-primary" data-toggle="tooltip" title="Remember Me?">
                        <input type="checkbox" id="login-remember-me" name="login-remember-me" checked="" />
                        <span></span>
                    </label>
                    -->
                        </div>
                        <div class="col-xs-8 text-right">
                            <asp:Button ID="btnLogin" class="btn btn-success" Text="Login to Dashboard" runat="server"
                                OnClick="btnLogin_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12">
                            <p class="text-center remove-margin">
                                <small>Don't have an account?</small> <a href="javascript:void(0)" id="link-login"><small>
                                    Create one for free!</small></a></p>
                        </div>
                    </div>
                </div>
                <div id="form-register" class="form-horizontal form-bordered form-control-borderless display-none" />
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-user"></i></span>
                            <asp:TextBox ID="txtRegiUserName" MaxLength="50" class="form-control input-lg" placeholder="Username"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-envelope"></i></span>
                            <asp:TextBox ID="txtRegiEmail" MaxLength="50" class="form-control input-lg" placeholder="Email"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                            <asp:TextBox ID="txtRegiPass" MaxLength="50" runat="server" TextMode="Password" class="form-control input-lg"
                                placeholder="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                            <asp:TextBox ID="txtRegiRePass" TextMode="Password" MaxLength="50" runat="server"
                                class="form-control input-lg" placeholder="Verify Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group form-actions">
                    <div class="col-xs-6">
                        <!--
                <a href="#modal-terms" data-toggle="modal" class="register-terms">Terms</a>
                <label class="switch switch-primary" data-toggle="tooltip" title="Agree to the terms">
                    <input type="checkbox" id="register-terms" name="register-terms" />
                    <span></span>
                </label>
                -->
                    </div>
                    <div class="col-xs-6 text-right">
                        <asp:Button ID="btnRegi" runat="server" class="btn  btn-success" Text="Register Account"
                            OnClick="btnRegi_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <p class="text-center remove-margin">
                            <small>Oops, you have an account?</small> <a href="javascript:void(0)" id="link-register">
                                <small>Login!</small></a></p>
                    </div>
                </div>
            </div>
            </div> </div>
            <!--
        <div id="modal-terms" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                        <h4 class="modal-title">
                            Terms &amp; Conditions</h4>
                    </div>
                    <div class="modal-body">
                        <h4>
                            Title</h4>
                        <p>
                            Donec lacinia venenatis metus at bibendum? In hac habitasse platea dictumst. Proin
                            ac nibh rutrum lectus rhoncus eleifend. Sed porttitor pretium venenatis. Suspendisse
                            potenti. Aliquam quis ligula elit. Aliquam at orci ac neque semper dictum. Sed tincidunt
                            scelerisque ligula, et facilisis nulla hendrerit non. Suspendisse potenti. Pellentesque
                            non accumsan orci. Praesent at lacinia dolor. Lorem ipsum dolor sit amet, consectetur
                            adipiscing elit.</p>
                        <p>
                            Donec lacinia venenatis metus at bibendum? In hac habitasse platea dictumst. Proin
                            ac nibh rutrum lectus rhoncus eleifend. Sed porttitor pretium venenatis. Suspendisse
                            potenti. Aliquam quis ligula elit. Aliquam at orci ac neque semper dictum. Sed tincidunt
                            scelerisque ligula, et facilisis nulla hendrerit non. Suspendisse potenti. Pellentesque
                            non accumsan orci. Praesent at lacinia dolor. Lorem ipsum dolor sit amet, consectetur
                            adipiscing elit.</p>
                        <h4>
                            Title</h4>
                        <p>
                            Donec lacinia venenatis metus at bibendum? In hac habitasse platea dictumst. Proin
                            ac nibh rutrum lectus rhoncus eleifend. Sed porttitor pretium venenatis. Suspendisse
                            potenti. Aliquam quis ligula elit. Aliquam at orci ac neque semper dictum. Sed tincidunt
                            scelerisque ligula, et facilisis nulla hendrerit non. Suspendisse potenti. Pellentesque
                            non accumsan orci. Praesent at lacinia dolor. Lorem ipsum dolor sit amet, consectetur
                            adipiscing elit.</p>
                        <p>
                            Donec lacinia venenatis metus at bibendum? In hac habitasse platea dictumst. Proin
                            ac nibh rutrum lectus rhoncus eleifend. Sed porttitor pretium venenatis. Suspendisse
                            potenti. Aliquam quis ligula elit. Aliquam at orci ac neque semper dictum. Sed tincidunt
                            scelerisque ligula, et facilisis nulla hendrerit non. Suspendisse potenti. Pellentesque
                            non accumsan orci. Praesent at lacinia dolor. Lorem ipsum dolor sit amet, consectetur
                            adipiscing elit.</p>
                        <h4>
                            Title</h4>
                        <p>
                            Donec lacinia venenatis metus at bibendum? In hac habitasse platea dictumst. Proin
                            ac nibh rutrum lectus rhoncus eleifend. Sed porttitor pretium venenatis. Suspendisse
                            potenti. Aliquam quis ligula elit. Aliquam at orci ac neque semper dictum. Sed tincidunt
                            scelerisque ligula, et facilisis nulla hendrerit non. Suspendisse potenti. Pellentesque
                            non accumsan orci. Praesent at lacinia dolor. Lorem ipsum dolor sit amet, consectetur
                            adipiscing elit.</p>
                        <p>
                            Donec lacinia venenatis metus at bibendum? In hac habitasse platea dictumst. Proin
                            ac nibh rutrum lectus rhoncus eleifend. Sed porttitor pretium venenatis. Suspendisse
                            potenti. Aliquam quis ligula elit. Aliquam at orci ac neque semper dictum. Sed tincidunt
                            scelerisque ligula, et facilisis nulla hendrerit non. Suspendisse potenti. Pellentesque
                            non accumsan orci. Praesent at lacinia dolor. Lorem ipsum dolor sit amet, consectetur
                            adipiscing elit.</p>
                    </div>
                </div>
            </div>
        </div>
        -->
            <script src="../../../ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
            <script>                !window.jQuery && document.write(unescape('%3Cscript src="./js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
            <script src="./js/vendor/bootstrap.min.js"></script>
            <script src="./js/plugins.js"></script>
            <script src="./js/app.js"></script>
            <script src="./js/pages/login.js"></script>
            <script>                $(function () { Login.init(); });</script>
            <script>                var _gaq = _gaq || []; _gaq.push(["_setAccount", "UA-16158021-6"]), _gaq.push(["_setDomainName", "pixelcave.com"]), _gaq.push(["_trackPageview"]), function () { var t = document.createElement("script"); t.type = "text/javascript", t.async = !0, t.src = ("https:" == document.location.protocol ? "https://ssl" : "http://www") + ".google-analytics.com/ga.js"; var e = document.getElementsByTagName("script")[0]; e.parentNode.insertBefore(t, e) } ();</script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
