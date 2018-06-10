<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="ViewAddressBook.aspx.cs" Inherits="SMS.UI.ViewAddressBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnUnload="UpdatePanel1_Unload">
        <ContentTemplate>
            <div id="page-content" style="min-height: 451px;">
                <div class="row">
                    <div class="col-md-10">
                        <div class="block full">
                            <div class="block-title">
                                <h2>
                                    <strong>View Contact List</strong></h2>
                            </div>
                            <div class="table-responsive">
                                <div role="grid" class="dataTables_wrapper" id="Div2">
                                    <div class="row">
                                        <div>
                                            <div id="example-datatable_length" class="col-lg-12">
                                                <div class="form-horizontal form-bordered">
                                                    <div class="form-group">
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="dopGroup" class="form-control" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="dopGroup_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="input-group">
                                                                <asp:Button ID="btnSend" CssClass="btn  btn-danger" OnClientClick="__doPostBack('btnSend','')"
                                                                    UseSubmitBehavior="false" runat="server" Text="Send" OnClick="btnSend_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <table class="table table-vcenter table-striped">
                                        <thead>
                                            <tr>
                                                <th class="text-center">
                                                    Group
                                                </th>
                                                <th class="text-center">
                                                    Contact Person
                                                </th>
                                                <th class="text-center">
                                                    ContactNumber
                                                </th>
                                                <th class="text-center">
                                                    Added On
                                                </th>
                                                <th class="text-center">
                                                    Action
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("groupname") %>'></asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("number") %>'></asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("date")) %>'></asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Button ID="btnSend" OnClick="Send_Btn_Click" CssClass="btn btn-xs btn-danger"
                                                                runat="server" Text="Send" />
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
