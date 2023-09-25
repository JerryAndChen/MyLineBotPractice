<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LiffInit.aspx.cs" Inherits="LiffInit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Liff Init</title>
    <style>
        .centerText{
            position:absolute;
            top:50%;
            left:50%;
            transform:translate(-50%,-50%);
            font-size:16px;
        }
    </style>
    <script type="text/javascript" src="https://static.line-scdn.net/liff/edge/2/sdk.js"></script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            LiffInit();
        });
        function LiffInit() {
            var liffId = hfLiffId.value;
            liff.init({ liffId: liffId, withLoginOnExternalBrowser: true });
            liff.ready.then(() => {
                if (liff.isLoggedIn()) {
                    liff.getProfile().then(profile => {
                        //put value to hidden field
                        userId.value = profile.userId;
                        userName.value = profile.displayName;
                        userPicUrl.value = profile.pictureUrl;

                        //ajax => set user info
                        var q = "userId=" + profile.userId;
                        var x = getRemoteData(q);
                        if (x != null && x.length > 0) {
                            var json = JSON.parse(x);
                            if (json.Pass == true) {
                                //導向index頁面
                                form1.action = "index.aspx";
                                form1.submit();
                            }else
                                alert(json.ErrorMsg);
                        }
                        
                    });
                }
            });
        }
        function getRemoteData(q) {
            var xhr = new XMLHttpRequest();
            xhr.open("post", "ajax/json_setUserSession.aspx", false);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.send(q);
            return xhr.responseText.trim();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="centerText">
            Loading...
        </div>
        <asp:HiddenField ID="hfLiffId" runat="server" />
        <input type="hidden" id="userId" name="userId" />
        <input type="hidden" id="userName" name="userName" />
        <input type="hidden" id="userPicUrl" name="userPicUrl" />
    </form>
</body>
</html>
