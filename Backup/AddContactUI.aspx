﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="AddContactUI.aspx.cs" Inherits="SMS.UI.AddContactUI" %>

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
                                    <strong>Add Contact</strong>
                                </h2>
                            </div>
                            <div class="form-horizontal form-bordered">
                                <div class="form-group">
                                    <label for="example-select" class="col-md-3 control-label">
                                        Select Group</label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="hi hi-globe"></i></span>
                                            <asp:DropDownList ID="dopGroup" class="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        Contact Name
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="gi gi-user"></i></span>
                                            <asp:TextBox ID="txtName" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        Phone Number
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="gi gi-earphone"></i></span>
                                            <asp:TextBox ID="txtNumber" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-actions">
                                    <div class="col-md-9 col-md-offset-6">
                                        <asp:Button ID="btnAdd" class="btn btn-success" runat="server" Text="Add" OnClick="btnAdd_Click" />
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
