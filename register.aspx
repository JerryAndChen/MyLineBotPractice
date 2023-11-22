<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>註冊</title>
    <link rel="stylesheet" href="assets/css/main.css"/>
    <link rel="stylesheet" href="assets/css/dialog.css" />
    <script type="text/javascript" src="https://static.line-scdn.net/liff/edge/2/sdk.js"></script>
    <script type="text/javascript" src="assets/js/dialog.js"></script>
    <script type="text/javascript" src="js/function.js"></script>
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
        function liff_sendMessages(msg) {
            return new Promise(function (resolve, reject) {
                liff.init({ liffId: "2000626468-ZQE950nX", withLoginOnExternalBrowser: true });
                liff.ready.then(() => {
                    //用戶發送訊息 - 傳給當前 Line Bot
                    if (!liff.isInClient()) {
                        // alert('This button is unavailable as LIFF is currently being opened in an external browser.');
                        //於外開瀏覽器無法使用此功能
                        resolve("於外開瀏覽器無法使用此功能");
                    } else {
                        liff.sendMessages(msg.messages)
                            .then(() => {
                                resolve("已發送訊息");
                            })
                            .catch((error) => {
                                //發送訊息失敗
                                reject("發送訊息失敗" + error);
                            });
                    }
                });
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="h_center">
            <caption>資料註冊</caption>
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
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnSubmit" runat="server" Text="確定送出" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
