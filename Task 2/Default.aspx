<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Task_2._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" SkinID="MyTheme">
    <main>
        <section class="jumbotron text-center">
            <div class="container">
                <h1>Welcome to Our Student Portal</h1>
                <p class="lead">Unlock your potential and reach for the stars.</p>
                <a href="#" class="btn btn-primary">Explore</a>
            </div>
        </section>

        <section class="features mt-5">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <h2>Study Tips</h2>
                        <p>"The expert in anything was once a beginner." - Helen Hayes</p>
                    </div>
                    <div class="col-md-4">
                        <h2>Inspiration</h2>
                        <p>"Education is the most powerful weapon which you can use to change the world." - Nelson Mandela</p>
                    </div>
                    <div class="col-md-4">
                        <h2>Success</h2>
                        <p>"Success is not final, failure is not fatal: It is the courage to continue that counts." - Winston Churchill</p>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
