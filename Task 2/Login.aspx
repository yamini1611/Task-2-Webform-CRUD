<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Task_2.Login" MasterPageFile="~/Site.Master"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" 
    SkinID="skin.css">
    <div class="container">
        <h2 class="text-center mb-4">Login</h2>
        <div id="formstyle">
 <div class="form-group">
     <label for="txtUsername">Username:</label>
     <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." CssClass="text-danger" />
 </div>
 <div class="form-group">
     <label for="txtEmail">Email:</label>
     <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger" />
     <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger" />
 </div>
 <div class="form-group">
     <label for="txtPassword">Password:</label>
     <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." CssClass="text-danger" />
 </div>
 <div class="form-group">
     <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
 </div>
 <div>
     <h5>New User - <a href="Register.aspx">Register</a></h5>
 </div>
        </div>
       
    </div>
</asp:Content>
