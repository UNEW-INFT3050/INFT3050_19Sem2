<%@ Page Title="" Language="C#" MasterPageFile="~/Interstellar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Week8_InterstellarTravel.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater ID="ImageRepeater" runat="server">
                <ItemTemplate>

                    <div class="col-md-4">
                        <div class="img-thumbnail">
                            <asp:ImageButton ID="img1" CssClass="img-thumbnail" runat="server" ImageUrl='<%# Eval("ImagePath") %>'  OnCommand="img1_Command" CommandArgument='<%# Eval("Id") %>'/>
                            <div class="caption">
                                <h3 class="text-center"><%# Eval("Name")%></h3>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
