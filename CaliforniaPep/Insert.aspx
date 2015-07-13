<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="CaliforniaPep.Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="Button1" runat="server" Text="Insert From PageSource of Catalog page" OnClick="InsertFromPageSource_Click" />
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Insert from Url of Product" OnClick="InsertFromUrl_Click" />    
    <br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="400px" Width="594px" AutoPostBack="True"></asp:TextBox>       
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    
    

    
</asp:Content>
