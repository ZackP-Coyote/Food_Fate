<%@ Page Title="" Language="C#" MasterPageFile="~/Food_Fate.Master" AutoEventWireup="true" CodeBehind="Main_Page.aspx.cs" Inherits="CSE4050Project.Main_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Searching for a place to eat?</h1>
    <div class="input-group">
        <asp:TextBox ID="TextBox1" runat="server" Placeholder="Enter ZIP Code"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Placeholder="Enter Address"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Filter" Value="None" />
            <asp:ListItem Text="Burgers" Value="Burgers" />
            <asp:ListItem Text="Japanese" Value="Japanese" />
            <asp:ListItem Text="Chinese" Value="Chinese" />
            <asp:ListItem Text="Mexican" Value="Mexican" />
            <asp:ListItem Text="Italian" Value="Italian" />
            <asp:ListItem Text="Thai" Value="Thai" />
        </asp:DropDownList>
        <asp:Button class="btn btn-primary" runat="server" Text="Search" OnClick="SearchButton"></asp:Button> <br />
    </div>
    
    

</asp:Content>
