<%@ Page Title="" Language="C#" MasterPageFile="~/eadmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Salt.aspx.cs" Inherits="eadmin_Salt" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
                        <h3>Salt Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">All Salts</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Add Salt</a>
                            </li>
                            <li class=""><a href="#uploadExcel" data-toggle="tab">Upload Excel</a>
                            </li>
                            <li class=""><a href="#updateExcel" data-toggle="tab">Update Excel</a>
                            </li>
                           
                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All Salts</h4>
                              
                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Area
                                             <div class="pull-right"><asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div>
                                        </div>
                                        
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>name</th>
                                                                <th>Uses</th>
                                                                <th>How It Work</th>
                                                                <th>Common Side Effect</th>
                                                                <th>Expert Advice</th>
                                                               <th>Update</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                  <th>S.No</th>
                                                                <th>name</th>
                                                                <th>Uses</th>
                                                                <th>How It Work</th>
                                                                <th>Common Side Effect</th>
                                                                <th>Expert Advice</th>
                                                                <th>Update</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpSalt" runat="server" OnItemCommand="rpSalt_ItemCommand">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td><asp:CheckBox ID="areaid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                        <td><%#Eval("name") %></td>                                                                      
                                                                        <td><%#Eval("uses") %></td>
                                                                        <td><%#Eval("how_it_work") %></td>
                                                                        <td><%#Eval("common_side_effect") %></td>
                                                                        <td><%#Eval("expert_advice") %></td>
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
                                        Salt Details For Update
                                    </div>
                                    <div class="panel-body">
                                     <div class="col-md-6">
                                   
                                    
                                        <div class="form-group">
                                            <label>Salt Name</label>
                                            <asp:TextBox ID="txtNametUp" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>
                                     <div class="form-group">
                                                <label for="exampleInputEmail1">Product Uses</label>
                                                <CKEditor:CKEditorControl ID="txtProductUsesUp" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">How it Work</label>
                                                <CKEditor:CKEditorControl ID="txtHowItWorkUp" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                             
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" 
                                                 onclick="btnUpdate_Click" />
                                              <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancel" 
                                                 onclick="btnCancel_Click" />
                                        </div>

                                    
                                  
                                </div>
                                        <div class="col-md-6">
                                             <div class="form-group">
                                                <label for="exampleInputEmail1">Common Side Effect</label>
                                                <CKEditor:CKEditorControl ID="txtCommonSideEffectUp" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Expert Advice</label>
                                                <CKEditor:CKEditorControl ID="txtExpertAdviceUp" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
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
                                <h 4>Add Salt</h>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Salt Details
                                    </div>
                                    <div class="panel-body">
 <div class="col-md-6">
                                   
                                    
                                        <div class="form-group">
                                            <label>Salt Name</label>
                                            <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>
                                     <div class="form-group">
                                                <label for="exampleInputEmail1">Product Uses</label>
                                                <CKEditor:CKEditorControl ID="txtProductUses" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">How it Work</label>
                                                <CKEditor:CKEditorControl ID="txtHowitWork" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                             
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Upload" 
                                                 onclick="btnUpload_Click" />
                                              <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Text="Reset" 
                                                 onclick="btnReset_Click" />
                                        </div>

                                    
                                  
                                </div>
                                        <div class="col-md-6">
                                             <div class="form-group">
                                                <label for="exampleInputEmail1">Common Side Effect</label>
                                                <CKEditor:CKEditorControl ID="txtCommonSideEffect" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Expert Advice</label>
                                                <CKEditor:CKEditorControl ID="txtExpertAdvice" BasePath="~/eadmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                        </div>
                                      
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
                                
                            </div>



                            <div class="tab-pane fade" id="uploadExcel">
                                <h4>Upload All Areaes Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Area Upload
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Select Excel File </label>
                                                <asp:FileUpload ID="excelUpload" CssClass="form-control" runat="server" />

                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnUploadExcel" runat="server" Text="Upload Excel" CssClass="btn btn-success" OnClick="btnUploadExcel_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="tab-pane fade" id="updateExcel">
                                <h4>Update All Areaes Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Area Update
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                               
                                                <asp:Button ID="btnExcelExport" runat="server" Text="Export Excel File" OnClick="btnExcelExport_Click" CssClass="btn btn-success" />

                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Select Excel File</label>
                                                <asp:FileUpload ID="excelUpdate" CssClass="form-control" runat="server" />

                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnExcelUpdate" runat="server" Text="Update Excel" OnClick="btnExcelUpdate_Click" CssClass="btn btn-success" />
                                            </div>
                                        </div>
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

