<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="assets/css/dialog.css" />
    <style>
        table{
            position:absolute;
            top:50%;
            left:50%;
            transform:translate(-50%,-50%);
        }
    </style>
    <script type="text/javascript" src="assets/js/dialog.js"></script>
    <script>
        function showCalendar() {
            showDialog(200, 230, "Shared/Calendar.aspx");
        }
        function selectDate(value) {
            var txtBirth = document.getElementById("<%=txtBirth.ClientID%>");
            txtBirth.value = value;
            closeDialog();
        }
        function registerSuccess(msg) {
            liff_sendMessages(msg)
                .then((log) => {
                    console.log(log);
                    showMsgAndGoto("註冊成功", "index.aspx");
                })
                .catch((e) => console.log(e));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <caption>會員註冊</caption>
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
                <%--<asp:RadioButton ID="rdSexType1" GroupName="sexType" runat="server" Text="男" Checked="true"/>
                <asp:RadioButton ID="rdSexType2" GroupName="sexType" runat="server" Text="女" />--%>
                <asp:RadioButtonList ID="rdSexType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="男" Selected="True" />
                    <asp:ListItem Value="女" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th>生日:</th>
            <td>
                <asp:TextBox ID="txtBirth" runat="server" onclick="showCalendar();" />
                <asp:RequiredFieldValidator ID="rfvBirth" runat="server" ControlToValidate="txtBirth" Display="Dynamic" ForeColor="Red" ErrorMessage="日期不可為空" />
                <asp:RegularExpressionValidator ID="revBirth" runat="server" ControlToValidate="txtBirth" ValidationExpression="^(19|20)[0-9]{2}\-(0(?:[0-9])|1(?:[0-2]))\-(0(?:[1-9])|[1-2](?:[0-9])|3(?:[01]))$" Display="Dynamic" ForeColor="Red" ErrorMessage="日期格式不正確" />
                <%--<asp:CustomValidator ID="cvBirth" runat="server" ControlToValidate="txtBirth" Display="Dynamic" OnServerValidate="cv_Field" ForeColor="Red" ErrorMessage="日期格式不正確" />--%>
                <%--<asp:Image ID="imgCalendar" runat="server" ImageUrl="~/assets/css/calendar.svg" />--%>
            </td>
        </tr>
        <tr>
            <th>手機:</th>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" />
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" ErrorMessage="手機不可為空" />
                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^09[0-9]{8}$" Display="Dynamic"  ForeColor="Red" ErrorMessage="手機格式不正確" />
                <%--<asp:CustomValidator ID="cvPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" OnServerValidate="cv_Field" ForeColor="Red" ErrorMessage="手機格式不正確" />--%>
            </td>
        </tr>
        <tr>
            <th>Email:</th>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"/>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^(\w+([\.\-]\w+)*)@\w+(\-\w+)*(\.\w{2,})+$" Display="Dynamic" ForeColor="Red" ErrorMessage="Email格式不正確" />
                <%--<asp:CustomValidator ID="cvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" OnServerValidate="cv_Field" ForeColor="Red" ErrorMessage="Email格式不正確" />--%>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="確定送出" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

