<%@ Page Title="" Language="C#" MasterPageFile="~/SMSPANEL.Master" AutoEventWireup="true"
    CodeBehind="SMSPackage.aspx.cs" Inherits="SMS.UI.SMSPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content" style="min-height: 314px;">
        <div class="block full">
            <div class="block-title">
                <h1>
                    <strong>Packages</strong></h1>
            </div>
            <div class="tab-content">
                <div id="pt-grid-based" class="tab-pane active">
                    <div class="row">
                        <div class="col-sm-3">
                            <table class="table table-borderless table-pricing table-featured">
                                <thead>
                                    <tr>
                                        <th class="table-featured">
                                            <i class="fa fa-cloud-download"></i>Personal
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <strong>10GB</strong> Downloads
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table-price">
                                            <h1>
                                                - FREE -<br>
                                                <small><i class="fa fa-gift text-primary"></i></small>
                                            </h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a class="btn btn-success" id="add-regular" href="javascript:void(0)"><i class="fa fa-angle-right">
                                            </i>Add To Cart <i class="fa fa-angle-left"></i></a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-sm-3">
                            <table class="table table-borderless table-pricing table-featured">
                                <thead>
                                    <tr>
                                        <th class="table-featured">
                                            <i class="fa fa-cloud-download"></i>Business
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <strong>100GB</strong> Downloads
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table-price">
                                            <h1>
                                                $9<br>
                                                <small>per month</small></h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a class="btn btn-success" onclick="popup('Error','hi')" href="javascript:void(0)"><i
                                                class="fa fa-angle-right"></i>Get Started <i class="fa fa-angle-left"></i></a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-sm-3">
                            <table class="table table-borderless table-pricing table-featured">
                                <thead>
                                    <tr>
                                        <th class="table-featured">
                                            <i class="fa fa-cloud-download"></i>VIP
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <strong>1TB</strong> Downloads
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table-price">
                                            <h1>
                                                $19<br>
                                                <small>per month</small></h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a class="btn btn-success" href="javascript:void(0)"><i class="fa fa-angle-right"></i>
                                                Get Started <i class="fa fa-angle-left"></i></a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-sm-3">
                            <table class="table table-borderless table-pricing table-featured">
                                <thead>
                                    <tr>
                                        <th class="table-featured">
                                            <i class="fa fa-cloud-download"></i>Pro
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <strong>Unlimited</strong> Downloads
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table-price">
                                            <h1>
                                                $29<br>
                                                <small>per month</small></h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a class="btn btn-success" href="javascript:void(0)"><i class="fa fa-angle-right"></i>
                                                Get Started <i class="fa fa-angle-left"></i></a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
      

       
    </script>
</asp:Content>
