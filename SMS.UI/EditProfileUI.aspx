<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="EditProfileUI.aspx.cs" Inherits="SMS.UI.EditProfileUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="block">
                            <div class="form-horizontal form-bordered">
                                <div class="form-group form-actions">
                                    <div class="text-center">
                                        <strong>Edit Profile</strong>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="block">
                            <div class="form-horizontal form-bordered">
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        User Name
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="gi gi-user"></i></span>
                                            <asp:TextBox ID="txtUname" disabled="" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        Full Name
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-barcode"></i></span>
                                            <asp:TextBox ID="txtFullName" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-textarea-input" class="col-md-3 control-label">
                                        Adress</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtAddress" class="form-control" onchange="textcount(this.value.length);"
                                            onkeypress="return
                textcount(this.value.length);" TextMode="MultiLine" MaxLength="130" Style="width: 387px; height: 170px; resize: none;"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="block">
                            <div class="form-horizontal form-bordered">
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        Email
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                                            <asp:TextBox ID="txtEmail" disabled="" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3
                control-label">
                                        Phone
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="hi hi-earphone"></i></span>
                                            <asp:TextBox ID="txtPhone" disabled=""  class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3
                control-label">
                                        District
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="gi gi-table"></i></span>
                                            <asp:TextBox ID="txtDistrict" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3
                control-label">
                                        Postal Code
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="gi gi-fabric"></i></span>
                                            <asp:TextBox ID="txtPostal" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3
                control-label">
                                        Password
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="block">
                            <div class="form-horizontal form-bordered">
                                <div class="form-group form-actions">
                                    <div class="text-center">
                                        <asp:LinkButton CssClass="btn btn-sm btn-success" runat="server" ID="btnUpdate" 
                                            onclick="btnUpdate_Click"><i class="fa fa-angle-right"></i>&nbsp; <strong>Update</strong></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-sm btn-warning" runat="server" ID="btnReset" 
                                            onclick="btnReset_Click"><i class="fa fa-repeat"></i>&nbsp; <strong>Reset</strong></asp:LinkButton>
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
