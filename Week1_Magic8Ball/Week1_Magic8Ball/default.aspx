<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Week1_Magic8Ball._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Magic 8 Ball</title>
    <link href="magic8ball.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <br />
            <asp:Button ID="queryButton" CssClass="inputbutton" runat="server" OnClick="Button1_Click" Text="Make my decision!" />
            <asp:Label ID="responseLabel" CssClass="answer" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
