<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cfgSchedule.aspx.cs" Inherits="cfgSchedule" %>

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
        function chgType(obj) {
            $(".trTimeGrp").css("display", obj.value=="time" ? "" : "none");
            $(".trPeriodGrp").css("display", obj.value == "period" ? "" : "none");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="h_center">
        <caption>行事曆設定</caption>
        <tr>
            <th>類型:</th>
            <td>
                <asp:RadioButtonList ID="rdType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdType_Changed" >
                    <asp:ListItem Text="時段" Value="time" Selected="True" onclick="chgType(this)" />
                    <asp:ListItem Text="週期" Value="period" onclick="chgType(this)" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="trTimeGrp">
            <th>時間起:</th>
            <td>
                <asp:TextBox ID="txtStartD" runat="server" onclick="showCalendar(this);" />
                <asp:DropDownList ID="ddlStartH" runat="server" />時
                <asp:DropDownList ID="ddlStartT" runat="server" />分
            </td>
        </tr>
        <tr class="trTimeGrp">
            <th>時間迄:</th>
            <td>
                <asp:TextBox ID="txtEndD" runat="server" onclick="showCalendar(this);" />
                <asp:DropDownList ID="ddlEndH" runat="server" />時
                <asp:DropDownList ID="ddlEndT" runat="server" />分
            </td>
        </tr>
        <tr class="trPeriodGrp" style="display:none">
            <th>時段:</th>
            <td>
                <asp:DropDownList ID="ddlPStartH" runat="server" />時
                <asp:DropDownList ID="ddlPStartT" runat="server" />分
                ~
                <asp:DropDownList ID="ddlPEndH" runat="server" />時
                <asp:DropDownList ID="ddlPEndT" runat="server" />分
            </td>
        </tr>
        <tr class="trPeriodGrp" style="display:none">
            <th>週期:</th>
            <td>
                <asp:CheckBoxList ID="ckPeriod" runat="server" RepeatLayout="Flow">
                    <asp:ListItem Text="星期一" Value="1" />
                    <asp:ListItem Text="星期二" Value="2" />
                    <asp:ListItem Text="星期三" Value="3" />
                    <asp:ListItem Text="星期四" Value="4" />
                    <asp:ListItem Text="星期五" Value="5" />
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="確定新增" />
            </td>
        </tr>
    </table>
</asp:Content>

