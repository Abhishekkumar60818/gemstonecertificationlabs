<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://unpkg.com/boxicons@2.0.9/dist/boxicons.js"></script>
    <link href='https://unpkg.com/boxicons@2.0.9/css/boxicons.min.css' rel='stylesheet'>

     <script type="text/javascript">
    function SetTarget() {
        document.forms[0].target = "_blank";
    }
      </script>
    <style type="text/css">

       .bb{
width:100%; height:45px; border:none; line-height:45px; margin-top:10px;
       }
       
        .cc{


            border: 1px solid #600000;
    color: #fff;
    cursor: pointer;
    display: inline-block;
    font-size: 14px;
    font-weight: 700;
    margin-top: 10px;
    padding: 10px 20px;
    text-align: center;
    text-transform: uppercase;
    transition: all 0.4s ease 0s;
    z-index: 222;
    background: #600000;
    width: 150px;
    border-radius: 3px;
       } 
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" style="width: 100%; margin: 0 auto;">
        <div class="col-sm-12">
            <div id="my-slider" class="carousel slide" data-ride="carousel">
                <!-- Indicators dot nav -->
                <ol class="carousel-indicators">
                    <li style="margin: 0px 0px 0px 0px;" data-target="#my-slider" data-slide-to="0" class="active"></li>
                    <li style="margin: 0px 0px 0px 0px;" data-target="#my-slider" data-slide-to="1"></li>
                    <li style="margin: 0px 0px 0px 0px;" data-target="#my-slider" data-slide-to="2"></li>
                       <li style="margin: 0px 0px 0px 0px;" data-target="#my-slider" data-slide-to="3"></li>
                       <li style="margin: 0px 0px 0px 0px;" data-target="#my-slider" data-slide-to="4"></li>
                </ol>
                <!-- wrapper for slide -->
                <div class="carousel-inner" role="listbox">
                    
                    <div class="item active">
                        <img src="images/2.png" style="width: 100%; height: 50%;">
                        <%--<img src="images/banner2.png" alt="painting" style="width: 100%; height: 100%;" />--%>
                        <div class="carousel-caption">
                            <h2 style="margin: 80px 0px 0px 0px;"></h2>
                        </div>
                    </div>
                    <div class="item">
                        <img src="images/3.png" style="width: 100%; height: 50%;">
                        <%--<img src="images/banner3.png" alt="painting" style="width: 100%; height: 100%;" />--%>
                        <div class="carousel-caption">
                            <h2 style="margin: 80px 0px 0px 0px;"></h2>
                        </div>
                    </div>
                    <div class="item">
                        <img src="images/1.png" style="width: 100%; height: 50%;">
                        <%--<img src="images/banner3.png" alt="painting" style="width: 100%; height: 100%;" />--%>
                        <div class="carousel-caption">
                            <h2 style="margin: 80px 0px 0px 0px;"></h2>
                        </div>
                    </div>
                     <div class="item">
                        <img src="images/4.png" style="width: 100%; height: 50%;">
                        <%--<img src="images/banner3.png" alt="painting" style="width: 100%; height: 100%;" />--%>
                        <div class="carousel-caption">
                            <h2 style="margin: 80px 0px 0px 0px;"></h2>
                        </div>
                    </div>

                     <div class="item">
                        <img src="images/5.png" style="width: 100%; height: 50%;">
                        <%--<img src="images/banner3.png" alt="painting" style="width: 100%; height: 100%;" />--%>
                        <div class="carousel-caption">
                            <h2 style="margin: 80px 0px 0px 0px;"></h2>
                        </div>
                    </div>
                  
                   
                  
                     
                </div>

                <!-- controls for prev and next buttons -->
                <a class="left carousel-control" href="#my-slider" role="button" data-slide="prev" style="margin: 10px 0px 0px 0px;">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#my-slider" role="button" data-slide="next" style="margin: 10px 0px 0px 0px;">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    </div>
    <div class="agile-about w3ls-section text-center mb-50" id="about">
        <div class="container">
           
          
            <div class="banner-area" style="background:#e2c37b;margin-top: -43px">
        <div class="container">
            <div class="row">
               
               
               
                <div class="col-md-3 col-sm-12 col-xs-12">
                    <div class="banner-content">
                        <h4 style="margin-bottom: 0;
    text-align: center;
    color: #fff;
    font-size: 22px;
    font-weight: 600;
    line-height: 60px;">Verify Your Certificate</h4>
                    </div>
                </div>
                
                 <div class="col-md-6 col-sm-12 col-xs-12">
                 
                    

                      <asp:TextBox ID="txtcertifid" runat="server" placeholder="GCL15347" class="form-control bb" ></asp:TextBox>

                   
                </div>
                        
                <div class="col-md-3 col-sm-12 col-xs-12">
                   

                    


                      <asp:LinkButton ID="btncheck" runat="server" Text="view" OnClick="btncheck_Click" OnClientClick="SetTarget();"  CssClass="ready-btn left-btn cc" />

                  	<footer class="notification-box"></footer>
                </div>
                
                
                
               
                
                
                
                
            </div>
        </div>
    </div>

            <br />
            <br />


            <h1 class="heading-agileinfo">GEMSTONE CERTIFICATION LAB</h1>

            <div class="center">
                <img src="images/back.png" alt="" />
            </div>
            <div class="agileits-about-grid">
                <p style="text-align: justify; font-size: 28px; margin: 0px 0px 0px 0px;"><strong></strong></p>
                <div class="well" style=" font-size: 20px; color: #fff; margin: 0px 0px 0px 0px;background-color:#530606">
                    (GEMSTONE CERTIFICATION LAB) GEMSTONE CERTIFICATION LAB Is A Nonprofit Organization Dedicated To Research In The Field Of Gemology.<br />
                    <br />
                    GEMSTONE CERTIFICATION LAB Is To Protect All Buyers And Sellers Of Gemstones By Setting And Maintaining The Standards Used To Evaluate Gemstone Quality.<br />
                    <br />
                    An GEMSTONE CERTIFICATION LAB Certificate Clearly Discloses The Details Of Any Item It Accompanies, Providing Confidence For Both Buyer And Seller.<br />
                    <br />
                    Jaipur, Over The Years Has Been One Of The Main Trade Center For Gems And Jewellery.<br />
                </div>
            </div>
        </div>
    </div>
    <div class="container" style="margin-top: -50px;">
        <div class="news-w3row">
            <div class="wthree-news-grids" style="margin-left: 10px;">
                <strong></strong>
                <img class="img-responsive pull-left" src="images/machineOne.png" width="550" style="margin: 10px 10px 0px 0px;" />
                <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;">The GEMSTONE CERTIFICATION LAB Report is based on a precious stone analysis, which is designed to identify the species and variety of a colored Gemstone.</p>
                <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;">
                    GEMSTONE CERTIFICATION LAB Report clearly states whether the stone is natural or synthetic, provides other data describing its shape, cut, weight, measurements, color, transparency and major optical characteristics,
                        and also includes a detailed photograph of the stone.
                </p>
                <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;">
                    GEMSTONE CERTIFICATION LAB. We are providing Services for Gemstone Identification, Gemstone Treatment Identification, Gemstone Origin Identification, Diamond Grading and Diamond Grading for Jewellery Items. In all
                        our services we are maintaining the international standards. GEMSTONE CERTIFICATION LAB is a Jaipur based Indian Gem Testing Lab Company. Started with a mission to give services to it's customers in Gems &
                        Jewellery Industry.
                </p>

                <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;"></p>
                <p style="text-align: justify; font-size: 18px; margin: 10px 0px 0px 0px;"></p>
            </div>
        </div>

        <img src="images/last.jpeg" style="width: 100%;
    margin-top: 20px;
    margin-bottom: 20px;
    margin-left: 14px;" />
    </div>
</asp:Content>

