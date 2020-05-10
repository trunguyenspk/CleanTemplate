Logixtek.Form = Logixtek.Form || {};

Logixtek.Form.ControlTypes = {
    "inputtext": "input-text",
    "inputnumber": "input-number",
    "textarea": "textarea",
    "inputobjtext": "input-obj-text",
    "inputtextdate": "input-text-date",
    "grid": "grid",
    "combobox": "combobox",
    "signature": "signature",
    "text": "text",
    "textdate": "text-date"
};
Logixtek.Form.GridControlTypes = {
    "text": "text",
    "multitext": "multitext",
    "signature": "signature",
    "radio": "radio",
    "removeControl": "removeControl"
};

Logixtek.Form.FormatDate = function (date) {
    var dateStr = "";
    if (date === "0001-01-01T00:00:00") {
        return dateStr;
    }
    if (typeof date === "string") {
        date = new Date(date);
    }
    if (date instanceof Date && !isNaN(date.valueOf())) {
        const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

        var d = date.getDate();
        var M = date.getMonth() + 1;
        var y = date.getFullYear();

        var dStr = d.toString();
        var MStr = monthNames[M];
        var yStr = y.toString();

        /*if (dStr[dStr.length - 1] === "1") dStr = dStr + "st";
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

        var t = (h > 12) ? "pm" : "am";*/

        if (dStr.length === 1) dStr = "0" + dStr;
        if (M < 10) M = "0" + M;

        dateStr = dStr + "/" + M + "/" + yStr; //+ " " + hStr + ":" + mStr + ":" + sStr + " " + t;
    }
    return dateStr;
};

Logixtek.Form.GetShortDate = function (date) {
    var dateStr = "";
    if (date === "0001-01-01T00:00:00") {
        return dateStr;
    }
    if (typeof date === "string") {
        date = new Date(date);
    }
    if (date instanceof Date && !isNaN(date.valueOf())) {
        language = Logixtek.Form.GetCulture();
        dateStr = date.toLocaleDateString(language);
    }
    return dateStr;
}

Logixtek.Form.GetCulture = function () {
    var language = "en-US";
    if (window.navigator.languages) {
        language = window.navigator.languages[0];
    } else {
        language = window.navigator.userLanguage || window.navigator.language;
    }
    return language;
};

Logixtek.Form.ParseCorrectDateFormat = function (date) {
    var arr = date.split("/");
    var correctDate = new Date(arr[2], parseInt(arr[1]) - 1, arr[0]);
    return correctDate;
};


Logixtek.Form.Item = null;
Logixtek.Form.States = [];

Logixtek.Form.Controls = [];
Logixtek.Form.GetAllControls = function () {
    var htmlControls = $("[data-type='form-field'] [data-obj='eBatchSheet']");
    $.each(htmlControls, function (index, c) {
        var ctrl = {};
        ctrl["control"] = c;
        var attrs = $(c)[0].attributes;
        $.each(attrs, function (attrIndex, attr) {
            ctrl[attr.name] = attr.value;
        });

        //Get Grid control
        if (typeof ctrl["data-type"] === "string" && ctrl["data-type"] === Logixtek.Form.ControlTypes.grid) {
            if (typeof ctrl["data-prop"] === "string") {
                var dprop = ctrl["data-prop"];
                var eprops = $("props[data-prop='" + dprop + "'] prop");
                if (eprops.length > 0) {
                    var props = [];
                    $.each(eprops, function (index, property) {
                        var field = $(property).attr("field");
                        var type = $(property).attr("type");
                        var title = $(property).attr("title");
                        var propobj = { field: field, type: type, title: title };

                        if (typeof $(property).attr("footer") === "string") {
                            propobj["footer"] = $(property).attr("footer");
                        }
                        if ($(property).find("prop-option").length > 0) {
                            var poptions = [];
                            $.each($(property).find("prop-option"), function (oindex, poption) {
                                var povalue = $(poption).attr("value");
                                var potitle = $(poption).attr("title");
                                poptions.push({ value: povalue, title: potitle });
                            });
                            propobj["options"] = poptions;
                        }

                        props.push(propobj);
                    });
                    ctrl["properties"] = props;
                }
            }
        }

        Logixtek.Form.Controls.push(ctrl);
    });
}

Logixtek.Form.GetItem = function (done) {
    var id = Logixtek.GetUrlParameter("id");
    if (typeof id === "string") {
        var url = window.location.protocol + "//" + window.location.host + "/api/EbatchSheet/" + id;
        $.ajax({
            url: url,
            async: true,
            headers: {
                'Content-Type': 'application/json'
            }
        }).done(function (item) {
            if (typeof done === "function") done(item);
        }).fail(function (jqXHR, textStatus) {
            if (jqXHR.status == 401) {
                window.location.href = "/Account/AccessDenied";
            }
            //console.log(jqXHR);
        }).always(function () {
            console.log("complete");
        });
    }
}
Logixtek.Form.GetStates = function (done) {
    var url = window.location.protocol + "//" + window.location.host + "/api/EbatchSheet/EbatchStates";
    $.ajax({
        url: url,
        async: true,
        headers: {
            'Content-Type': 'application/json'
        }
    }).done(function (states) {
        if (states.length > 0) {
            Logixtek.Form.States = states.filter(s => s.id > 0);
        }
        if (typeof done === "function") done();
    }).fail(function (jqXHR, textStatus) {
        console.log(jqXHR);
    }).always(function () {
        console.log("complete");
    });
};

Logixtek.Form.AddGridRow = function (control, dataload) {
    var dprop = control["data-prop"];
    var props = control["properties"];

    var tbody = $(control["control"]).find("tbody");

    var trlength = 1;
    var rowLength = $(tbody).find("tr[for='" + dprop + "']").length;
    if (rowLength > 0) {
        var lastTrIndex = rowLength - 1;
        var lastTr = $(tbody).find("tr[for='" + dprop + "']")[lastTrIndex];
        trlength = parseInt($(lastTr).attr("index")) + 1;
    }
    $(tbody).append("<tr index=\"" + trlength + "\"  for=\"" + dprop + "\"></tr>");
    var tr = $(tbody).find("tr[index='" + trlength + "']");

    if (typeof dataload === "object") {
        var obj = dataload;
        $.each(props, function (pindex, property) {
            var cvalue = (typeof obj[property.field] === "string" || typeof obj[property.field] === "number") ? obj[property.field] : "";
            switch (property.type) {
                case Logixtek.Form.GridControlTypes.text:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <input for=\"" + trlength + "-" + pindex + "\" class=\"form-control\" spellcheck=\"true\" type=\"text\" placeholder=\"\" data-prop=\"" + property.field + "\" value=\"" + cvalue + "\"/>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                case Logixtek.Form.GridControlTypes.multitext:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <textarea for=\"" + trlength + "-" + pindex + "\"  class=\"form-control\" spellcheck=\"true\" rows=\"3\" placeholder=\"\" data-prop=\"" + property.field + "\">" + cvalue + "</textarea>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                case Logixtek.Form.GridControlTypes.signature:
                    var postfix = dprop + "-" + trlength + "-" + pindex;
                    var id = "canvas-sign-" + postfix;
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <canvas id=\"" + id + "\" name=\"" + postfix + "\" class=\"canvas-sign\" style=\"width: 300px; height: 150px; background-color: #f5f5eb;\" data-prop=\"" + property.field + "\"></canvas>";
                    chtml += "      <div style=\"text-align: center; color: #c3c3c3;\">" + property.footer + "</div>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    loadSignaturePad(id);
                    loadSignaturePadValue(id, cvalue);
                    break;
                case Logixtek.Form.GridControlTypes.radio:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    $.each(property.options, function (index, option) {
                        var valueCheck = option.value.trim().toLowerCase();
                        var cvalueCheck = cvalue.trim().toLowerCase();
                        var checked = (valueCheck === cvalueCheck) ? "checked" : "";
                        chtml += "       <div class=\"radio\"><label class=\"control-label\"><input for=\"" + trlength + "-" + pindex + "\"  type=\"radio\" value=\"" + option.value + "\" data-prop=\"" + property.field + "\" name=\"" + property.field + "-" + dprop + "-" + trlength + "-" + pindex + "\" " + checked + "/><span>" + option.title + "</span></label>";
                    });
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                case Logixtek.Form.GridControlTypes.removeControl:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <div  onclick='Logixtek.Form.RemoveGridItem(this);'> <i class=\"fa fa-times fa-2x\" onMouseOver=\"this.style.cursor = 'pointer'\"></i></div>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                default:
                    var chtml = "<td></td>";
                    $(tr).append(chtml);
                    break;
            }
        });
    }
    else {
        $.each(props, function (pindex, property) {
            switch (property.type) {
                case Logixtek.Form.GridControlTypes.text:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <input for=\"" + trlength + "-" + pindex + "\"  class=\"form-control\" spellcheck=\"true\" type=\"text\" placeholder=\"\" data-prop=\"" + property.field + "\"/>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                case Logixtek.Form.GridControlTypes.multitext:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <textarea for=\"" + trlength + "-" + pindex + "\"  class=\"form-control\" spellcheck=\"true\" rows=\"3\" placeholder=\"\" data-prop=\"" + property.field + "\"></textarea>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                case Logixtek.Form.GridControlTypes.signature:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <canvas id=\"canvas-sign-" + dprop + "-" + trlength + "-" + pindex + "\" class=\"canvas-sign\" style=\"width: 300px; height: 150px; background-color: #f5f5eb;\" data-prop=\"" + property.field + "\"></canvas>";
                    chtml += "      <div style=\"text-align: center; color: #c3c3c3;\">" + property.footer + "</div>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    loadSignaturePad("canvas-sign-" + dprop + "-" + trlength + "-" + pindex);
                    break;
                case Logixtek.Form.GridControlTypes.radio:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    $.each(property.options, function (index, option) {
                        chtml += "       <div class=\"radio\"><label class=\"control-label\"><input for=\"" + trlength + "-" + pindex + "\"   type=\"radio\" value=\"" + option.value + "\" data-prop=\"" + property.field + "\" name=\"" + property.field + "\"/><span>" + option.title + "</span></label>";
                    });
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                case Logixtek.Form.GridControlTypes.removeControl:
                    var chtml = "";
                    chtml += "<td>";
                    chtml += "  <div class=\"input-group\">";
                    chtml += "      <div  onclick=\"Logixtek.Form.RemoveGridItem(this);\"> <i class=\"fa fa-times fa-2x\" onMouseOver=\"this.style.cursor = 'pointer'\"></i></div>";
                    chtml += "  </div>";
                    chtml += "</td>";
                    $(tr).append(chtml);
                    break;
                default:
                    var chtml = "<td></td>";
                    $(tr).append(chtml);
                    break;
            }
        });
    }
};

Logixtek.Form.AddNewGridRow = function (_control) {
    event.preventDefault();

    var dprop = $(_control).attr("data-prop");
    var controls = Logixtek.Form.Controls.filter(function (c) {
        return c["data-prop"] === dprop;
    });

    if (controls.length > 0) {
        Logixtek.Form.AddGridRow(controls[0]);
    }
};

Logixtek.Form.LoadItem = function () {
    var item = Logixtek.Form.Item;
    $.each(item, function (key, value) {
        var controls = Logixtek.Form.Controls.filter(function (c) {
            return c["data-prop"] === key;
        });
        if (controls.length > 0) {
            var type = controls[0]["data-type"];
            switch (type) {
                case Logixtek.Form.ControlTypes.inputtext:
                case Logixtek.Form.ControlTypes.textarea:
                    $(controls[0]["control"]).val(value);
                    break;
                case Logixtek.Form.ControlTypes.inputnumber:
                    $(controls[0]["control"]).val(value);
                    break;
                case Logixtek.Form.ControlTypes.inputtextdate:
                    var cvalue = Logixtek.Form.FormatDate(value);
                    $(controls[0]["control"]).val(cvalue);
                    break;
                case Logixtek.Form.ControlTypes.inputobjtext:
                    var propshow = controls[0]["data-propshow"];
                    if (typeof propshow === "string") {
                        $(controls[0]["control"]).val(value[propshow]);
                    }
                    break;
                case Logixtek.Form.ControlTypes.grid:
                    var props = controls[0]["properties"];
                    var theadhtml = "";
                    $.each(props, function (index, property) {
                        theadhtml += "<th><span>" + property.title + "</span></th>";
                    });
                    theadhtml += "<thead><tr>" + theadhtml + "</tr></thead>";
                    $(controls[0]["control"]).append(theadhtml);

                    var array = value;
                    if (typeof array !== "undefined" && array.length > 0) {
                        $(controls[0]["control"]).append("<tbody></tbody>");
                        $.each(array, function (aindex, obj) {
                            Logixtek.Form.AddGridRow(controls[0], obj);
                        });
                    }
                case Logixtek.Form.ControlTypes.combobox:
                    //var propshow = controls[0]["data-propshow"];
                    //var propvalue = controls[0]["data-propvalue"];
                    //if (typeof propshow !== "string" || propshow.trim() === "") {
                    //    propshow = propvalue;
                    //}
                    //if (typeof propvalue === "string" && propvalue.trim() !== "") {
                    //    $(controls[0]["control"]).kendoComboBox({
                    //        dataTextField: propshow,
                    //        dataValueField: propvalue,
                    //        dataSource: Logixtek.Form.States,
                    //        filter: "contains",
                    //        suggest: true,
                    //        value: value[propvalue]
                    //    });
                    //}
                    break;
                case Logixtek.Form.ControlTypes.signature:
                    var id = "canvas-sign-" + key;
                    $(controls[0]["control"]).attr("id", id);
                    loadSignaturePad(id);
                    loadSignaturePadValue(id, value);
                    break;
                case Logixtek.Form.ControlTypes.text:
                    $(controls[0]["control"]).text(value);
                    break;
                case Logixtek.Form.ControlTypes.textdate:
                    var cvalue = Logixtek.Form.FormatDate(value);
                    $(controls[0]["control"]).text(cvalue);
                    break;
                default:
                    break;
            }
        }
    });
}
Logixtek.Form.LoadStateControl = function () {
    if ($("#select-current-state").length > 0) {
        $("#select-current-state").css("width", "100%");
        $("#select-current-state").kendoDropDownList({
            dataTextField: "value",
            dataValueField: "id",
            dataSource: Logixtek.Form.States,
            change: function (e) {
                var selectedItem = e.sender.select();
                var selectControl = $("#select-current-state").data("kendoDropDownList");
                var dataItem = selectControl.dataItem(selectedItem);

                Logixtek.Form.Item["currentState"] = { "id": dataItem.id, "value": dataItem.value };
            }
        });
        var dropdownlist = $("#select-current-state").data("kendoDropDownList");
        dropdownlist.value(Logixtek.Form.Item["currentState"].id);
    }
}

Logixtek.Form.GetGridRowData = function (control) {
    var results = [];

    var dprop = control["data-prop"];
    var props = control["properties"];
    var tbody = $(control["control"]).find("tbody");
    var trs = $(tbody).find("tr");
    $.each(trs, function (tri, tr) {
        var trindex = parseInt($(tr).attr("index"));
        var obj = {};
        $.each(props, function (pindex, property) {
            if (typeof property.field === "string" && property.field.trim() !== "") {
                switch (property.type) {
                    case Logixtek.Form.GridControlTypes.text:
                    case Logixtek.Form.GridControlTypes.multitext:
                        var c = $(tr).find("[for='" + trindex + "-" + pindex + "']");
                        if (c.length > 0) {
                            obj[property.field] = $(c).val();
                        }
                        break;
                    case Logixtek.Form.GridControlTypes.signature:
                        var id = "canvas-sign-" + dprop + "-" + trindex + "-" + pindex;
                        var data = getSignaturePadValue(id);
                        obj[property.field] = data;
                        break;
                    case Logixtek.Form.GridControlTypes.radio:
                        var c = $(tr).find("[for='" + trindex + "-" + pindex + "']:checked");
                        if (c.length > 0) {
                            obj[property.field] = $(c).val();
                        }
                        break;
                    default:

                        break;
                }
            }
        });
        results.push(obj);
    });

    return results;
}

Logixtek.Form.GetDataToSave = function () {
    var item = Logixtek.Form.Item;
    $.each(Logixtek.Form.Controls, function (index, c) {
        var type = c["data-type"];
        var prop = c["data-prop"];
        switch (type) {
            case Logixtek.Form.ControlTypes.inputtext:
            case Logixtek.Form.ControlTypes.textarea:
                item[prop] = $(c["control"]).val();
                break;
            case Logixtek.Form.ControlTypes.inputnumber:
                var value = $(c["control"]).val();
                if (!isNaN(value)) {
                    item[prop] = parseInt(value);
                }
                break;
            case Logixtek.Form.ControlTypes.inputtextdate:
                var dvalue = $(c["control"]).val();
                if (dvalue) {
                    item[prop] = Logixtek.Form.ParseCorrectDateFormat(dvalue);
                }
                break;
            case Logixtek.Form.ControlTypes.inputobjtext:

                break;
            case Logixtek.Form.ControlTypes.grid:
                item[prop] = Logixtek.Form.GetGridRowData(c);
                break;
            case Logixtek.Form.ControlTypes.combobox:

                break;
            case Logixtek.Form.ControlTypes.signature:
                var id = "canvas-sign-" + prop;
                var data = getSignaturePadValue(id);
                item[prop] = data;
                break;
            case Logixtek.Form.ControlTypes.text:

                break;
            case Logixtek.Form.ControlTypes.textdate:

                break;
            default:
                break;
        }
    });
    return item;
};

Logixtek.Form.Save = function () {
    event.preventDefault();

    var id = Logixtek.GetUrlParameter("id");
    if (typeof id === "string") {
        var item = Logixtek.Form.GetDataToSave();
        var url = window.location.protocol + "//" + window.location.host + "/api/EbatchSheet/" + id;
        $.ajax({
            method: "PATCH",
            url: url,
            async: true,
            headers: {
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(item),
        }).done(function (data) {
            if (typeof done === "function") done(data);
            //alert("Success!");
            window.location.reload();
        }).fail(function (jqXHR, textStatus) {
            console.log(jqXHR);
            alert("SERVER ERROR: " + jqXHR.responseText);
        }).always(function () {
            console.log("complete");
        });
    }
    else {
        alert("No id!");
    }
};

Logixtek.Form.SaveAndSend = function () {
    event.preventDefault();

    var id = Logixtek.GetUrlParameter("id");
    if (typeof id === "string") {
        var item = Logixtek.Form.GetDataToSave();
        item.currentState = item.nextState;
        var url = window.location.protocol + "//" + window.location.host + "/api/EbatchSheet/" + id;
        $.ajax({
            method: "PATCH",
            url: url,
            async: true,
            headers: {
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(item),
        }).done(function (data) {
            if (typeof done === "function") done(data);
            window.location.href = "/";
            //alert("Success!");
        }).fail(function (jqXHR, textStatus) {
            console.log(jqXHR);
            alert("SERVER ERROR: " + jqXHR.responseText);
        }).always(function () {
            console.log("complete");
        });
    }
    else {
        alert("No id!");
    }
};

Logixtek.Form.RemoveGridItem = function (control) {
    var tr = $(control).closest("tr");
    var canvasArr = $(tr).find("canvas.canvas-sign");
    $.each(canvasArr, function (cindex, canvas) {
        var canvasId = $(canvas).attr("id");
        removeSignaturePad(canvasId);
    });
    $(tr).remove();
};

$(function () {
    Logixtek.Form.GetAllControls();
    Logixtek.Form.GetStates(function () {
        Logixtek.Form.GetItem(function (item) {
            if (typeof item === "object") {
                Logixtek.Form.Item = item;
                Logixtek.Form.LoadItem();
                Logixtek.Form.LoadStateControl();
            }
        });
    });
});