<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorinis2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet1.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Table ID="Table1" runat="server" GridLines="Both">
            </asp:Table>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:Table ID="Table2" runat="server" GridLines="Both">
            </asp:Table>

            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:Table ID="Table3" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <input type="time" id="start" name="start" runat="server"/>
            <input type="time" id="finish" name="finish" runat="server"/>
            <asp:DropDownList ID="DropDownList1"  runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ieškoti" />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <asp:Table ID="Table4" runat="server" GridLines="Both">
            </asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
