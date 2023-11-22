<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="agentForm.aspx.cs" Inherits="Sign_agentForm" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="/assets/css/dialog.css" />
    <script type="text/javascript" src="/assets/js/dialog.js"></script>
    <script>
        var selectedDate;
        function showCalendar(obj) {
            selectedDate = obj;
            showDialog(200, 230, "../Shared/Calendar.aspx");
        }
        function selectDate(value) {
            selectedDate.value = value;
            closeDialog();
        }
        function createSuccess(msg) {
            liff_sendMessages(msg)
                .then((log) => {
                    console.log(log);
                    showMsgAndGoto("新增成功", "../index.aspx");
                })
                .catch((e) => console.log(e));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="h_center">
        <caption>新增人力需求</caption>
        <tr>
            <th>所屬門市:</th>
            <td>
                <asp:TextBox ID="txtCity" runat="server" CssClass="field_RO" ReadOnly="true" />
                <asp:TextBox ID="txtDistrict" runat="server" CssClass="field_RO" ReadOnly="true" />
                <asp:TextBox ID="txtStore" runat="server" CssClass="field_RO" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th class="require">標題:</th>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" />
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="標題不可為空" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <th class="require">職務:</th>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server" >
                    <asp:ListItem Text="店長" Value="1" />
                    <asp:ListItem Text="員工" Value="2" Selected="True" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlRoleCnt" runat="server" />名
            </td>
        </tr>
        <tr>
            <th>工作內容:</th>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" />
            </td>
        </tr>
        <tr>
            <th class="require">日期起:</th>
            <td>
                <asp:TextBox ID="txtStartD" runat="server" onclick="showCalendar(this);" />
                <asp:DropDownList ID="ddlStartH" runat="server" />時
                <asp:DropDownList ID="ddlStartT" runat="server" />分
            </td>
        </tr>
        <tr>
            <th class="require">日期迄:</th>
            <td>
                <asp:TextBox ID="txtEndD" runat="server" onclick="showCalendar(this);" />
                <asp:DropDownList ID="ddlEndH" runat="server" />時
                <asp:DropDownList ID="ddlEndT" runat="server" />分
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:PlaceHolder ID="plContainer" runat="server" />
                <%--<asp:Button ID="btnSubmit" runat="server" Text="送出" OnClick="btnSubmit_Click" CssClass="btn_main" />--%>
            </td>
        </tr>
    </table>
</asp:Content>

