<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="playerRegAdmin2.aspx.cs" Inherits="eadmin_playerRegAdmin2" %>

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
                                        <div class="pull-right"><%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"   />--%></div>
                                         <div class="pull-right">
                                                 <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div>--%>
                                            </div>
                                
                                        </div>
                                        <div class="panel-body table-responsive">
                                            <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        
                                                        <th>Name</th>
                                                        <th>Mobile No</th>
                                                        <th>Email</th>
                                                        <th>Date</th>
                                                        <th>Safari Time:</th>
                                                        <th>Safari Zone</th>
                                                        <th>Safari Vehicle</th>
                                                        <th>Number Of Person</th>  
                                                    </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr>
                                                     
                                                        <th>Name</th>
                                                        <th>Mobile No</th>
                                                        <th>Email</th>
                                                        <th>Date</th>
                                                        <th>Safari Time:</th>
                                                        <th>Safari Zone</th>
                                                        <th>Safari Vehicle</th>
                                                        <th>Number Of Person</th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpTopOrer" runat="server" >
                                                        <ItemTemplate>
                                                    <tr>
                                                        <%--<td><asp:CheckBox ID="userid" runat="server" Text='<%# Eval("id") %>' /></td>--%>
                                                        
                                                        <td><%#Eval("name") %></td>
                                                        <td><%#Eval("Mobil_No") %></td>
                                                        <td><%#Eval("Email") %></td>
                                                        <td><%#Eval("Date") %></td>
                                                        <td><%#Eval("sazoncheck") %></td>
                                                        <td><%#Eval("sazoncheck2") %></td>
                                                        <td><%#Eval("sazoncheck4") %></td>
                                                        <td><%#Eval("noofPerson") %></td>
                                                        
                                                        <%--<td><a href="ranking_player.aspx?id=<%#Eval("id") %>" style="border: 2px solid chocolate;text-decoration: none;display: inherit;background: #f1ab7a;" > View Ranking </a> </td>--%>
                                                       
                                                         <%--<td><asp:Button ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>' CssClass="btn btn-sm btn-warning" Text="Edit" /></td>--%>
                                                    </tr>
                                                           
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
    </div>


    
</asp:Content>

