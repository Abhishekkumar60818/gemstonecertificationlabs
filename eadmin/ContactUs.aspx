<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="eadmin_ContactUs" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <%--<div class="content-header">
        <div class="leftside-content-header">
            <ul class="breadcrumbs">
                <li><i class="fa fa-columns" aria-hidden="true"></i><a href="#">Home</a></li>
                <li><a>Board of Director </a>/<asp:Label ID="lblId" runat="server"></asp:Label></li>
            </ul>
        </div>
    </div>--%>
    <div class="col-sm-12">
        <div class="panel" style="margin-top: 15px;">
            <div class="panel-content">
                 <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                <asp:Label ID="lblchk" runat="server"></asp:Label>
                <div class="row" style="margin-top: 20px;padding-bottom: 15px;">
                    <div class="col-lg-10" style="text-align:center!important;"></div>
                    <div class="col-lg-2" style="text-align:center!important;">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update"  OnClick="btnUpdate_Click" CssClass="btn btn-block btn-outline btn-rounded btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

