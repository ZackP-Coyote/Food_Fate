<%@ Page Title="" Language="C#" MasterPageFile="~/Food_Fate.Master" AutoEventWireup="true" CodeBehind="Main_Page.aspx.cs" Inherits="CSE4050Project.Main_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <div class="container">
        <div class="row-md-6 mx-auto">
            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <h1>Searching for a place to eat?</h1>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr /> <!-- adds a break line in between -->
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-5">
                            <label>Enter Zip or Address</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" required="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-5">
                            
                            <label>Enter Max Radius</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" required="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-2">
                            <label>Filters</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="None" Value="None" />
                                    <asp:ListItem Text="Burgers" Value="Burgers" />
                                    <asp:ListItem Text="Japanese" Value="Japanese" />
                                    <asp:ListItem Text="Chinese" Value="Chinese" />
                                    <asp:ListItem Text="Mexican" Value="Mexican" />
                                    <asp:ListItem Text="Italian" Value="Italian" />
                                    <asp:ListItem Text="Thai" Value="Thai" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <br />

                        <div class="d-grid gap-2">
                            <br />
                            <asp:Button class="btn btn-primary" runat="server" Text="Search" OnClick="Unnamed1_Click"></asp:Button> <br />

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>
