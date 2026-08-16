<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="currentbooking.aspx.cs" Inherits="eadmin_currentbooking" %>

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
                                                        <th>Mobile No</th>
                                                        <th>Zone</th>
                                                        <th>Vehicle</th>
                                                        <th>Timing</th>
                                                        <th>Calendra</th>
                                                    </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr>
                                                        <th>Id</th>
                                                        <th>Name</th>
                                                        <th>Mobile No</th>
                                                        <th>Zone</th>
                                                        <th>Vehicle</th>
                                                        <th>Timing</th>
                                                        <th>Calendra</th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpTopOrer" runat="server" >
                                                        <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("id") %></td>
                                                        <td><%#Eval("Name") %></td>
                                                        <td><%#Eval("Number") %></td>
                                                       <%-- <td><img src="./eadmin//<%#Eval("Image") %>" width="72px" height="62px" /></td>--%>
                                                        <td><%#Eval("Zone") %></td>
                                                        <td><%#Eval("Vehicle") %></td>
                                                         <td><%#Eval("Timing") %></td>
                                                        <td><%#Eval("Calendra") %></td>
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

