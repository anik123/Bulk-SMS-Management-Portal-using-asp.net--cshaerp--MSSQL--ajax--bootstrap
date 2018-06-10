<%@ Page Title="" Language="C#" MasterPageFile="~/SMSUI.Master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="SMS.UI.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- subheader begin -->
    <div id="subheader">
        <div class="container">
            <div class="row">
                <div class="span12">
                    <h1>
                        Contact Us</h1>
                    <span>Lorem ipsum dolor sit amet</span>
                    <ul class="crumb">
                        <li><a href="index.html">Home</a></li>
                        <li class="sep">/</li>
                        <li>Contact Us</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- subheader close -->
    <div id="map-container">
        <iframe frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=envato&amp;aq=&amp;sll=23.730276,90.41664&amp;sspn=23.730276,90.41664&amp;ie=UTF8&amp;hq=envato&amp;hnear=&amp;radius=15000&amp;t=m&amp;z=13&amp;output=embed">
        </iframe>
    </div>
    <!-- content begin -->
    <div id="content">
        <div class="container">
            <div class="row">
                <div class="span8">
                    <h4>
                        Get in touch with us now!</h4>
                    Feel free to contact us by contact to get more information.<br />
                    <br />
                    <div class="contact_form_holder">
                        <form id="contact" class="row" name="form1" method="post" action="#" />
                        <div class="span4">
                            <label>
                                Name</label>
                            <input type="text" class="full" name="name" id="name" />
                        </div>
                        <div class="span4">
                            <label>
                                Email <span class="req">*</span></label>
                            <input type="text" class="full" name="email" id="email" />
                            <div id="error_email" class="error">
                                Please check your email</div>
                        </div>
                        <div class="span8">
                            <label>
                                Message <span class="req">*</span></label>
                            <textarea cols="10" rows="10" name="message" id="message" class="full"></textarea>
                            <div id="error_message" class="error">
                                Please check your message</div>
                            <div id="mail_success" class="success">
                                Thank you. Your message has been sent.</div>
                            <div id="mail_failed" class="error">
                                Error, email not sent</div>
                            <p id="btnsubmit">
                                <input type="submit" id="send" value="Send Now" class="btn btn-large" /></p>
                        </div>
                        </form>
                    </div>
                </div>
                <div id="sidebar" class="span3">
                    <!-- widget category -->
                    <!-- widget tags -->
                    <!-- widget text -->
                    <div class="widget widget-text">
                        <h4>
                            Our Address</h4>
                        <address>
                            100 Mainstreet Center, Sydney <span><strong>Phone:</strong>(208) 333 9296</span>
                            <span><strong>Fax:</strong>(208) 333 9298</span> <span><strong>Email:</strong><a
                                href="mailto:contact@example.com">contact@example.com</a></span> <span><strong>Web:</strong><a
                                    href="#test">http://example.com</a></span>
                        </address>
                    </div>
                </div>
            </div>
            <div class="map">
            </div>
        </div>
    </div>
</asp:Content>
