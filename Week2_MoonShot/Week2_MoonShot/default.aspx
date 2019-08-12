<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Week2_MoonShot._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Go to the moon!</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="moonshot.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"> </script>
    <script src="Scripts/bootstrap.min.js"> </script>
</head>
<body>
    <header class="jumbotron">
        <h1>Moon Shot</h1>
    </header>
    <main>
        <form id="form1" runat="server">
            <div class="container">
                <div class="media">
                <img class="img-rounded img-responsive interstellar_img" alt="Earth, your oasis in space!" src="https://www.jpl.nasa.gov/visions-of-the-future/images/earth-small.jpg" />
                
                <div class="media-body">
                    <h5 class="mt-0 mb-1">How long will it take to get there?</h5>
    Every journey starts with a single step, or so they say. Some journeys might take longer than others depending on how many steps follow that first one. How long will it take to get to these destinations?
                </div>
                </div>
                    <div class="row">
                    <div class="col-md">Where do you want to go?</div>
                    <div class="col-md">
                        <asp:DropDownList ID="DestinationDdl" runat="server" ></asp:DropDownList>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md">How do you intend to travel?</div>
                    <div class="col-md">
                        <asp:DropDownList ID="SpeedDdl" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="CalculateButton" CssClass="btn-primary" runat="server" Text="Calculate How Long" OnClick="CalculateButton_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="ResultLabel" runat="server" Text="Calculate your travel time"></asp:Label>
                    </div>
                </div>
            </div>
        </form>
    </main>
</body>
</html>
