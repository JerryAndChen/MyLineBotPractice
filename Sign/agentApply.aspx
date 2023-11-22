<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="agentApply.aspx.cs" Inherits="Sign_agentApply" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="h_center">
        <caption>需求資訊</caption>
        <tr>
            <th>門市:</th>
            <td>
                <asp:TextBox ID="txtCity" runat="server" CssClass="field_RO" ReadOnly="true" />
                <asp:TextBox ID="txtDistrict" runat="server" CssClass="field_RO" ReadOnly="true" />
                <asp:TextBox ID="txtStore" runat="server" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th>地址:</th>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th>職務:</th>
            <td>
                <asp:TextBox ID="txtRole" runat="server" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th>名額:</th>
            <td>
                <asp:TextBox ID="txtRoleCnt" runat="server" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th>工作內容:</th>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th>日期起:</th>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th>日期迄:</th>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="送出申請" OnClick="btnSubmit_Click" CssClass="btn_main" />
            </td>
        </tr>
    </table>
</asp:Content>

