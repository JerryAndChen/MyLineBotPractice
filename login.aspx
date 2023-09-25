<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="assets/css/main.css" />
    <style>
        table{
            position:absolute;
            top:50%;
            left:50%;
            transform:translate(-50%,-50%); /*translate(X,Y)的百分比平移基準是物件本身*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="center">
        <tr>
            <td colspan="2" style="text-align:center">會員登入</td>
        </tr>
        <tr>
            <th>帳號:</th>
            <td>
                <asp:TextBox ID="txtAccount" runat="server" />
            </td>
        </tr>
        <tr>
            <th>密碼:</th>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click"/>
                </div>
                <div>
                    <asp:LinkButton ID="btnRegister" runat="server" Text="註冊" OnClick="btnRegister_Click"/>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

