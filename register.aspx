<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        table{
            position:absolute;
            top:50%;
            left:50%;
            transform:translate(-50%,-50%);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <caption>資料登入</caption>
        <tr>
            <th>姓名:</th>
            <td>
                <asp:TextBox ID="txtName" runat="server" />
            </td>
        </tr>
        <tr>
            <th>性別:</th>
            <td>
                <asp:RadioButton ID="rdSexType1" GroupName="sexType" runat="server" Text="男" Checked="true"/>
                <asp:RadioButton ID="rdSexType2" GroupName="sexType" runat="server" Text="女" />
            </td>
        </tr>
        <tr>
            <th>生日:</th>
            <td>
                <asp:TextBox ID="txtBirth" runat="server" />
            </td>
        </tr>
        <tr>
            <th>手機:</th>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" />
            </td>
        </tr>
        <tr>
            <th>Email:</th>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="確定送出" />
            </td>
        </tr>
    </table>
</asp:Content>

