<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Task_2.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" SkinID="MyTheme.skin">
    <div class="container">
        <h2 class="text-center mb-4">User Registration</h2>
                <div id="formstyle">

        <div class="form-group">
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            <!-- RequiredFieldValidator for Username -->
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." ValidationGroup="UserValidation" ForeColor="Red" />
        </div>
        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <!-- RequiredFieldValidator for Email -->
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ValidationGroup="UserValidation" ForeColor="Red" />
            <!-- RegularExpressionValidator for Email format -->
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." ValidationGroup="UserValidation" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ForeColor="Red" />
        </div>
        <div class="form-group">
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <!-- RequiredFieldValidator for Password -->
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ValidationGroup="UserValidation" ForeColor="Red" />
        </div>
        <div class="form-group">
            <label for="txtConfirmPassword">Confirm Password:</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <!-- RequiredFieldValidator for Confirm Password -->
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required." ValidationGroup="UserValidation" ForeColor="Red" />
            <!-- CompareValidator to match Confirm Password with Password -->
            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match." ValidationGroup="UserValidation" ForeColor="Red" />
        </div>
        <div class="btn-group">
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-primary" ValidationGroup="UserValidation" />
        </div>
                    <h5 >Already Having Account - <a href="Login.aspx">Login</a></h5>
        </div>

        <!-- Validation Summary to display all validation messages -->
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="UserValidation" ForeColor="Red" />
    </div>
</asp:Content>
