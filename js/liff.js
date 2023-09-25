liff.init({ liffId: "2000626468-ZQE950nX", withLoginOnExternalBrowser: true });
function liff_sendMessages() {
    liff.ready.then(() => {
        alert("send messages");
    });
}