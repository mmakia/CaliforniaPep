<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="CaliforniaPep.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="CaliforniaPep.Models.Product" SelectMethod="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h4><%#:Item.ProductName %></h4>
            </div>
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.ImagePath %>" style="border: solid; height: 110px" alt="<%#:Item.ProductName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Sequence: </b><%#:Item.Sequence %>
                        <br />
                        <b>Molecular Weight: </b><%#:Item.MolecularWeight %>
                        <br />
                        <b>Catalog Number: </b><%#:Item.CatalogNumber %>
                        <br />
                        <span><b>Price: </b>&nbsp;<%#: String.Format("{0:f1}{1} For {2:c}", Item.Amount, Item.Unit, Item.UnitPrice) %></span>
                        <br />
                        <span><b>Category: </b>&nbsp;

                            
                                <asp:ListView ID="categoryList"
                                    ItemType="CaliforniaPep.Models.Category"
                                    runat="server"
                                    SelectMethod="GetCategories2">
                                    <EmptyDataTemplate>
                                        None
                                    </EmptyDataTemplate>

                                    <ItemTemplate>
                                        <b style="font-style: normal">
                                            <a href="/ProductList.aspx?id=<%#: Item.CategoryID %>">
                                                <%#: Item.CategoryName %>
                                            </a>
                                        </b>
                                    </ItemTemplate>
                                    <ItemSeparatorTemplate>,  </ItemSeparatorTemplate>
                                </asp:ListView>
                        </span>                        
                        <br />                        
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
