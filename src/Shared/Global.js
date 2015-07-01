//===============================
// Modal popup functions
//===============================

function showPopup() {
    var modalPopupBehavior = $find('programmaticModalPopupBehavior');
    modalPopupBehavior.show();
}


function hidePopup() {
    var modalPopupBehavior = $find('programmaticModalPopupBehavior');
    modalPopupBehavior.hide();
}


function redirectTo(destURL) {
    var url = document.URL
    var utmPos = url.indexOf("__utma=");
    var sitePos = destURL.indexOf("site=");

    var additionalParams = sitePos > -1 ? "&" + url.substring(utmPos) : "?" + url.substring(utmPos);

    if (utmPos > -1) {
        window.location = destURL + additionalParams;
    } else
        window.location = destURL;

}