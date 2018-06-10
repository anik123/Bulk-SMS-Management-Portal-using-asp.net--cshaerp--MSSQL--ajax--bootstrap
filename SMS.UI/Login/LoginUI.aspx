<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="SMS.UI.Login.LoginUI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SMS ON BD</title>
    <!--STYLESHEETS-->
    <link href="~/Login/css/style.css" rel="stylesheet" type="text/css" />
    <!--SCRIPTS-->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.2.6/jquery.min.js"></script>
    <!--Slider-in icons-->
    <script type="text/javascript">
        $(document).ready(function () {
            binding();
        });
        function binding() {
            $(".username").focus(function () {
                $(".user-icon").css("left", "-48px");
            });
            $(".username").blur(function () {
                $(".user-icon").css("left", "0px");
            });

            $(".password").focus(function () {
                $(".pass-icon").css("left", "-48px");
            });
            $(".password").blur(function () {
                $(".pass-icon").css("left", "0px");
            });
        }
    </script>
    <link rel="stylesheet" type="text/css" href="../css/jquery.gritter.css" />
    <script type="text/javascript" src="http://www.google.com/jsapi"></script>
    <script type="text/javascript">        google.load('jquery', '1.7.1');</script>
    <script type="text/javascript" src="../js/jquery.gritter.js"></script>
    <script src="../js/abhi-pop.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load">
        <ContentTemplate>
            <!--WRAPPER-->
            <div id="wrapper">
                <!--SLIDE-IN ICONS-->
                <div class="user-icon">
                </div>
                <div class="pass-icon">
                </div>
                <!--END SLIDE-IN ICONS-->
                <!--LOGIN FORM-->
                <div name="login-form" class="login-form" action="" method="post">
                    <!--HEADER-->
                    <div class="header">
                        <!--TITLE-->
                        <h1>
                            <img src="../img/logo.png" />
                        </h1>
                        <!--END TITLE-->
                        <!--DESCRIPTION-->
                    </div>
                    <!--END HEADER-->
                    <!--CONTENT-->
                    <div class="content">
                        <!--USERNAME-->
                        <asp:TextBox ID="txtName" class="input username" placeholder="User Name" runat="server"></asp:TextBox>
                        <!--PASSWORD-->
                        <asp:TextBox ID="txtPass" class="input password" TextMode="Password" placeholder="Password"
                            runat="server"></asp:TextBox>
                    </div>
                    <!--END CONTENT-->
                    <!--FOOTER-->
                    <div class="footer">
                        <!--LOGIN BUTTON-->
                        <asp:Button ID="btnLogin" class="button" Text="Login" runat="server" OnClick="btnLogin_Click" />
                        <asp:Button ID="btnRegi" class="register" Text="Sign up" runat="server" 
                            onclick="btnRegi_Click" />
                    </div>
                    <!--END FOOTER-->
                </div>
                <!--END LOGIN FORM-->
            </div>
            <!--END WRAPPER-->
            <!--GRADIENT-->
            <div class="gradient">
            </div>
            <!--END GRADIENT-->
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        // Create the event handler for PageRequestManager.endRequest
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(binding);
    </script>
    </form>
</body>
</html>
