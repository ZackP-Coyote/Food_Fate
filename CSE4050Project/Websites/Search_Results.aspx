<%@ Page Title="" Language="C#" MasterPageFile="~/Food_Fate.Master" AutoEventWireup="true" CodeBehind="Search_Results.aspx.cs" Inherits="CSE4050Project.Websites.Search_Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Search Again?</h1>
    <div class="input-group">
        <asp:TextBox ID="TextBox1" runat="server" Placeholder="Enter ZIP Code or Address"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Placeholder="Radius"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Text="Filter" Value="None" />
                <asp:ListItem Text="Burgers" Value="Burgers" />
                <asp:ListItem Text="Japanese" Value="Japanese" />
                <asp:ListItem Text="Chinese" Value="Chinese" />
                <asp:ListItem Text="Mexican" Value="Mexican" />
                <asp:ListItem Text="Italian" Value="Italian" />
                <asp:ListItem Text="Thai" Value="Thai" />
        </asp:DropDownList>
        <asp:Button class="btn btn-primary" runat="server" Text="Search" OnClick="SearchAgainButton"></asp:Button> <br />

     </div>
    
    
    
    <div class="row-md-12">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col">
                        <center>
                            <h2>
                                You're foods have been selected
                            </h2>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 border">
                        <center>
                            <h4>Resturants appear here</h4>
                        </center>
                    </div>

                    <div class="col-md-4 border">
                        <center>
                            <h4>Resturants appear here</h4>
                        </center>
                    </div>

                    <div class="col-md-4 border">
                        <center>
                            <h4>Resturants appear here</h4>
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
