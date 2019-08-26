<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="Week4_Registration1.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>Week 4: Register your interest</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"> </script>
    <script src="Scripts/bootstrap.min.js"> </script>
</head>
<body>
    <header class="jumbotron">
        <h1>Moon Shot</h1>
    </header>
    <main>
        <form id="form1" runat="server">
            <div>Register your interest</div>
            <%-- Validation summary --%>
            <div>
                <asp:ValidationSummary ID="validationSummary" CssClass="alert-danger" runat="server" HeaderText="Please correct these issues" />
            </div>
 
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                <asp:TextBox ID="nameText" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="nameTextRequiredFieldValidator" runat="server" CssClass="text-danger" ErrorMessage="name required" ControlToValidate="nameText">Required</asp:RequiredFieldValidator>
                
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="emailText" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="emailTextRequiredFieldValidator" runat="server" CssClass="text-danger" ErrorMessage="Email required" ControlToValidate="emailText"> Reqired</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="emailTextRegularExpressionValidator" runat="server" CssClass="text-danger" ErrorMessage="Email in incorrect format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailText"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Reenter Email:"></asp:Label>
                <asp:TextBox ID="emailCompareText" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="emailCompareRequiredFieldValidator" runat="server" CssClass="text-danger" ErrorMessage="Email address copy required" ControlToValidate="emailCompareText">Required</asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="emailCompareValidator" runat="server" CssClass="text-danger" ErrorMessage="You must enter your email address twice to confirm" Operator="Equal" ControlToCompare="emailText" ControlToValidate="emailCompareText"></asp:CompareValidator>
                
            </div>
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="SubmitButton_Click" />
            </div>
            <asp:Label ID="resultLabel" runat="server" Text="Enter your data"></asp:Label>
        </form>
    </main>
</body>
</html>
