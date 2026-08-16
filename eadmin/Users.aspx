<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="eadmin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        <h3>User Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">All Users</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Add New User</a>
                            </li>


                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All Users</h4>

                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                               Users
                                             <div class="pull-right">
                                                 <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div>
                                            </div>

                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>User .No</th>
                                                                <th>Name</th>
                                                                <th>Shop Name</th>
                                                                <th>Mobile</th>
                                                                <th>Email</th>
                                                               <th>Password</th>
                                                                <th>User Type</th>
                                                                <th>Status</th>
                                                                <th>Edit</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                 <th>User .No</th>
                                                                <th>Name</th>
                                                                <th>Shop Name</th>
                                                                <th>Mobile</th>
                                                                <th>Email</th>
                                                               <th>Password</th>
                                                                <th>User Type</th>
                                                                <th>Status</th>
                                                                <th>Edit</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                             <asp:Repeater ID="rpUsers" runat="server" OnItemCommand="rpUsers_ItemCommand">
                                                                <ItemTemplate>
                                                                     <tr>
                                                                   <td><asp:CheckBox ID="userid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                    <td><%#Eval("name") %></td>
                                                                    <td><%#Eval("shopname") %></td>
                                                                    <td><%#Eval("mobile") %></td>
                                                                    <td><%#Eval("email") %></td>
                                                                          <td><%#Eval("epassword") %></td>
                                                                         <td><%#Eval("usertype") %></td>
                                                                         
                                                                    <td>
                                                                        <asp:DropDownList ID="cmbUserStatus" DataTextField="status" DataValueField="status" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbCustomerStatus_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">Block</asp:ListItem>
                                                                            <asp:ListItem Value="1">Active</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </td>
                                                                         <td><asp:Button ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>' CssClass="btn btn-sm btn-warning" Text="Edit" /></td>
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
                                                User Details For Update
                                            </div>
                                            <div class="panel-body">
                                               <div class="col-md-5">


                                            <div class="form-group">
                                                <label>Name</label>
                                                <asp:TextBox ID="txtNameUp" runat="server" class="form-control" placeholder="Name"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Shop Name</label>
                                                <asp:TextBox ID="txtShopNameUp" runat="server" class="form-control" placeholder="Shop Name"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Tin Number</label>
                                                <asp:TextBox ID="txtTinNumberUp" runat="server" class="form-control" placeholder="Tin Number"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Mobile</label>
                                                <asp:TextBox ID="txtMobileUp" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Email</label>
                                                <asp:TextBox ID="txtEmailUp" runat="server" class="form-control" placeholder="Email ID"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Password</label>
                                                <asp:TextBox ID="txtPasswordUp" runat="server" class="form-control" placeholder="Password"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Image</label>
                                                <asp:FileUpload ID="imageUp" runat="server" CssClass="form-control" />

                                            </div>

                                            <div class="form-group">

                                                <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Upload" OnClick="btnUpdate_Click"/>
                                                <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </div>



                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label>User Type</label>
                                                <asp:DropDownList ID="cmbUserTypeUp" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="Wholesale">Wholesale</asp:ListItem>
                                                    <asp:ListItem Value="Retailer">Retailer</asp:ListItem>
                                                     <asp:ListItem Value="admin">Admin</asp:ListItem>
                                                    <asp:ListItem Value="Normal">Normal</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                            <div class="form-group">
                                                <label>Reference</label>
                                                <asp:DropDownList ID="cmbReferenceUp" runat="server" CssClass="form-control">
                                                    
                                                </asp:DropDownList>

                                            </div>
                                            <div class="form-group">
                                                <label>State</label>
                                                <asp:TextBox ID="txtStateUp" runat="server" class="form-control" placeholder="State"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>City</label>
                                                <asp:TextBox ID="txtCityUp" runat="server" class="form-control" placeholder="State"></asp:TextBox>

                                            </div>
                                          
                                            <div class="form-group">
                                                <label>Address</label>
                                                <asp:TextBox ID="txtAddressUp" runat="server" class="form-control" TextMode="MultiLine" Rows="2" placeholder="Address"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Other Information</label>
                                                <asp:TextBox ID="txtOtherInfoUp" runat="server" class="form-control" TextMode="MultiLine" Rows="2" placeholder="Other Information"></asp:TextBox>

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
                                <h4>Add New User</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        User Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-5">


                                            <div class="form-group">
                                                <label>Name</label>
                                                <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Shop Name</label>
                                                <asp:TextBox ID="txtShopName" runat="server" class="form-control" placeholder="Shop Name"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Tin Number</label>
                                                <asp:TextBox ID="txtTinNumber" runat="server" class="form-control" placeholder="Tin Number"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Mobile</label>
                                                <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email ID"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Password</label>
                                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Image</label>
                                                <asp:FileUpload ID="ProfileImage" runat="server" CssClass="form-control" />

                                            </div>

                                            <div class="form-group">

                                                <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Upload" OnClick="btnUpload_Click"/>
                                                <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                            </div>



                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label>User Type</label>
                                                <asp:DropDownList ID="cmbUserType" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="Wholesale">Wholesale</asp:ListItem>
                                                    <asp:ListItem Value="Retailer">Retailer</asp:ListItem>
                                                     <asp:ListItem Value="admin">Admin</asp:ListItem>
                                                    <asp:ListItem Value="Normal">Normal</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                            <div class="form-group">
                                                <label>Reference</label>
                                                <asp:DropDownList ID="cmbReference" runat="server" CssClass="form-control">
                                                    <asp:ListItem>--Reference By--</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                            <div class="form-group">
                                                <label>State</label>
                                                <asp:TextBox ID="txtState" runat="server" class="form-control" placeholder="State"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>City</label>
                                                <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="State"></asp:TextBox>

                                            </div>
                                           
                                            <div class="form-group">
                                                <label>Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control" TextMode="MultiLine" Rows="2" placeholder="Address"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label>Other Information</label>
                                                <asp:TextBox ID="txtOtherOnfo" runat="server" class="form-control" TextMode="MultiLine" Rows="2" placeholder="Other Information"></asp:TextBox>

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

