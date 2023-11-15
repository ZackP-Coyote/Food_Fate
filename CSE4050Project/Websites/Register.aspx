<%@ Page Title="" Language="C#" MasterPageFile="~/Food_Fate.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CSE4050Project.Websites.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="row">
        <div class="col-md-8 mx-auto">
            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="100px" src="../Images/generaluser.png" />

                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>User Register</h4>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <label>Full Name:</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col">
                            <label>Enter Email:</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                            </div>

                            <label>Enter Password:</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>

                            <br />

                            <div class="d-grid gap-2 ">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
                            </div>

                            <br />

                        </div>
                    </div>


                </div>
            </div>

            <a href="Main_Page.aspx">Back to Home</a>
        </div>
    </div>
</div>


</asp:Content>
