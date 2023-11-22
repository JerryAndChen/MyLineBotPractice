<%@ Page Language="C#" AutoEventWireup="true" CodeFile="transfer.aspx.cs" Inherits="test_transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlCity" runat="server">
                <asp:ListItem Value="台北市"/>
                <asp:ListItem Value="新北市"/>
                <asp:ListItem Value="基隆市"/>
                <asp:ListItem Value="桃園市"/>
                <asp:ListItem Value="新竹縣"/>
                <asp:ListItem Value="新竹市"/>
                <asp:ListItem Value="苗栗縣"/>
                <asp:ListItem Value="台中市"/>
                <asp:ListItem Value="南投縣"/>
                <asp:ListItem Value="彰化縣"/>
                <asp:ListItem Value="雲林縣"/>
                <asp:ListItem Value="嘉義縣"/>
                <asp:ListItem Value="嘉義市"/>
                <asp:ListItem Value="台南市"/>
                <asp:ListItem Value="高雄市"/>
                <asp:ListItem Value="屏東縣"/>
                <asp:ListItem Value="宜蘭縣"/>
                <asp:ListItem Value="花蓮縣"/>
                <asp:ListItem Value="台東縣"/>
                <asp:ListItem Value="澎湖縣"/>
                <asp:ListItem Value="金門縣"/>
                <asp:ListItem Value="連江縣"/>
            </asp:DropDownList>
            <asp:Button ID="btnTransfer" runat="server" Text="轉換" OnClick="btnTransfer_Click" />
            <asp:Button ID="btnBatchTransfer" runat="server" Text="批次轉換" OnClick="btnTransfer_Click" />
        </div>
    </form>
</body>
</html>
