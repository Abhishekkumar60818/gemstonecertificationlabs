<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Dashboard</h3> 

                    </div>
                    <div class="panel-body">
                        <div class="row">
                         <%--   <div class="col-md-4">
                                <div class="notice-board">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Lifetime Sales
                                <div class="pull-right">
                                    <div class="dropdown">
                                        <button class="btn btn-success dropdown-toggle btn-xs" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-expanded="true">
                                            <span class="glyphicon glyphicon-cog"></span>
                                            <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Refresh</a></li>
                                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Logout</a></li>
                                        </ul>
                                    </div>
                                </div>
                                        </div>
                                        <div class="panel-body text-center">
                                            Rs. 0/-
                                        </div>
                                        <div class="panel-footer">
                                            Average Orders
                                        </div>
                                        <div class="panel-body text-center">
                                            Rs. 0/-
                                        </div>
                                    </div>
                                </div>
                                

                            </div>--%>
                            
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Literal ID="lblShowMessage" runat="server"></asp:Literal>
</asp:Content>

