//================================================
//
//================================================
function showMembership(o) {
    var membershipSpan = document.getElementById("membershipInfoActive");
    var autoshipCheck = document.getElementById("chkAutoship");
    try {
        var id = o.options[o.selectedIndex].value;
        var div = document.getElementById("div" + id);
        membershipSpan.innerHTML = div.innerHTML;
        autoshipCheck.disabled = false;
    }
    catch (e) {
        membershipSpan.innerHTML = "<br><br><b><font color=\"red\">Autoship is not available for this product offering.</font>";
        autoshipCheck.disabled = true;
        autoshipCheck.checked = false;
    }
}

function changeAutoShipState() {
    var autoshipCheck = document.getElementById("ctl00_cBody_chkAutoship");
    var memberInfo = document.getElementById("membershipInfoActive");

    if (autoshipCheck.checked == false) {
        if (memberInfo.style.display == "block") {
            memberInfo.style.display = "none";
        }
    }
    else
        memberInfo.style.display = "block";

}


function changeNotAutoShipState() {
    var autoshipCheck = document.getElementById("chkAutoship");
    var notAutoshipCheck = document.getElementById("chkNotAutoship");

    if (notAutoshipCheck.checked == false) {
        autoshipCheck.checked = true;
    }
    else {
        notAutoshipCheck.checked = true;
        autoshipCheck.checked = false;
    }

}

//================================================
//
//================================================
function openWindow(site) {
    var dd = document.getElementById("ddProducts");
    var id = dd.options[dd.selectedIndex].value;
    window.open("membership.aspx?site=" + site + "&PID=" + id, "parentWindow", "width=500,height=500,toolbar=0,resizable=0,location=0,status=0,menubar=0,directories=0")
}

function openWindow1(site, productId) {
    window.open("membership.aspx?site=" + site + "&PID=" + productId, "parentWindow", "width=500,height=500,toolbar=0,resizable=0,location=0,status=0,menubar=0,directories=0")
}

//================================================
//
//================================================
function hideMembership(o) {
    var selectedValue = o.value;
    var span = document.getElementById("spanPromotion");
    var site = document.getElementById("txtSite").value;

    //if(selectedValue == 611 || selectedValue == 614)
    //	span.className = "show"
    //else 
    //	span.className = "hidden";

    //	alert(span.className);

    if (selectedValue == 618 || selectedValue == 619) {
        span.className = "show";
        span.innerHTML = "**<a href=\"javascript:openWindow1('" + site + "','" + selectedValue + "')\">Please read to learn more about this 30-day membership program</a>";
    }

    if (selectedValue == 616 || selectedValue == 617) {
        span.className = "show";
        span.innerHTML = "<a href=\"javascript:openWindow('" + site + "','" + selectedValue + "')\">*Please read and learn about this 90-day membership program.</a></a>";
    }


    if (selectedValue == 611 || selectedValue == 614)
        span.className = "hidden";

}

//================================================
// Google Analytics function to track navigation among multiple domains.  
// Warning: ct100_cBody_ gets appended to the asp control when using a master page.
//================================================
function doRedirect() {
    var promotionString = "";
    var selection = document.getElementById("ctl00_cBody_ddProducts");
    var autoshipCheck = document.getElementById("ctl00_cBody_chkAutoship");
    var promotionKey = "";
    if (String(promotionKey.value).length > 0)
        promotionString = "&PRID=" + promotionKey.value;

    var str = document.referrer;

    //if there is no referrer then it's the initial page running from the IDE. Set it to 0.
    if (str.Length > 0)
        var isLocalhost = str.indexOf("localhost");
    else
        var isLocalhost = 0;


    var url = document.URL
    var additionalParams = url.substring(url.indexOf("?"));


    if (isLocalhost > -1)
        window.location = "setcart.aspx?" + additionalParams + "&PID=" + selection.options[selection.selectedIndex].value + "&wantsMembership=" + autoshipCheck.checked + (String(promotionString).length > 0 ? promotionString : "");
    else
        window.location = "https://www.interceuticals.com/interceuticals/Product/setcart.aspx?PID=" + selection.options[selection.selectedIndex].value + "&wantsMembership=" + autoshipCheck.checked + (String(promotionString).length > 0 ? promotionString : "");

}
