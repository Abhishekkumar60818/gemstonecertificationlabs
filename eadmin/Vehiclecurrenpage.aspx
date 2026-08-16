<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Vehiclecurrenpage.aspx.cs" Inherits="eadmin_Vehiclecurrenpage" %>

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
     <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3> Home Page Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab"> Table</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Upload </a>
                            </li>
                            
                           
                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All  Type</h4>
                              
                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                             Type
                                            <div class="pull-right"><asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"   /></div>
                                        </div>
                                        
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Name</th>
                                                                
                                                               <th>Edit</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                               <th>S.No</th>
                                                                <th>Name</th>
                                                                
                                                               <th>Edit</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpMedicineType" runat="server" OnItemCommand="rpMedicineType_ItemCommand">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td><asp:CheckBox ID="areaid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                        <td><%#Eval("name") %></td>                                                              
                                                                       
                                                                        <td>
                                                                              <asp:Button ID="btnEdit" runat="server" Text="Edit  " CommandArgument='<%# Eval("id") %>' CommandName="edit" CssClass="btn btn-warning btn-sm" />
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
                                      <asp:Panel ID="updatePanel" runat="server">
                                              <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Avengers Details
                                    </div>
                                    <div class="panel-body">
                                         <div class="col-md-6">
                                         <div class="form-group">
                                            <label>Name</label>
                                            <asp:TextBox ID="txtNameUp" runat="server" class="form-control"></asp:TextBox>
                                        </div>     
                                         
                                      <div class="form-group" style="display:none;">
                                            <label>Image</label>
                                          <asp:FileUpload ID="imageMedicineUp" runat="server" class="form-control" ></asp:FileUpload>
                                        </div>
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" onclick="btnUpdate_Click" 
                                                  />
                                              <asp:Button ID="btnCancel" class="btn btn-success" runat="server" Text="Cancel" onclick="btnCancel_Click" 
                                                  />
                                        </div>

                                </div>
                                        <div class="col=md-4">
                                            <img id="medicineImage" runat="server" />
                                        </div>
                                      
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
 
                                        </asp:Panel>
                                </div>


                            </div>





                            <div class="tab-pane fade" id="addnew">
                                <h4>Add photo</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                         Details
                                    </div>
                                    <div class="panel-body"> <div class="col-md-6">
                                   
                                    
                                         <div class="form-group">
                                            <label>Name</label>
                                            <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div> 
                                         <div class="form-group" style="display:none; ">
                                            <label>message</label>
                                            <asp:TextBox ID="txtMsg" runat="server" class="form-control"></asp:TextBox>
                                        </div> 
                                      <div class="form-group" style="display:none;">
                                            <label>Image</label>
                                          <asp:FileUpload ID="imageMedicine" runat="server" class="form-control"></asp:FileUpload>
                                        </div>
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Submit" onclick="btnUpload_Click" 
                                                  />
                                              <asp:Button ID="btnReset" class="btn btn-success" runat="server" Text="Cancel" onclick="btnReset_Click" 
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
    <asp:Literal ID="lblShowMessage" runat="server"></asp:Literal>
</asp:Content>

