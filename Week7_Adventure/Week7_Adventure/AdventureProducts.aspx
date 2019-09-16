<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdventureProducts.aspx.cs" Inherits="Week7_Adventure.AdventureProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorksLT2016ConnectionString %>" 
        SelectCommand="SELECT Name, Color, StandardCost, ListPrice FROM SalesLT.Product"></asp:SqlDataSource>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ColorLabel" runat="server" Text='<%# Eval("Color") %>' />
                </td>
                <td>
                    <asp:Label ID="StandardCostLabel" runat="server" Text='<%# Eval("StandardCost") %>' />
                </td>
                <td>
                    <asp:Label ID="ListPriceLabel" runat="server" Text='<%# Eval("ListPrice") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ColorTextBox" runat="server" Text='<%# Bind("Color") %>' />
                </td>
                <td>
                    <asp:TextBox ID="StandardCostTextBox" runat="server" Text='<%# Bind("StandardCost") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ListPriceTextBox" runat="server" Text='<%# Bind("ListPrice") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ColorTextBox" runat="server" Text='<%# Bind("Color") %>' />
                </td>
                <td>
                    <asp:TextBox ID="StandardCostTextBox" runat="server" Text='<%# Bind("StandardCost") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ListPriceTextBox" runat="server" Text='<%# Bind("ListPrice") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ColorLabel" runat="server" Text='<%# Eval("Color") %>' />
                </td>
                <td>
                    <asp:Label ID="StandardCostLabel" runat="server" Text='<%# Eval("StandardCost") %>' />
                </td>
                <td>
                    <asp:Label ID="ListPriceLabel" runat="server" Text='<%# Eval("ListPrice") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">Name</th>
                                <th runat="server">Color</th>
                                <th runat="server">StandardCost</th>
                                <th runat="server">ListPrice</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ColorLabel" runat="server" Text='<%# Eval("Color") %>' />
                </td>
                <td>
                    <asp:Label ID="StandardCostLabel" runat="server" Text='<%# Eval("StandardCost") %>' />
                </td>
                <td>
                    <asp:Label ID="ListPriceLabel" runat="server" Text='<%# Eval("ListPrice") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
</asp:Content>
