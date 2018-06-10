<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="GroupSendSms.aspx.cs" Inherits="SMS.UI.GroupSendSms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function textcount(value) {
            // alert("hi");
            var count = 100 - value;
            document.getElementById("ContentPlaceHolder1_txtCount").value = count;
            if (count <= 0)
                return false;
            else
                return true;
        }
    </script>
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
                                    <strong>Send SMS</strong>
                                </h2>
                            </div>
                            <div class="form-horizontal form-bordered">
                                <div class="form-group">
                                    <label for="example-text-input" class="col-md-3 control-label">
                                        Group Name
                                    </label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="hi hi-globe"></i></span>
                                            <asp:TextBox ID="txtNumber" disabled="" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-textarea-input" class="col-md-3 control-label">
                                        Message</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtMsgBox" class="form-control" onchange="textcount(this.value.length);"
                                            onkeypress="return textcount(this.value.length);" TextMode="MultiLine" MaxLength="130"
                                            Style="width: 387px; height: 170px;" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                    </label>
                                    <div class="col-md-9">
                                        <p class="form-control-static">
                                            (Maximum characters: 100)You have
                                            <asp:TextBox ID="txtCount" ReadOnly="true" Width="50" MaxLength="3" Text="100" runat="server"></asp:TextBox>
                                        characters left.
                                    </div>
                                </div>
                                <div class="form-group form-actions">
                                    <div class="col-md-9 col-md-offset-6">
                                        <asp:Button ID="btnAdd" class="btn btn-success" runat="server" Text="Send" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Text="Clear" OnClick="btnReset_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HFGroupId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
