<%@ Page Title="" Language="C#" MasterPageFile="~/Food_Fate.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CSE4050Project.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="../Images/generaluser.png" />

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Login</h3>
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
                                <label>Enter Email:</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Email"></asp:TextBox>
                                </div>
                                <label>Enter Password:</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <br />

                                <div class="d-grid gap-2 ">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>

                                <br />

                                <div class="d-grid gap-2">
                                    <a href="Register.aspx"> <input class="btn btn-info btn-block btn-lg" id="Button2" 
                                        type="button" value="Register" /> </a>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>

                <a href="Main_Page.aspx">Back to Home</a>
            </div>
        </div>
    </div>

</asp:Content>
