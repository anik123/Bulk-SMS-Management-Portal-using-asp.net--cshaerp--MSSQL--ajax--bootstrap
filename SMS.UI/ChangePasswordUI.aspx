<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="ChangePasswordUI.aspx.cs" Inherits="SMS.UI.ChangePasswordUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="page-content">
                <div class="row">
                    <div class="col-md-6">
                        <div class="block">
                            <div class="block-title">
                                <h2>
                                    <strong>Change Password</strong>
                                </h2>
                            </div>
                            <div class="form-horizontal form-bordered">
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        Old Password
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-minus-circle"></i></span>
                                            <asp:TextBox ID="txtOldPass" TextMode="Password" MaxLength="50" class="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        New Password
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="txtNewPassword" TextMode="Password" MaxLength="50" class="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        Re-Password
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-reply"></i></span>
                                            <asp:TextBox ID="txtRetype" MaxLength="50" TextMode="Password" class="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-actions">
                                    <div class="text-center">
                                        <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Text="Clear" OnClick="btnReset_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
