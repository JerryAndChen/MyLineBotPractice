<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cfgUser.aspx.cs" Inherits="cfgUser" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="h_center">
        <caption>個人資料設定</caption>
        <tr>
            <th>姓名:</th>
            <td>
                <asp:TextBox ID="txtName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" ErrorMessage="姓名不可為空" />
            </td>
        </tr>
        <tr>
            <th>性別:</th>
            <td>
                <asp:RadioButtonList ID="rdSexType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Text="男" Value="1" Selected="True" />
                    <asp:ListItem Text="女" Value="2" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th>生日:</th>
            <td>
                <asp:TextBox ID="txtBirth" runat="server" onclick="showCalendar();" />
                <asp:RequiredFieldValidator ID="rfvBirth" runat="server" ControlToValidate="txtBirth" Display="Dynamic" ForeColor="Red" ErrorMessage="日期不可為空" />
                <asp:RegularExpressionValidator ID="revBirth" runat="server" ControlToValidate="txtBirth" ValidationExpression="^(19|20)[0-9]{2}\-(0(?:[0-9])|1(?:[0-2]))\-(0(?:[1-9])|[1-2](?:[0-9])|3(?:[01]))$" Display="Dynamic" ForeColor="Red" ErrorMessage="日期格式不正確" />
            </td>
        </tr>
        <tr>
            <th>手機:</th>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" />
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" ErrorMessage="手機不可為空" />
                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^09[0-9]{8}$" Display="Dynamic"  ForeColor="Red" ErrorMessage="手機格式不正確" />
            </td>
        </tr>
        <tr>
            <th>Email:</th>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"/>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^(\w+([\.\-]\w+)*)@\w+(\-\w+)*(\.\w{2,})+$" Display="Dynamic" ForeColor="Red" ErrorMessage="Email格式不正確" />
            </td>
        </tr>
        <tr>
            <th>角色:</th>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server" >
                    <asp:ListItem Text="店長" Value="1" />
                    <asp:ListItem Text="員工" Value="2" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>所屬門市:</th>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_Change" />
                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_Change" />
                <asp:DropDownList ID="ddlStore" runat="server" />
                <%--<asp:TextBox ID="txtAddress" runat="server" />--%>
            </td>
        </tr>
        <tr>
            <th>履歷表:</th>
            <td>
                <asp:Button ID="btnUpload" runat="server" Text="上傳履歷表" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="確認修改" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

