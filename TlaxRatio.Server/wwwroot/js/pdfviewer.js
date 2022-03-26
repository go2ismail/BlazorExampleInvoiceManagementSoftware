 
window.showPdf = (base64) => {
    const blob = window.base64ToBlob(base64, 'application/pdf');
    const url = URL.createObjectURL(blob);
    document.getElementById('pdfContent').setAttribute("src", url);
    //document.getElementById("pdfContent").innerHTML = ("<iframe width='100%'importand height='100%' src='" + url + "'></iframe>");
    window.autoResize("pdfContent");
    return "ok";
};

window.base64ToBlob = (base64, type="application/octet-stream")  => {
    const binStr = atob(base64);
    const len = binStr.length;
    const arr = new Uint8Array(len);
    for (let i = 0; i < len; i++) {
        arr[i] = binStr.charCodeAt(i);
    }
    return new Blob([arr], {type: type });
};

window.autoResize = (id) => {
    var newheight;
    var newwidth;

    if (document.getElementById) {
        newheight = document.getElementById(id).contentWindow.document.body.scrollHeight;
    }
    document.getElementById(id).height = (newheight) + "px";
};

