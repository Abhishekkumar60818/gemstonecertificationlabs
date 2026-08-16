<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Certificate.aspx.cs" Inherits="Certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <h3 class="heading-agileinfo">Certificates</h3>
            <div class="center">
                    <img src="images/back.png" alt="" />
                </div>
        </div>
         <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4 col-12">
            <p style="margin: 0px 0px 10px 0px;"><strong>Enter the Certificate ID</strong> in the box and click on <strong>View</strong><br /></p>
                    <div class="form-group mb-2">
                        <label for="certificate">Certificate ID</label>
                        <asp:TextBox ID="txtcertifid" runat="server"></asp:TextBox>
                        <%--<input type="text" class="form-control-plaintext" id="certificate" name="certificate" value="" />--%>
                    </div>
                    <%--<asp:Button ID="btncheck" runat="server" Text="view" OnClick="btncheck_Click"  CssClass="btn btn-primary mb-2"/>--%>
                <asp:LinkButton ID="btncheck" runat="server" Text="view" OnClick="btncheck_Click" OnClientClick="SetTarget();"  CssClass="btn btn-primary mb-2" />
            <div id="certpic" style="margin: 20px 0px 0px 0px;"></div>
                <p id="demo" style="visibility: hidden;"></p>
                <div class="clearfix"></div>
        </div>
        <div class="col-md-4"></div>
             <asp:Repeater ID="rpthome" runat="server">
                    <ItemTemplate>

                       <center> <a href="imagetake.aspx" target="_blank"><img  style="-webkit-user-select: none;margin: auto;cursor: zoom-in;background-color: hsl(0, 0%, 90%);transition: background-color 300ms;" target="_blank" src="./eadmin/slider/<%#Eval("imagename") %>" ></a></center>
    <%--<img src="" />--%>
                        </ItemTemplate>
        </asp:Repeater>
             </div>
    </div>
      <script type="text/javascript">
    function SetTarget() {
        document.forms[0].target = "_blank";
    }
      </script>
</asp:Content>

