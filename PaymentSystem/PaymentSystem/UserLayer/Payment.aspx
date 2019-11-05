<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayer/PaymentSystem.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="PaymentSystem.UserLayer.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
       <label for="PaymentSystem_AmountText">Amount:</label>
       <div><asp:Label ID="AmountText" runat="server" Text="20.00"/></div>  
       <label for="PaymentSystem_NameText">Name:</label>
       <div><asp:TextBox ID="NameText" runat="server" Text="Arthur Anderson"/></div>  
       <label for="PaymentSystem_NumberText">Name:</label>
       <div><asp:TextBox ID="NumberText" runat="server" Text="4444333322221111" /></div>  
       <label for="PaymentSystem_ExpiryText">Expiry:</label>
       <div><asp:TextBox ID="ExpiryText" runat="server" Text="2020-11" TextMode="Month"/></div>  
       <label for="PaymentSystem_CVCText">Expiry:</label>
       <div><asp:TextBox ID="CVCText" runat="server" Text="123"/></div>  
    </div>
    <div>
        <asp:Button ID="PaymentButton" Text="Make payment" runat="server" OnClick="PaymentButton_Click"/>
    </div>
</asp:Content>
