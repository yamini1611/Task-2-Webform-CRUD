﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CRUD.aspx.cs" Inherits="Task_2.CRUD1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mb-4">CRUD Operations</h2>
        <div class="form-group">
            <label for="txtUserName">User Name:</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="txtUserID" runat="server" Visible="false"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="btn-group">
            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" CssClass="btn btn-secondary" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-info" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-danger" />
        </div>
        <hr />
        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="MyGridView_RowEditing" OnRowCancelingEdit="MyGridView_RowCancelingEdit" OnRowDeleting="MyGridView_RowDeleting" DataKeyNames="UserID">
            <Columns>
                <asp:TemplateField HeaderText="User Name">
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <div class="edit-delete-buttons">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-edit" ToolTip="Edit">
                               <i class="fas fa-edit"></i> Edit
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-delete" ToolTip="Delete">
                                <i class="fas fa-trash-alt"></i> Delete
                            </asp:LinkButton>
                            <!-- Hidden field for UserID -->
                            <asp:HiddenField ID="hiddenUserID" runat="server" Value='<%# Eval("UserID") %>' />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <style>
        .container {
            max-width: 800px;
            margin: auto;
            padding-top: 50px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .btn-group {
            margin-bottom: 20px;
        }

        .edit-delete-buttons .btn {
            margin-right: 5px;
        }

        .edit-delete-buttons .btn i {
            margin-right: 5px;
        }

        .edit-delete-buttons .btn-edit i {
            color: #007bff;
        }

        .edit-delete-buttons .btn-delete i {
            color: #dc3545;
        }
    </style>
</asp:Content>
