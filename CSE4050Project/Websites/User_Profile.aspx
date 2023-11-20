﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Food_Fate.Master" AutoEventWireup="true" CodeBehind="User_Profile.aspx.cs" Inherits="CSE4050Project.Websites.User_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
    <div class="row">
        <!-- profile side -->
        <div class="col-md-5">
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
                                <h4>User Profile</h4>
                                <span> Account Status - </span>
                                <asp:Label class="badge rounded-pill text-bg-success" ID="Label1" 
                                    runat="server" Text="Your Status"></asp:Label>
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
                            <label>Email:</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>Old Password:</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" 
                                    runat="server" placeholder="Password" TextMode="Password" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Change Password:</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                            
                    </div>
                            <br />

                            <div class="d-grid gap-2 col-6 mx-auto">
                                <asp:Button class="btn btn-primary btn-block " ID="Button1" runat="server" Text="Update" />
                            </div>

                            <br />

                </div>
            </div>
            <a href="Main_Page.aspx">Back to Home</a>
            <br />
        </div>
    
        <!-- Favorite Resturants -->
        <div class="col-md-7">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="100px" src="../Images/generaluser.png" /> <!-- change later -->
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Favorite Resturants</h4>
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
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>