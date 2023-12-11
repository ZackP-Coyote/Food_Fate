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
                            <label>Enter Zip or City</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="ZipCity" runat="server" required="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-5">
                            
                            <label>Enter Max Radius in Miles</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="Radius" runat="server" required="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-2">
                            <label>Filters</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="Filters" runat="server">
                                    <asp:ListItem Text="None" Value="None" />
                                    <asp:ListItem Text="Burgers" Value="Burgers" />
                                    <asp:ListItem Text="Japanese" Value="Japanese" />
                                    <asp:ListItem Text="Chinese" Value="Chinese" />
                                    <asp:ListItem Text="Vietnamese" Value="Vietnamese" />
                                    <asp:ListItem Text="Thai" Value="Thai" />
                                    <asp:ListItem Text="Mexican" Value="Mexican" />
                                    <asp:ListItem Text="Italian" Value="Italian" />
                                    <asp:ListItem Text="Hot Dogs" Value="HotDogs" />
                                    <asp:ListItem Text="Donuts" Value="Donuts" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <br />

                        <div class="d-grid gap-2">
                            <br />
                            <asp:Button class="btn btn-primary" runat="server" Text="Search" OnClick="Redirect_Click"></asp:Button> <br />

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>
