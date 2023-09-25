function showDialog(w,h,url) {
    var iframe = document.createElement("iframe");
    iframe.src = url;
    iframe.className = "dialogFrame";

    var btn = document.createElement("input");
    btn.type = "button";
    btn.value = "關閉";
    btn.setAttribute("onclick", "closeDialog()");

    var dialog = document.createElement("dialog");
    dialog.className = "dialog";
    dialog.id = "dialog";
    dialog.style.width = w+"px";
    dialog.style.height = h+"px";
    dialog.appendChild(iframe);
    dialog.appendChild(btn);

    
    setPage(true);
    document.body.appendChild(dialog);
    dialog.show();
}
function closeDialog() {
    var dialog = document.getElementById("dialog");
    setPage(false);
    document.body.removeChild(dialog);
}
function setPage(isDisabled) {
    var children = form1.children;
    form1.style.opacity = isDisabled ? 0.5 : 1;
    setElement(children, isDisabled);
}
function setElement(obj, isDisabled) {
    var i;
    for (i = 0; i < obj.length; i++) {
        if (obj[i].firstChild) {
            setElement(obj[i].children, isDisabled);
        } else {
            if (obj[i].tagName.toLowerCase() == "input" && obj[i].type.match("text|button|submit")) {
                obj[i].isDisabled = isDisabled ? true : false;
            }
        }
    }
    
}