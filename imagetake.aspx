<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="imagetake.aspx.cs" Inherits="imagetake" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4 col-12 col-sm-12">
                 <asp:Repeater ID="rpthome" runat="server">
                    <ItemTemplate>

                       
                    <img class="img-responsive" src="./eadmin/slider/<%#Eval("imagename") %>" />
                        </ItemTemplate>
        </asp:Repeater>
            </div>
           
        </div>
    </div>
</asp:Content>

