<%@ Page Title="Register your interest to go!" Language="C#" MasterPageFile="~/Interstellar.Master" AutoEventWireup="true" CodeBehind="RegisterInterest.aspx.cs" Inherits="Week8_InterstellarTravel.RegisterInterest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ValidationSummary ID="validationSummary" CssClass="alert-danger" runat="server" HeaderText="Please correct these issues" />
    </div>
    <%--Text entry--%>
    <div class="form-group">
        <label class="control-label col-sm-3" for="nameText">Name: </label>

        <asp:TextBox ID="nameText" CssClass="form-control col-sm-5" runat="server"></asp:TextBox>
        <div class="form-text col-sm-4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="name required" ControlToValidate="nameText">Required</asp:RequiredFieldValidator>
        </div>
    </div>
    <%--Email entry--%>
    <div class="form-group">
        <label class="control-label col-sm-3" for="email1Text">Email Address: </label>

        <asp:TextBox ID="email1Text" CssClass="form-control col-sm-5" runat="server" TextMode="Email"></asp:TextBox>
        <div class="form-text col-sm-4">
            <asp:RequiredFieldValidator ID="Email1TextRequiredFieldValidator" runat="server" CssClass="text-danger" ErrorMessage="Email address required" ControlToValidate="email1Text">Required</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="text-danger" ErrorMessage="Must have a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email1Text"></asp:RegularExpressionValidator>
        </div>
    </div>
    <%--Email reentry--%>
    <div class="form-group">
        <label class="control-label col-sm-3" for="emailCompareText">Email Reentry: </label>

        <asp:TextBox ID="emailCompareText" CssClass="form-control col-sm-5" runat="server" TextMode="Email"></asp:TextBox>
        <div class="form-text col-sm-4">
            <asp:RequiredFieldValidator ID="emailCompareRequiredFieldValidator" runat="server" CssClass="text-danger" ErrorMessage="Email address copy required" ControlToValidate="Email1Text">Required</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="emailCompareValidator" runat="server" CssClass="text-danger" ErrorMessage="You must enter your email address twice to confirm" Operator="Equal" ControlToCompare="Email1Text" ControlToValidate="emailCompareText"></asp:CompareValidator>
        </div>
    </div>
    <%--Date to travel--%>
    <div class="form-group">
        <label class="control-label col-sm-3">Date: </label>

        <asp:TextBox ID="dateToGoText" CssClass="form-control col-sm-5" runat="server" TextMode="Date"></asp:TextBox>

        <div class="form-text col-sm-4">
            <asp:RequiredFieldValidator ID="dateToGoRequiredFieldValidator" runat="server" CssClass="text-danger" ErrorMessage="Travel date" ControlToValidate="dateToGoText">Required</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="dateToGoCompareValidator" runat="server" CssClass="text-danger" ErrorMessage="Must be after today" ControlToValidate="dateToGoText" Type="Date" Operator="GreaterThanEqual"> </asp:CompareValidator>
        </div>
    </div>
    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
</asp:Content>
