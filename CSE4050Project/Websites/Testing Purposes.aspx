<%@ Page Title="" Language="C#" MasterPageFile="~/Food_Fate.Master" AutoEventWireup="true" CodeBehind="Testing Purposes.aspx.cs" Inherits="CSE4050Project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Testing </h1>

    <section>
    <div class="searching">
        <form method="get" class="search-bar">
            <div id="search-container">
                <input type="search"
                       id="search-input"
                       placeholder="Search for Fast Food..." />
                <button type="submit"><img src="../Images/search-circle-sharp.svg"/></button>
                
            </div>
        </form>
        <div class="searching-button">
            <br />
            <button type="button">Filters</button>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <button type="button">I'm Feeling Lucky!</button>
        </div>
    </div>
    </section>
</asp:Content>
