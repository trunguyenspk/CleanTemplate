Logixtek.Home = Logixtek.Home || {};
Logixtek.Home.GetAllItems = function (done) {
    var url = window.location.protocol + "//" + window.location.host + "/api/EbatchSheet";
    $.ajax({
        url: url,
        async: true,
        headers: {
            'Content-Type': 'application/json'
        }
    }).done(function (datas) {
        if (typeof done === "function") done(datas);
    }).fail(function (jqXHR, textStatus) {
        console.log(jqXHR);
    }).always(function () {
        console.log("complete");
    });
}
Logixtek.Home.BindGrid = function () {
    Logixtek.Home.GetAllItems(function (datas) {
        $("#grid").kendoGrid({
            dataSource: datas,
            sortable: true,
            pageable: {
                alwaysVisible: false,
                pageSizes: [5, 10, 20, 50]
            },
            noRecords: {
                template: "<b style=\"padding: 10px 0px 10px 10px;\">There are no form that is currently available for you to work on.<b>"
            },
            columns: [
                {
                    field: "workOrderNumber",
                    title: "Work Order Number",
                    width: "25%",
                    template: function (data) {
                        var url = window.location.protocol + "//" + window.location.host + "/form?id=" + data.id;
                        var html = "";
                        var number = (typeof data.workOrderNumber === "string" && data.workOrderNumber.trim() !== "") ? data.workOrderNumber : data.workOrderId;
                        html += "<a href=\"" + url + "\">" + number + "</a>";
                        return html;
                    }
                }, {
                    field: "currentState",
                    title: "State",
                    width: "15%",
                    template: function (data) {
                        var html = "";
                        if (typeof data.currentState === "object" && typeof data.currentState.value === "string")
                            html = data.currentState.value;
                        return html;
                    }
                }, {
                    field: "ModifiedDate",
                    title: "Modified Date",
                    width: "25%",
                    template: function (data) {
                        var date = data.modifiedDate;
                        var html = Logixtek.Home.FormatDate(date);
                        return html;
                    }
                }, {
                    field: "CreatedDate",
                    title: "Created Date",
                    width: "25%",
                    template: function (data) {
                        var date = data.createdDate;
                        var html = Logixtek.Home.FormatDate(date);
                        return html;
                    }
                }, {
                    title: "Action",
                    width: "10%",
                    template: function (data) {
                        var html = "";
                        html += "<button type=\"button\" class=\"btn btn-default btn-sm\" id=\"" + data.id + "\" onclick=\"Logixtek.Home.Delete(this)\">";
                        html += "   <span class= \"glyphicon glyphicon-trash\" ></span>";
                        html += "</button>";
                        return html;
                    }
                }
            ]
        });
    });
};

Logixtek.Home.FormatDate = function (date) {
    var dateStr = "";
    if (typeof date === "string") {
        date = new Date(date);
    }
    if (date instanceof Date && !isNaN(date.valueOf())) {
        const monthNames = ["January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];

        var d = date.getDate();
        var M = date.getMonth();
        var y = date.getFullYear();
        var dStr = d.toString();
        var MStr = monthNames[M];
        var yStr = y.toString();
        if (dStr[dStr.length - 1] === "1") dStr = dStr + "st";
        else if (dStr[dStr.length - 1] === "2") dStr = dStr + "nd";
        else if (dStr[dStr.length - 1] === "3") dStr = dStr + "rd";
        else dStr = dStr + "th";

        var h = date.getHours();
        var m = date.getMinutes();
        var s = date.getSeconds();
        var hStr = (h > 12) ? (h - 12).toString() : h.toString();
        var mStr = m.toString();
        var sStr = s.toString();
        if (hStr.length === 1) hStr = "0" + hStr;
        if (mStr.length === 1) mStr = "0" + mStr;
        if (sStr.length === 1) sStr = "0" + sStr;

        var t = (h > 12) ? "pm" : "am";

        dateStr = MStr + " " + dStr + " " + yStr + " " + hStr + ":" + mStr + ":" + sStr + " " + t;
    }
    return dateStr;
}

Logixtek.Home.Delete = function (control) {
    var delete_dialog = $('#delete-dialog');

    delete_dialog.kendoDialog({
        width: "250px",
        title: "Confirmation",
        closable: true,
        modal: true,
        content: "<p style=\"text-align: center;\"> Are you sure ? </p>",
        actions: [
            {
                text: 'Delete',
                action: function (e) {
                    DeleteById(control.id);
                    return true;
                }
            },
            {
                text: 'Cancel',
                primary: true
            }
        ]
    });

    delete_dialog.data("kendoDialog").open();
};

function DeleteById(id) {
    if (typeof id === "string") {
        var url = window.location.protocol + "//" + window.location.host + "/api/EbatchSheet/" + id;
        $.ajax({
            method: "DELETE",
            url: url,
            async: true,
            headers: {
                'Content-Type': 'application/json'
            }
        }).done(function (data) {
            if (typeof done === "function") done(data);
            Logixtek.Home.BindGrid();
        }).fail(function (jqXHR, textStatus) {
            console.log(jqXHR);
            alert("Error!");
        }).always(function () {
            console.log("complete");
        });
    }
    else {
        alert("NO ID!");
    }
}

$(function () {

});

window.onload = function () {
    Logixtek.Home.BindGrid();
};