<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="vehicleselected.aspx.cs" Inherits="eadmin_vehicleselected" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panelMessage" runat="server">
        <div class="mydialog">
            <div class="row">
                <div class="col-md-12 text-center">
                    <img width="150px" height="50px" style="margin-top: 10px" src="../img/log.png" />
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
                        <h3>Avenger Home Page Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">Table</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Upload </a>
                            </li>


                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All Medicine Type</h4>

                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                Medicine Type
                                            <div class="pull-right">
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                                            </div>
                                            </div>

                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Vehicle-Id</th>
                                                                <th>vehicle</th>
                                                                <th>seat</th>
                                                                <th>Rent</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Vehicle-Id</th>
                                                                <th>vehicle</th>
                                                                <th>seat</th>
                                                                <th>Rent</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpMedicineType" runat="server" OnItemCommand="rpMedicineType_ItemCommand">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CheckBox ID="areaid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                        <%--<td><%#Eval("catId") %></td>
                                                                        <td><%#Eval("SubcatId") %></td>--%>
                                                                        <td><%#Eval("productId") %></td>
                                                                        <td><%#Eval("product") %></td>
                                                                        <td><%#Eval("seat") %></td>
                                                                        <td><%#Eval("rent") %></td>
                                                                        <%-- <td>
                                                                            <img src="../eadmin/medicine/xlarge/<%#Eval("image")%>" width="80px" height="80px"></img></td>--%>

                                                                        <%--<td>
                                                                            <asp:Button ID="btnEdit" runat="server" Text="Edit  " CommandArgument='<%# Eval("id") %>' CommandName="edit" CssClass="btn btn-warning btn-sm" />
                                                                        </td>--%>
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
                                                        <label for="exampleInputEmail1">Category Name </label>
                                                        <asp:DropDownList ID="dropcatedit" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>sub-category</label>
                                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                                        <asp:DropDownList ID="dropsubcate" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>product</label>
                                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                                        <asp:DropDownList ID="dropproducte" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>sub-product</label>
                                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                                        <asp:DropDownList ID="dropsubproducte" runat="server" CssClass="form-control" />
                                                    </div>


                                                    <div class="form-group">
                                                        <label>Image</label>
                                                        <asp:FileUpload ID="imageMedicineUp" runat="server" class="form-control"></asp:FileUpload>
                                                    </div>

                                                    <div class="form-group">

                                                        <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                                        <asp:Button ID="btnCancel" class="btn btn-success" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
                                <asp:ScriptManager ID="ScriptManager" 
                               runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" 
                             UpdateMode="Conditional"
                             runat="server">
                <ContentTemplate>
                                    <h4>Add photo</h4>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Avenger Details
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label for="exampleInputEmail1">Category Name </label>
                                                    <asp:DropDownList ID="dropcat" AutoPostBack="true" OnTextChanged="dropcat_TextChanged" runat="server" CssClass="form-control" />
                                                </div>
                                                <div class="form-group">
                                                    <label>sub-category</label>
                                                    <%--<asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>--%>
                                                    <asp:DropDownList ID="dropsubcat" AutoPostBack="true" OnTextChanged="dropsubcat_TextChanged" runat="server" CssClass="form-control" />
                                                </div>
                                                <div class="form-group">
                                                    <label>product</label>

                                                    <asp:DropDownList ID="dropproduct" runat="server" CssClass="form-control" />
                                                </div>
                                                <div class="form-group">
                                                    <label>Vehicle Name</label>
                                                    <asp:TextBox ID="dropsubproduct" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <%--<asp:DropDownList ID="dropsubproduct" runat="server" CssClass="form-control" />--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>seat</label>
                                                    <asp:TextBox ID="txtseat" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <%--<asp:DropDownList ID="dropsubproduct" runat="server" CssClass="form-control" />--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Rent Vehicle</label>
                                                    <asp:TextBox ID="txtrent" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <%--<asp:DropDownList ID="dropsubproduct" runat="server" CssClass="form-control" />--%>
                                                </div>

                                               <%-- <div class="form-group">
                                                    <label>Image</label>
                                                    <asp:FileUpload ID="imageMedicine" runat="server" class="form-control"></asp:FileUpload>
                                                </div>--%>

                                                <div class="form-group">

                                                    <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Submit" OnClick="btnUpload_Click" />
                                                    <%--<asp:Button ID="btnReset" class="btn btn-success" runat="server" Text="Cancel" OnClick="btnReset_Click" />--%>
                                                </div>



                                            </div>

                                        </div>
                                        <div class="panel-footer text-muted">
                                        </div>
                                    </div>
                                </ContentTemplate>
            </asp:UpdatePanel>
                            </div>



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Literal ID="lblShowMessage" runat="server"></asp:Literal>
</asp:Content>

