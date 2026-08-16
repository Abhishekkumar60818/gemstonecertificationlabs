<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Advancepage.aspx.cs" Inherits="eadmin_Advancepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12">

                                <div class="Compose-Message">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Last 10 Orders
                                        
                                         <div class="pull-right">
                                                <%-- <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div>--%>
                                            </div>
                                
                                        </div>
                                        <div class="panel-body table-responsive">
                                            <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Id</th>
                                                        <th>Name</th>
                                                        <th>Gender</th>
                                                        <th>Nationalaity</th>
                                                        <th>Id Ref</th>
                                                        <th>Id Number</th>
                                                        
                                                    </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr>
                                                        <th>Id</th>
                                                        <th>Name</th>
                                                        <th>Gender</th>
                                                        <th>Nationalaity</th>
                                                        <th>Id Ref</th>
                                                        <th>Id Number</th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpTopOrer" runat="server" >
                                                        <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("id") %></td>
                                                        <td><%#Eval("Fullname") %></td>
                                                        <td><%#Eval("gender") %></td>
                                                       <%-- <td><img src="./eadmin//<%#Eval("Image") %>" width="72px" height="62px" /></td>--%>
                                                        <td><%#Eval("nationality") %></td>
                                                        <td><%#Eval("idproof") %></td>
                                                         <td><%#Eval("idnumber") %></td>
                                                    </tr>
                                                           <%-- <td><asp:Button ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>' CssClass="btn btn-sm btn-warning" Text="Edit" /></td>--%>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                   
                                                    
                                                  

                                                </tbody>
                                            </table>

                                        </div>
                                        <div class="panel-footer text-muted">
                                        </div>
                                    </div>
                                </div>
                            </div>
            </div>
        </div>
</asp:Content>

