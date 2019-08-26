<%@ Page Title="" Language="C#" MasterPageFile="~/Interstellar.Master" AutoEventWireup="true" CodeBehind="Destinations.aspx.cs" Inherits="Week5_InterstellarTravel.Destinations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlacement" runat="server">
    Go to a variety of interesting destinations
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Object data source allows us to connect to a 'business object' - basically a class which returns an IEnumerable or similar--%>
    <asp:ObjectDataSource ID="destinationDataSource" runat="server" SelectMethod="GetDestinations" TypeName="Week5_InterstellarTravel.DAL.DummyDB"></asp:ObjectDataSource>
    
    <%-- Gridview allows us to quickly and easily show items from a data source in a tablular form--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="destinationDataSource">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:ImageField DataImageUrlField="ImagePath" ControlStyle-CssClass="destination_thumb">
            </asp:ImageField>
            <asp:BoundField DataField="ShortDescription" HeaderText="Description" SortExpression="ShortDescription" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="DistanceInKm" HeaderText="DistanceInKm" SortExpression="DistanceInKm" />
        </Columns>
    </asp:GridView>
</asp:Content>
