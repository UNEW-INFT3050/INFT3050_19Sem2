<%@ Page Title="" Language="C#" MasterPageFile="~/Interstellar.Master" AutoEventWireup="true" CodeBehind="Destination.aspx.cs" Inherits="Week8_InterstellarTravel.Destination" %>
<%--Contains information about a destination--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" >
        <div class="row">
            <div class ="col-md-6">
                <asp:Image CssClass="rounded" ID="destinationImg" runat="server" />
            </div>
            <div class="col-md-6">
                <h2><asp:Label ID="nameLabel" runat="server" Text="Label"></asp:Label></h2>
                <p><asp:Label ID="descriptionLabel" runat="server"></asp:Label></p>    
            </div>
        </div>
    </div>
</asp:Content>
