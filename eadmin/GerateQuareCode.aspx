<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="GerateQuareCode.aspx.cs" Inherits="eadmin_GerateQuareCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:Panel ID="panelMessage" runat="server">
    <div class="mydialog">
        <div class="row">
            <div class="col-md-12 text-center">
                <img width="150px" height="50px" style="margin-top:10px"  src="../img/log.png" />
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <h3>Task Completed</h3>

                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                       <asp:Button ID="btnCloseMessage" runat="server" Text="OK" CssClass="btn btn-success" OnClick="btnCloseMessage_Click" />

                    </div>

                </div>

            </div>
        </div>


    </div>
       </asp:Panel>


     <asp:Panel ID="panel1" runat="server">
    <div class="mydialog">
        <div class="row">
            <div class="col-md-12 text-center">
                <img width="150px" height="50px" style="margin-top:10px"  src="../img/log.png" />
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <h3>Sorry QR Code Alredy Exites</h3>

                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                       <asp:Button ID="Button2" runat="server" Text="OK" CssClass="btn btn-success" OnClick="btnCloseMessage_Click" />

                    </div>

                </div>

            </div>
        </div>


    </div>
       </asp:Panel>

     <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>QR Code Certificate</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">All Result</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Add QR Code </a>
                            </li>
                           
                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <%--<h4>All Slides</h4>--%>
                                
                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            QR Code 
                                             <div class="pull-right"><asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"   /></div>
                                        </div>
                                        
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                               <th>S.No</th>
                                                                <th>QR Code </th>
                                                                 <th>Certificate</th>
                                                                 <th>Certificate No</th>
                                                                <th>Download</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>QR Code </th>
                                                                 <th>Certificate</th>
                                                                <th>Certificate No</th>
                                                                <th>Download</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpSilder" runat="server" OnItemCommand="rpProduct_ItemCommand" OnItemDataBound="rpProduct_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                       
                                                                <td><asp:CheckBox ID="sliderid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                <td>
                                                                    <img width="150px" height="70px" class="img-responsive" src="qrimg/<%#Eval("imagename") %>" /></td>

                                                                          <td>
                                                                         <img width="150px" height="70px" class="img-responsive" src="slider/<%#Eval("imagename") %>" /></td>
                                                                         <td>


                                                                          <%#Eval("imagename") %>
                                                                        </td>
                                                              

                                                                        <td>
                                                                            <a href="qrimg/<%#Eval("link")  %>" download> Download</a>
                                                                        </td>
                                                              
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>



                                                        </tbody>
                                                    </table>
                                                </div>
                                                
                                            </div>
                                        
                                      
                                    </div>
                                    <!-- End  Hover Rows  -->
                                </asp:Panel>
                                      <asp:Panel ID="updatePanel" runat="server" style="display:none;">
                                              <div class="panel panel-default">
                                    <div class="panel-heading">
                                        certificate Details For Update
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                 <label>Site Section</label>
                                               <%-- <asp:DropDownList ID="cmbSiteSectionUp" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1">Main Site</asp:ListItem>
                                                   
                                                </asp:DropDownList>--%>
                                            </div>
                                            <div class="form-group">
                                            <label>Certificate Image  * 1400X855px </label>
                                           <asp:FileUpload ID="sliderUploadUp" runat="server" class="form-control" />
                                        </div>
                                     <%--<div class="form-group">
                                            <label>Offer</label>
                                            <asp:TextBox ID="txtOfferUp" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                     <div class="form-group">
                                            <label>About Offer</label>
                                           <asp:TextBox ID="txtAboutOfferUp" runat="server" class="form-control"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>certificate</label>
                                            <asp:TextBox ID="txtLinkUp" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>
                                         <div class="form-group" style="display:none;">
                                            <label>Is Visible ?</label>
                                             <asp:CheckBox ID="chkVisibleUp" Text="Do you want to display ?" class="form-control" runat="server" />
                                            
                                        </div>
                                      
                                     
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" onclick="btnUpdate_Click" />
                                              <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" 
                                                  />
                                        </div>

                                        </div>
                                       <div class="col-md-6">
                                            <div class="form-group">
                                            <label>Slider Image </label>
                                             <asp:Image CssClass="img-responsive" ID="sliderImage" runat="server" />
                                            
                                        </div>
                                       </div>
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
 
                                        </asp:Panel>
                                </div>


                            </div>





                            <div class="tab-pane fade" id="addnew">
                                <h4>Add Document</h4>
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Certificate Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-11">
                                            <div class="form-group" style="display:none;">
                                                 <label>Site Section</label>
                                                <asp:DropDownList ID="cmbSiteSection" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1">Main Site</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                            </div>
                                             <div class="form-group" style="display:none;">
                                            <label>Certificate Image * 1400X855px</label>
                                           <asp:FileUpload ID="sliderUpload" AllowMultiple="true" runat="server" class="form-control" />
                                        </div>
                                     <%--<div class="form-group">
                                            <label>heading</label>
                                            <asp:TextBox ID="txtOffer" runat="server" class="form-control"></asp:TextBox>
                                        </div>--%>
                                     <div class="form-group">
                                            <label>Certifitcate No QR Code</label>
                                           <asp:TextBox ID="txtAboutOffer" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                       <%-- <div class="form-group" style="display:none;">
                                            <label>URL</label>
                                            <asp:TextBox ID="txtUrl" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>--%>
                                         <div class="form-group" style="display:none;">
                                            <label>Is Visible ?</label>
                                             <asp:CheckBox ID="chkIsVisible" Text="Do you want to display ?" class="form-control" runat="server" />
                                            
                                        </div>
                                         <div class="form-group">

                                             <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Upload" onclick="btnUpload_Click"
                                                 />
                                              <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Reset" 
                                                  />
                                        </div>

                                    
                                        </div>
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
                               </div>
                            </div>



                          
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

