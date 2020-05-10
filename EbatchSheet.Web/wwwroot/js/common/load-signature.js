var signaturePadArr = {};

function loadSignaturePad(id) {
    if (typeof signaturePadArr[id] === "undefined" || signaturePadArr[id] === null) {
        $("<i id=\"canvas-sign-refresh-btn-" + id + "\" for=\"" + id + "\" class=\"canvas-sign-refresh-btn fa fa-refresh\" style=\"float: right;\"></i>").insertAfter("#" + id);
        var canvas = document.getElementById(id);

        var ratio = Math.max(window.devicePixelRatio || 1, 1);
        var signaturePad = new SignaturePad(canvas);
        canvas.width = canvas.offsetWidth * ratio;
        canvas.height = canvas.offsetHeight * ratio;
        canvas.getContext("2d").scale(ratio, ratio);
        signaturePad.clear();

        signaturePadArr[id] = signaturePad;

        $("#canvas-sign-refresh-btn-" + id).click(function () {
            var eId = $(this).attr("for");
            if (typeof eId === "string") {
                signaturePadArr[eId].clear();
            }
        });
    }
}
function loadAllRenderedSignaturePad() {
    var canvasSigns = document.getElementsByClassName("canvas-sign");
    for (var i = 0; i < canvasSigns.length; i++) {
        var eId = canvasSigns[i].id;
        if (typeof eId === "string" && eId.trim() !== "") {
            loadSignaturePad(eId);
        }
    }
}

function getSignaturePadValue(id) {
    var signaturePad = null;
    if (typeof signaturePadArr[id] === "object") {
        signaturePad = signaturePadArr[id];
    }
    else {
        var canvas = document.getElementById(id);
        signaturePad = new SignaturePad(canvas);
    }
    var data = signaturePad.toDataURL();
    return data;
}
function loadSignaturePadValue(id, data) {
    if (typeof data === "string" && data.trim() !== "") {
        var signaturePad = null;
        if (typeof signaturePadArr[id] === "object") {
            signaturePad = signaturePadArr[id];
        }
        else {
            var canvas = document.getElementById(id);
            signaturePad = new SignaturePad(canvas);
        }

        signaturePad.fromDataURL(data);
    }
}

function removeSignaturePad(id) {
    if (typeof signaturePadArr[id] === "object") {
        delete signaturePadArr[id];
    }
}

$(function () {
    loadAllRenderedSignaturePad();
});