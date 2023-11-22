function closeWindow() {
    window.close();
}
function showMsg(e) {
    alert(e);
}
function showMsgAndGoto(e, url) {
    alert(e);
    window.location.href = url;
}
function showMsgAndGoBack(e) {
    alert(e);
    window.history.go(-1);
}