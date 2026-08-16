<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contactus.aspx.cs" Inherits="Contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="agile-about w3ls-section text-center mb-50" id="about">
            <div class="container">
                <h1 class="heading-agileinfo">Contact Us</h1>
                <div class="center">
                    <img src="images/back.png" alt="" />
                </div>

                <div class="news-agileinfo">
                    <div class="news-w3row">
                        <div class="wthree-news-grids" style="margin-left: 10px;">
                            <img class="img-responsive pull-right" src="images/imgContact.png" width="550" style="margin: 10px 15px 0px 5px; font-size: 32px;" />
                           <%-- <p style="text-align: justify; font-size: 28px; margin: 10px 0px 0px 0px;">Better yet, see us in person!</p>
                            <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;">We love our customers, so feel free to visit during normal business hours.</p>--%>
                            <img src="images/logocontact.jpg" style="margin-right: 248px;" />
                            <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;"><strong></strong>
							
							Petlion Ka Rasta Johri Bazar<br />
                    Jaipur-302003, Rajasthan (INDIA)



</p>
                            <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;">Mobile: <strong>+91 9587092478</strong></p>
                            <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;">Web Site: <strong>www.globalgemtestinglab.com</strong></p>
                            <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;">E Mail: <strong>rgtlab@aliyun.com</strong></p>
                            <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;"></p>
                            <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;"></p>
                        </div>
                    </div>
                </div>

                <div class="container contact">
                    <div class="row">
                        <div class="col-md-3" style="background-color: #870100;">
                            <div class="contact-info">
                                <img src="images/contact-image.png" style="margin-top:20px" alt="image <span class=" glyphicon="" glyphicon-envelope"="">
                                <h2>Contact Us</h2>
                                <h4>We would love to hear from you !</h4>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="contact-form">
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="fname">First Name:</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="fname" placeholder="Enter First Name" name="fname" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="lname">Last Name:</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="lname" placeholder="Enter Last Name" name="lname" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="email">Email:</label>
                                    <div class="col-sm-10">
                                        <input type="email" class="form-control" id="email" placeholder="Enter email" name="email" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="comment">Message:</label>
                                    <div class="col-sm-10">
                                        <textarea class="form-control" rows="5" id="comment"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <button type="submit" class="btn btn-default">Submit</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

