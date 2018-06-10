<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="ViewGroupUI.aspx.cs" Inherits="SMS.UI.ViewGroupUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="page-content" style="min-height: 451px;">
                <div class="row">
                    <div class="col-md-6">
                        <div class="block full">
                            <div class="block-title">
                                <h2>
                                    <strong>View Group List</strong></h2>
                            </div>
                            <div class="table-responsive">
                                <div role="grid" class="dataTables_wrapper" id="Div2">
                                    <table class="table table-vcenter table-striped">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Group Name
                                                </th>
                                                <th class="text-center" style="width: 150px;">
                                                    Actions
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" Visible="false" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                            <asp:LinkButton Style="color: #000;" OnClick="LinkButton_Click" ID="LinkButton1"
                                                                runat="server" Text='<%# Eval("Name") %>'></asp:LinkButton>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:Button ID="Button1" OnClick="Send_Btn_Click" CssClass="btn btn-xs btn-danger"
                                                                    runat="server" Text="Send" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    <div class="row">
                                        <div class="col-sm-7 col-xs-12 clearfix">
                                            <div class="dataTables_paginate paging_bootstrap">
                                                <ul class="pagination pagination-sm remove-margin">
                                                    <asp:PlaceHolder ID="plcPaging" runat="server"></asp:PlaceHolder>
                                                </ul>
                                            </div>
                                        </div>
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
