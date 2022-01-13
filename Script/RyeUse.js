/**!
 * 集結網路上大部分的東西,方便使用的工具庫.
 * @version 1.0.0.1
 * Copyright (c) 2020 
 */

/**
 * ------------------------------------------------------------------------
 * 有參照到的JS
 * 
 * datepicker-zh-TW.js
 * datatables.min.js
 * ------------------------------------------------------------------------
 * */


/**
 * ------------------------------------------------------------------------
 * Career need
 * ------------------------------------------------------------------------
 * */

//var main = document.getElementsByTagName('main');
//if (main != null) {
//    if (main.length > 0) {
//        main[0].onclick = function () { $('#navbar-classic').removeClass('show'); $('.navbar-toggler').addClass('collapsed'); }; 
//    }
//}




/**
 * ------------------------------------------------------------------------
 * 設定用參數
 * ------------------------------------------------------------------------
 */


/** debug 參數 */
var Debug = true;


/**
 * ------------------------------------------------------------------------
 * 基礎共用 - Parameter
 * ------------------------------------------------------------------------
 */

function getUrlParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
};

function queryString() {
    // This function is anonymous, is executed immediately and
    // the return value is assigned to QueryString!
    var query_string = {};
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        // If first entry with this name
        if (typeof query_string[pair[0]] === "undefined") {
            query_string[pair[0]] = pair[1];
            // If second entry with this name
        } else if (typeof query_string[pair[0]] === "string") {
            var arr = [query_string[pair[0]], pair[1]];
            query_string[pair[0]] = arr;
            // If third or later entry with this name
        } else {
            query_string[pair[0]].push(pair[1]);
        }
    }
    return query_string;
}



/**
 * ------------------------------------------------------------------------
 * 基礎共用 - 判斷
 * ------------------------------------------------------------------------
 */

/**
 *判斷是否為手機
 */
function isMobile() {
    var sUserAgent = navigator.userAgent.toLowerCase();
    var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
    var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
    var bIsMidp = sUserAgent.match(/midp/i) == "midp";
    var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
    var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
    var bIsAndroid = sUserAgent.match(/android/i) == "android";
    var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
    var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
    var isIphone = sUserAgent.match(/iphone/i) == "iphone";
    var isHuawei = sUserAgent.match(/huawei/i) == "huawei";
    var isHonor = sUserAgent.match(/honor/i) == "honor";
    var isOppo = sUserAgent.match(/oppo/i) == "oppo";
    var isOppoR15 = sUserAgent.match(/pacm00/i) == "pacm00";
    var isVivo = sUserAgent.match(/vivo/i) == "vivo";
    var isXiaomi = sUserAgent.match(/mi\s/i) == "mi ";
    var isXiaomi2s = sUserAgent.match(/mix\s/i) == "mix ";
    var isRedmi = sUserAgent.match(/redmi/i) == "redmi";
    var isSamsung = sUserAgent.match(/sm-/i) == "sm-";

    return (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM || isIphone || isHuawei || isHonor || isOppo || isOppoR15 || isVivo || isXiaomi || isXiaomi2s || isRedmi || isSamsung)
}

/**
 *判斷是否為空值
 */
function isEmpty(obj) {

    // null and undefined are "empty"
    if (obj == null) return true;

    // Assume if it has a length property with a non-zero value
    // that that property is correct.
    if (obj.length > 0) return false;
    if (obj.length === 0) return true;

    // If it isn't an object at this point
    // it is empty, but it can't be anything *but* empty
    // Is it empty?  Depends on your application.
    if (typeof obj !== "object") return true;

    // Otherwise, does it have any properties of its own?
    // Note that this doesn't handle
    // toString and valueOf enumeration bugs in IE < 9
    for (var key in obj) {
        if (hasOwnProperty.call(obj, key)) return false;
    }

    return true;
}
/**
 * 圖片確認用到的code
 * 這邊的範例是確認YT 是否存在高清圖 預設帶低清圖 有高清圖再做置換
 * */

var t_img; // 定時器
var isLoad = true; // 控制變量

/**
 * 1
 * */
function CheckImageIsHave() {
    
    isImgLoad(function () {
        // 加載完成
        for (var i = 0; i < $(".slideImgSet").length; i++) {
            var lurl = $(".slideImgSet")[i].src;
            if (lurl.indexOf("mqdefault.jpg") > 0) {
                var hurl = lurl.replace("mqdefault", "maxresdefault");
                CheckImgExists(hurl, $(".slideImgSet")[i])
            }
        }
    });
}

/**
 * 2
 * */
// 判斷圖片加載的函數
function isImgLoad(callback) {
    $('.slideImgSet').each(function () {
        if (this.height === 0) {
            isLoad = false;
            return false;
        }
    });
    // 為true，沒有發現為0的。加載完畢
    if (isLoad) {
        clearTimeout(t_img); // 清除定時器
        // 回調函數
        callback();
        // 為false，因為找到了沒有加載完成的圖，將調用定時器遞歸
    } else {
        isLoad = true;
        t_img = setTimeout(function () {
            isImgLoad(callback); // 遞歸掃描
        }, 150); // 我這裡設置的是500毫秒就掃描一次，可以自己調整
    }
}

/**
 * 可根據預計圖片大小來判斷是否無圖或是預設圖的大小
 * @param {any} imgurl
 * @param {any} ob
 * 3
 */
function CheckImgExists(imgurl, ob) {
    onImageLoaded(imgurl, function (icon) {
        //存在图片
        if (icon.fileSize > 0 || (icon.width > 120 && icon.height > 90)) {
            ob.src = icon.src;
        } else {
        }
    })
}

/**
 * 4
 * */
function onImageLoaded(url, cb) {
    var image = new Image()
    image.src = url
    if (image.complete) {
        // 圖片已經被載入
        cb(image)
    } else {
        // 如果圖片未被載入，則設定載入時的回調
        image.onload = function () {
            cb(image)
        }
    }
}

/**
 * ------------------------------------------------------------------------
 * 載入JS
 * ------------------------------------------------------------------------
 */
function appendJS(src) {
    var script = document.createElement("script");
    script.src = src;
    document.head.appendChild(script);
}

appendJS('https://d.line-scdn.net/r/web/social-plugin/js/thirdparty/loader.min.js');
appendJS('https://connect.facebook.net/zh_TW/sdk.js#xfbml=1&version=v3.0');
appendJS('https://platform.twitter.com/widgets.js');


/**
 * ------------------------------------------------------------------------
 * 基礎共用 - 轉值
 * ------------------------------------------------------------------------
 */

/**
 * 
 * @param {any} array
 */
function getStringByArray(array) {
    var str = "";
    var ele = $("<div>").text(array);
    str = ele.text();
    return str;
}

/**
 * 
 * @param {any} array
 * @param {any} key
 * @param {any} value
 */
function getObjectByArray(array, key, value) {
    var object = {};
    for (var i = 0; i < array.length; i++) {
        var temp = array[i];
        object[temp[key]] = temp[value];
    }
    return object;
}

function htmlencode(s){
var div = document.createElement('div');
div.appendChild(document.createTextNode(s));
return div.innerHTML;
}
function htmldecode(s){
var div = document.createElement('div');
div.innerHTML = s;
return div.innerText || div.textContent;
}

function repl(val) {
    return val.replace(/\\n/g, "\\n")
        .replace(/\\'/g, "\\'")
        .replace(/\\"/g, '\\"')
        .replace(/\\&/g, "\\&")
        .replace(/\\r/g, "\\r")
        .replace(/\\t/g, "\\t")
        .replace(/\\b/g, "\\b")
        .replace(/\\f/g, "\\f");
}

/**
 * ------------------------------------------------------------------------
 * 基礎共用 - 按鈕
 * ------------------------------------------------------------------------
 */

/** 刪除confirm */
function runScript(string) {
    if (string == null) {
        string = "你確定要刪除嗎？";
    }
    if (confirm(string)) {
        return true;
    }
    else {
        return false;
    }
}


/**
 * ------------------------------------------------------------------------
 * 時間用
 * ------------------------------------------------------------------------
 */


/**
 * 取得現在時間 的formattime p='格式'
 * @param {any} p
 */
function getNowDate(p) {
    var today = new Date();
    return FormatTime(p, today);
}

/**
 * 增加時間addDays功能
 * @param {any} p
 */
Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + days);
    return this;
}



/**
 * FormatTime("yyyy-MM-dd",new Date())
 * @param {any} t
 * @param {any} date
 */
function FormatTime(t, date) {
    var date = new Date(date);
    var o = {
        "M+": date.getMonth() + 1,                 //月份
        "d+": date.getDate(),                    //日
        "h+": date.getHours(),                   //小时
        "m+": date.getMinutes(),                 //分
        "s+": date.getSeconds(),                 //秒
        "q+": Math.floor((date.getMonth() + 3) / 3), //季度
        "S": date.getMilliseconds()             //毫秒
    };
    if (/(y+)/.test(t)) {
        t = t.replace(RegExp.$1, (date.getFullYear() + "").substr(4 - RegExp.$1.length));
    };
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(t)) {
            t = t.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        };
    }
    return t;
};

//啟用日期 預設抓 class name datepicker 需要datepicker-zh-TW.js
if ($(".datepicker") != null) {
    if ($(".datepicker").length > 0) {
        $(".datepicker").datepicker({
            showOn: 'both',
            buttonImage: '../images/calendar.gif',
            buttonImageOnly: false,
            dateFormat: 'yy-mm-dd',
            changeYear: true,
            changeMonth: false
            //showButtonPanel: true
        });
    }
}



/**
 * 將 datetime 改成 格式 yyyy/MM/dd 帶0在前方
 * @param {any} date
 */
function getYearMonthDayByDate(date) {
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    return date.getFullYear() + "/" + month + "/" + strDate;
}

/**
 * 將 datetime 改成 格式 yyyy-MM-dd hh:mm:ss 帶0在前方
 * @param {any} date
 */
function getNowFormatDate(date) {
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
        + " " + date.getHours() + seperator2 + date.getMinutes()
        + seperator2 + date.getSeconds();
    return currentdate;
}



/**
 * ------------------------------------------------------------------------
 * datatables
 * ------------------------------------------------------------------------
 */

/**
 * 中文化 預設class name formList 參數 class name , 第幾陣列為功能列
 * @param {any} css
 * @param {any} co
 */
function setTableList(css, co) {
    if (css == null) {
        css = ".formList";
    }
    if (co == null) {
        co = 0;
    }
    $(css).DataTable({
        "language": {
            "processing": "處理中...",
            "loadingRecords": "載入中...",
            "lengthMenu": "顯示 _MENU_ 項結果",
            "zeroRecords": "沒有符合的結果",
            "info": "顯示第 _START_ 至 _END_ 項結果，共 _TOTAL_ 項",
            "infoEmpty": "顯示第 0 至 0 項結果，共 0 項",
            "infoFiltered": "(從 _MAX_ 項結果中過濾)",
            "infoPostFix": "",
            "search": "搜尋:",
            "paginate": {
                "first": "第一頁",
                "previous": "上一頁",
                "next": "下一頁",
                "last": "最後一頁"
            },
            "aria": {
                "sortAscending": ": 升冪排列",
                "sortDescending": ": 降冪排列"
            }
        },
        // 參數設定[註1]
        "bPaginate": true, // 顯示換頁
        "searching": true, // 顯示搜尋
        "info": true, // 顯示資訊
        "fixedHeader": true, // 標題置頂
        "bJQueryUI": true,
        "iDisplayLength": 25,
        "order": [[0, "desc"]],
        "columnDefs": [{
            targets: [co],
            orderable: false
        }]
    });

}


/**
 * ------------------------------------------------------------------------
 * cookie
 * ------------------------------------------------------------------------
 * */

function setCookie(day, name,value) {
    expire_days = day; // 過期日期(天)
    var d = new Date();
    d.setTime(d.getTime() + (expire_days * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = name + " = " + value + "; " + expires + '; domain=' + window.location.hostname+'; path=/';
}


function parseCookie() {
    var cookieObj = {};
    var cookieAry = document.cookie.split(';');
    var cookie;

    for (var i = 0, l = cookieAry.length; i < l; ++i) {
        cookie = jQuery.trim(cookieAry[i]);
        cookie = cookie.split('=');
        cookieObj[cookie[0]] = cookie[1];
    }

    return cookieObj;
}


function getCookieByName(name) {
    var value = parseCookie()[name];
    if (value) {
        value = decodeURIComponent(value);
    }

    return value;
}

/**
 * ------------------------------------------------------------------------
 * uuid
 * ------------------------------------------------------------------------
 */
function _uuid() {
    var d = Date.now();
    if (typeof performance !== 'undefined' && typeof performance.now === 'function') {
        d += performance.now(); //use high-precision timer if available
    }
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });
}

function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}

function NewGuid() {
    return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
}

function NewGuid2() {
    var guid = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        guid += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
            guid += "-";
    }
    return guid;
}


/**
 * ------------------------------------------------------------------------
 * LOG
 * ------------------------------------------------------------------------
 */

/**
 * 供全域log
 * @param {any} value
 */
function all_console_log(value) {
    if (Debug) {
        console.log(value);
    }
}

/**
 * ------------------------------------------------------------------------
 * Loading page
 * ------------------------------------------------------------------------
 */

/**
 * 開啟Loading page  需搭配css like
 * .loaderBG{
 *     width: 100vw;
 *     height: 100vh;
 *     position: fixed;
 *     z - index: 9998;
 *     background - color: white;
 *     opacity: 0.5;
 *     top: 0px;
 *     left: 0px;
 * }
 * .loader {
 *     border: 5px solid #f3f3f3; // Light grey 
 *     border - top: 5px solid #3498db; // Blue 
 *     border - bottom: 5px solid #3498db; // Blue 
 *     border - radius: 50 %;
 *     width: 50px;
 *     height: 50px;
 *     animation: spin 2s linear infinite;
 *     position: fixed;
 *     z - index: 9998;
 *     top: 0px;
 *     left: 0px;
 *     right: 0px;
 *     bottom: 50px;
 *     margin: auto;
 * }
 * */

function startLoadingPage() {
    $("body").append('<div class="loaderBG"></div>');
    $("body").append('<div class="loader"></div>');
}
/**
 * 關閉Loading page  
 * */
function stopLoadingPage() {
    $(".loaderBG").remove();
    $(".loader").remove();
}

/**
 * ------------------------------------------------------------------------
 * upload file
 * ------------------------------------------------------------------------
 */

/**
 * 放入'上傳 flie 檔案 在指定的.addh 放預設圖
 * @param {any} value
 */
//function validateFile(value) {
//    var classname = '.addh';
//    validateFile(value, classname);
//    //$('.addh').empty();
//    //var fi = value.files.length;
//    //for (var i = 0; i < fi; i++) {
//    //    $('.addh').append('<p>' + value.files[i].name + '</p>')
//    //    var ex = value.files[i].name.split('.')
//    //    if (ex.length > 1) {
//    //        var te = ex[1].toLowerCase()
//    //        if (te == "pdf") {
//    //            $('.addh').append("<i class='fas fa-file-pdf'></i>")
//    //        } else if (te == "doc" || te == "docx") {
//    //            $('.addh').append("<i class='fas fa-file-word'></i>")
//    //        }
//    //        else if (te == "ppt" || te == "pps") {
//    //            $('.addh').append("<i class='fas fa-file-powerpoint'></i>")
//    //        }
//    //        else if (te == "jpg" || te == "jpeg") {
//    //            var img = window.URL.createObjectURL(value.files[i])
//    //            $('.addh').append("<img style='width: 100%;' src='" + img + "' />")
//    //        } else if (te == "gif") {
//    //            var img = window.URL.createObjectURL(value.files[i])
//    //            $('.addh').append("<img style='width: 100%;' src='" + img + "' />")
//    //        } else if (te == "png" || te == "bmp") {
//    //            var img = window.URL.createObjectURL(value.files[i])
//    //            $('.addh').append("<img style='width: 100%;' src='" + img + "' />")
//    //        } else {
//    //            $('.addh').append("<i class='fas fa-file'></i>")
//    //        }
//    //    } else {

//    //    }

//    //}
//}

/**
 * 放入'上傳 flie 檔案 在指定的 classname 放預設圖 
 * @param {any} value
 * @param {any} classname
 */
function validateFile(value,classname) {
    $(classname).empty();
    var fi = value.files.length;
    for (var i = 0; i < fi; i++) {
        $(classname).append('<p>' + value.files[i].name + '</p>')
        var ex = value.files[i].name.split('.')
        if (ex.length > 1) {
            var te = ex[1].toLowerCase()
            if (te == "pdf") {
                $(classname).append("<i class='fas fa-file-pdf'></i>")
            } else if (te == "doc" || te == "docx") {
                $(classname).append("<i class='fas fa-file-word'></i>")
            }
            else if (te == "ppt" || te == "pps") {
                $(classname).append("<i class='fas fa-file-powerpoint'></i>")
            }
            else if (te == "jpg" || te == "jpeg") {
                var img = window.URL.createObjectURL(value.files[i])
                $(classname).append("<img style='width: 100%;' src='" + img + "' />")
            } else if (te == "gif") {
                var img = window.URL.createObjectURL(value.files[i])
                $(classname).append("<img style='width: 100%;' src='" + img + "' />")
            } else if (te == "png" || te == "bmp") {
                var img = window.URL.createObjectURL(value.files[i])
                $(classname).append("<img style='width: 100%;' src='" + img + "' />")
            } else {
                $(classname).append("<i class='fas fa-file'></i>")
            }
        } else {

        }

    }
}

function validateFileHaveCancle(value, classname, inputId) {
    validateFile(value, classname);
    if (value.files.length > 0) {
        $(classname).append("<a href=\"javascript: btnimagedelete('" + classname + "','" + inputId + "'); \" class='btn btn-sm btn-danger'><i class='fa fa-trash-o'></i> 刪除</a>")
    }
}

function validateFileHaveCancleAndHidden(value, classname, inputId,HiddenId) {
    validateFile(value, classname);
    if (value.files.length > 0) {
        $(classname).append("<a href=\"javascript: btnimagedeletehidden('" + classname + "','" + inputId + "','" + HiddenId+"'); \" class='btn btn-sm btn-danger'><i class='fa fa-trash-o'></i> 刪除</a>")
    }
}


//function validateFileHaveCancle(value, classname,inputId) {
//    $(classname).empty();
//    var fi = value.files.length;
//    for (var i = 0; i < fi; i++) {
//        $(classname).append('<p>' + value.files[i].name + '</p>')
//        var ex = value.files[i].name.split('.')
//        if (ex.length > 1) {
//            var te = ex[1].toLowerCase()
//            if (te == "pdf") {
//                $(classname).append("<i class='fas fa-file-pdf'></i>")
//            } else if (te == "doc" || te == "docx") {
//                $(classname).append("<i class='fas fa-file-word'></i>")
//            }
//            else if (te == "ppt" || te == "pps") {
//                $(classname).append("<i class='fas fa-file-powerpoint'></i>")
//            }
//            else if (te == "jpg" || te == "jpeg") {
//                var img = window.URL.createObjectURL(value.files[i])
//                $(classname).append("<img style='width: 100%;' src='" + img + "' />")
//            } else if (te == "gif") {
//                var img = window.URL.createObjectURL(value.files[i])
//                $(classname).append("<img style='width: 100%;' src='" + img + "' />")
//            } else if (te == "png" || te == "bmp") {
//                var img = window.URL.createObjectURL(value.files[i])
//                $(classname).append("<img style='width: 100%;' src='" + img + "' />")
//            } else {
//                $(classname).append("<i class='fas fa-file'></i>")
//            }
//            $(classname).append("<a href=\"javascript: btnimagedelete('" + classname + "','" + inputId+"'); \" class='btn btn-sm btn-danger'><i class='fa fa-trash-o'></i> 刪除</a>")
            
//        } else {

//        }

//    }
//}

function btnimagedelete(classname, inputId) {
    $(classname).empty();
    var obj = document.getElementById(inputId);
    if (obj != null) {
        obj.outerHTML = obj.outerHTML;
    }
}
function btnimagedeletehidden(classname, inputId, HiddenId) {
    $(classname).empty();
    var obj = document.getElementById(inputId);
    if (obj != null) {
        obj.outerHTML = obj.outerHTML;
    }
    var obj2 = document.getElementById(HiddenId);
    if (obj2 != null) {
        obj2.value = ""
    }
}

/** keep live **/
SessionUpdater = (function () {
    var clientMovedSinceLastTimeout = false;
    var keepSessionAliveUrl = null;
    var timeout = 1 * 1000 * 60; // 1 minutes

    function setupSessionUpdater(actionUrl) {
        // store local value
        keepSessionAliveUrl = actionUrl;
        // setup handlers
        listenForChanges();
        // start timeout - it'll run after n minutes
        checkToKeepSessionAlive();
        //all_console_log("setupSessionUpdater");
    }

    function listenForChanges() {
        //all_console_log("listenForChanges");
        $("body").one("mousemove keydown", function () {
            clientMovedSinceLastTimeout = true;
        });
    }


    // fires every n minutes - if there's been movement ping server and restart timer
    function checkToKeepSessionAlive() {
        //all_console_log("checkToKeepSessionAlive");
        setTimeout(function () { keepSessionAlive(); }, timeout);
    }

    function keepSessionAlive() {
        //all_console_log("keepSessionAlive");
        // if we've had any movement since last run, ping the server
        if (clientMovedSinceLastTimeout && keepSessionAliveUrl != null) {
            $.ajax({
                type: "POST",
                url: keepSessionAliveUrl,
                success: function (data) {
                    // reset movement flag
                    clientMovedSinceLastTimeout = false;
                    // start listening for changes again
                    listenForChanges();
                    // restart timeout to check again in n minutes
                    checkToKeepSessionAlive();
                    all_console_log(data);
                    
                },
                error: function (data) {
                    all_console_log("Error posting to " & keepSessionAliveUrl);
                }
            });
        }
    }

    // export setup method
    return {
        Setup: setupSessionUpdater
    };

})();