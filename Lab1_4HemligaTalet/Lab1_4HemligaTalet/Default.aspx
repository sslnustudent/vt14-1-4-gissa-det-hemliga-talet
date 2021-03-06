﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab1_4HemligaTalet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <h1>Gissa det hemliga talet</h1>
        <p>Ange ett tal mellan 1 och 100</p>
        <asp:TextBox ID="GuessTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="GuessTextBox" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange ett nummer mellan 1 och 100" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RangeValidator ControlToValidate="GuessTextBox" ID="RangeValidator1" runat="server" ErrorMessage="Ange ett nummer mellan 1 och 100" Type="Integer" MaximumValue="100" MinimumValue="1" Display="Dynamic"></asp:RangeValidator>
        <asp:Button ID="OkButton" runat="server" Text="Gissa" OnClick="OkButton_Click" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="NewButton" runat="server" Text="Ny" Visible="false" OnClick="NewButton_Click" />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
