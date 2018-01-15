<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="MX2.Manager.Page.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="grid"></asp:GridView>
            <asp:TextBox runat="server" ID="txtid"></asp:TextBox><br/>
            <asp:TextBox runat="server" ID="txt1"></asp:TextBox><br/>
            <asp:TextBox runat="server" ID="txt2"></asp:TextBox><br/>
            <asp:Button runat="server" ID="btn" Text="add" OnClick="btn_Click" />
            <asp:Button runat="server" ID="btnedit" Text="edit" OnClick="btnedit_Click"  />
            <asp:Button runat="server" ID="btndelete" Text="delete" OnClick="btndelete_Click"  />
            <asp:GridView runat="server" ID="grid2"></asp:GridView>
            <asp:Button runat="server" ID="btnfy" Text="fenye" OnClick="btnfy_Click" />
        </div>
    </form>
</body>
</html>
