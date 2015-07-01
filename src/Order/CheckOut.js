
//=================================
//
//=================================
function setShipping(o)
{
    //try {
        
        var f = document.forms[0];

        //alert(f.ctl00$cBody$txtFirstName.value);

        var selectedState = "";


        if (o.checked) {
            $('#ctl00_cBody_ddShippingCountry option[selected="selected"]').removeAttr("selected");
            $('#ctl00_cBody_ddShippingCountry option[value="' + $('#ctl00_cBody_ddCountry').val() + '"]').attr("selected", "selected");
        }
    
         // trigger must happen before state is selected
        $('#ctl00_cBody_ddShippingCountry').trigger("change");
        
        if (f.ctl00$cBody$ddState.selectedIndex > 0)
            f.ctl00$cBody$ddStateShip.selectedIndex = f.ctl00$cBody$ddState.selectedIndex;

        f.ctl00$cBody$txtShippingFirstName.value = o.checked ? f.ctl00$cBody$txtFirstName.value : "";
        f.ctl00$cBody$txtShippingLastName.value = o.checked ? f.ctl00$cBody$txtLastName.value : "";
        f.ctl00$cBody$txtShippingEmailAddress.value = o.checked ? f.ctl00$cBody$txtEmailAddress.value : "";
        f.ctl00$cBody$txtShippingAddress.value = o.checked ? f.ctl00$cBody$txtAddress.value : "";
        //f.txtShippingCountry.value = o.checked ? selectedCountry : "";
        f.ctl00$cBody$txtShippingCity.value = o.checked ? f.ctl00$cBody$txtCity.value : "";
        $('#ctl00_cBody_txtShippingStateProvince').val($('#ctl00_cBody_txtStateProvince').val());
        f.ctl00$cBody$txtShippingZipPostalCode.value = o.checked ? f.ctl00$cBody$txtZipPostalCode.value : "";
        f.ctl00$cBody$txtShippingPhone.value = o.checked ? f.ctl00$cBody$txtPhone.value : "";

        $('#ctl00_cBody_ddStateShip').trigger("change");
        $('.textbox').trigger("blur");
        
   // }
    //catch (e) {
      //  alert("Error in setShipping: " + e);
   // }

}

//===============================
//
//===============================
function updatePricing()
{
    var shippingCost = document.getElementById("ctl00_cBody_ddShippingMethods");
    var shippingSpan = document.getElementById("shippingTotal");
    var cartTotal = document.getElementById("cartTotal");
    var totalSpan = document.getElementById("total");
    var cost = shippingCost.options[shippingCost.selectedIndex].getAttribute("data-cost");
    var shipState = document.getElementById("ctl00_cBody_ddStateShip");
    var state = shipState.options[shipState.selectedIndex].value;

    var tax = (state != "MA") ? 0 : 0.0625 * cartTotal.value;

    var showTotal = 0;
    $('#shippingTotal').text("$" + cost);
	showTotal = Number(cartTotal.value) + Number(cost) + tax;
	$('#total').text("$" + showTotal.toFixed(2));
}

//===============================
//
//===============================
function openShippingInfo()
{
	window.open("/dogztogz/content/helpcenter.aspx",null,'scrollbars=yes,menubar=no,height=800,width=1200,resizable=no,toolbar=no,location=no,status=no');
}

function validateShippingStateOrProvince(source, args)
{
    var selectedShipState = "";

    var f = document.forms[0];

    if (f.ctl00$cBody$ddStateShip.selectedIndex > 0)
        selectedShipState = f.ctl00$cBody$ddStateShip.options[f.selectedShipState.selectedIndex].value;

    if(selectedShipState != "")
    {
        args.IsValid = true;
        return;
    } 

    args.IsValid = false;	
}

function validateStateOrProvince(source, args)
{
    var selectedState = "";

    var f = document.forms[0];

    if (f.ctl00$cBody$ddState.selectedIndex > 0)
        selectedState = f.ctl00$cBody$ddState.options[f.ctl00$cBody$ddState.selectedIndex].value;

    if(selectedState != "")
    {
        args.IsValid = true;
        return;
    }


    args.IsValid = false;
    
}


//===============================
// Modal popup functions
//===============================

function showPopup() {
    try {
        var modalPopupBehavior = $find('programmaticModalPopupBehavior2');
        modalPopupBehavior.show();
    }
    catch (e) {
        alert(e)
    }

}


function hidePopup() {
    var modalPopupBehavior = $find('programmaticModalPopupBehavior2');
    modalPopupBehavior.hide();
}


//===============================
// Modal popup functions
//===============================
function setCookie(c_name, value, exdays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + exdays);
    var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
    document.cookie = c_name + "=" + c_value;

}

function getCookie(c_name) {
    var i, x, y, ARRcookies = document.cookie.split(";");
    for (i = 0; i < ARRcookies.length; i++) {
        x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
        y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x == c_name) {
            return unescape(y);
        }
    }
}

function deleteCookie(name) {
    var expired = new Date(today.getTime() - 24 * 3600 * 1000); // less 24 hours
    document.cookie = name + "=null; path=/; expires=" + expired.toGMTString();
}


var qs = (function (a) {
    if (a == "") return {};
    var b = {};
    for (var i = 0; i < a.length; ++i) {
        var p = a[i].split('=');
        if (p.length != 2) continue;
        b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
    }
    return b;
})(window.location.search.substr(1).split('&'));


function cartAbandonment() {
    /* Save fields */
    var billToFirstName = $('#ctl00_cBody_txtFirstName');
    var billToLastName = $('#ctl00_cBody_txtLastName');
    var billToAddress = $('#ctl00_cBody_txtAddress');
    var billToCity = $('#ctl00_cBody_txtCity');
    var billToState = $('#ctl00_cBody_ddState');
    var billToProvince = $('#ctl00_cBody_txtStateProvince');
    var billToZip = $('#ctl00_cBody_txtZipPostalCode');
    var billToPhone = $('#ctl00_cBody_txtPhone');
    var billToEmail = $('#ctl00_cBody_txtEmailAddress');
    var billToCountry = $('#ctl00_cBody_txtEmailAddress');

    var shipToFirstName = $('#ctl00_cBody_txtShippingFirstName');
    var shipToLastName = $('#ctl00_cBody_txtShippingLastName');
    var shipToAddress = $('#ctl00_cBody_txtShippingAddress');
    var shipToCity = $('#ctl00_cBody_txtShippingCity');
    var shipToState = $('#ctl00_cBody_ddStateShip');
    var shipToProvince = $('#ctl00_cBody_txtShippingStateProvince');
    var shipToZip = $('#ctl00_cBody_txtShippingZipPostalCode');
    var shipToPhone = $('#ctl00_cBody_txtShippingPhone');
    var shipToEmail = $('#ctl00_cBody_txtShippingEmailAddress');
    var shipToCountry = $('#ctl00_cBody_ddShippingCountry');

    var hearAboutUs = $('input[name="txtHowDidYouHear"]');
    var age = $('#mq_2');
    var promotion = $('#promotion');
    var comments = $('#ctl00_cBody_txtComments');

    caLock = 0;
    
    $('.textbox').blur(function() {
        var data = {
            BillToFirstName: billToFirstName.val(),
            BillToLastName: billToLastName.val(),
            BillToAddress: billToAddress.val(),
            BillToCity: billToCity.val(),
            BillToState: billToState.val(),
            BillToProvince: billToProvince.val(),
            BillToZip: billToZip.val(),
            BillToPhone: billToPhone.val(),
            BillToEmail: billToEmail.val(),
            BillToCountry: billToCountry.val(),
            ShipToFirstName: shipToFirstName.val(),
            ShipToLastName: shipToLastName.val(),
            ShipToAddress: shipToAddress.val(),
            ShipToCity: shipToCity.val(),
            ShipToState: shipToState.val(),
            ShipToProvince: shipToProvince.val(),
            ShipToZip: shipToZip.val(),
            ShipToPhone: shipToPhone.val(),
            ShipToEmail: shipToEmail.val(),
            ShipToCountry: shipToCountry.val(),
            ShoppingCartId: qs["SCID"],
            HearAboutUs: hearAboutUs.val(),
            Age: age.find("option:selected").text(),
            Promotion: promotion.val(),
            Comments: comments.val()
        };


        if (caLock == 0) {
            
            caLock = 1;

            $.ajax({
                type: 'POST',
                url: '/interceuticals/order/cartabandonment.aspx',
                data: data,
                success: function() {
                    caLock = 0;
                }
            });
        }

    });
}

function getStates(countryId, callback) {

    $.ajax({
        type: 'POST',
        url: '/interceuticals/InterWebServices.asmx/GetStates',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ countryId: countryId }),
        success: function(data) {
            callback(data);
        }
        
    });

}

function constructStatesDropdown(states) {
    var options = [];
    
    options.push('<option value="">Please Select</option>');
    for (var i = 0; i < states.length; i++) {
        var state = states[i];
        options.push('<option value="' + state.StateAbbreviation + '">' + state.StateName + '</option>');
    }

    return options.join("");
}

$(function () {

    $('#ctl00_cBody_ddStateShip').change(function () {
        if ($(this).val() == "MA") {
            $('.total .tax').show();
        } else $('.total .tax').hide();

        updatePricing();
    });

    $('#ctl00_cBody_ddStateShip').trigger("change");


    /* Cart Abandonment */
    cartAbandonment();

    /* Dropdowns */
    var Dropdowns = {};
    Dropdowns.States = null;

    // Default to US
    $('#ctl00_cBody_ddCountry option[value="222"], #ctl00_cBody_ddShippingCountry option[value="222"]').attr("selected", "selected");
    
    $('#ctl00_cBody_ddCountry, #ctl00_cBody_ddShippingCountry').change(function () {

        var countryId = $(this).val();
        var states = null;

        for (var i = 0; i < Dropdowns.States.length; i++) {
            if (Dropdowns.States[i].CountryId == countryId) states = Dropdowns.States[i].States;
        }

        if (states != null) {
            var options = constructStatesDropdown(states);
       
            var $select = $(this).parents("table").find(".states");
            $select.find("option").remove();
            $select.append(options);
            $(this).parents("table").find(".province").hide();
            $(this).parents("table").find(".province input").val("");
            $(this).parents("table").find(".stateSelect").show();
        } else {
            $(this).parents("table").find(".province").show();
            $(this).parents("table").find(".stateSelect").hide();
            $(this).parents("table").find(".stateSelect option:nth-child(2)").attr("selected", "selected"); // to override validation
        }

        var shipOptions = Dropdowns.ShippingOptions;
        var shipCountry = $('#ctl00_cBody_ddShippingCountry').val();
        if (shipCountry != 222 && shipCountry != 126) shipCountry = 0;

        var newOptions = shipOptions.filter(function (){return $(this).data("countryid") == shipCountry});

        $('#ctl00_cBody_ddShippingMethods option').remove();
        $('#ctl00_cBody_ddShippingMethods').append(newOptions);
        $('#ctl00_cBody_ddShippingMethods option:first-child').attr("selected", "selected");
        $('#ctl00_cBody_ddStateShip').trigger("change");
    });
    

    getStates(0, function (data) {
        Dropdowns.States = data.d;
        
        // Initial change 
        $('#ctl00_cBody_ddCountry, #ctl00_cBody_ddShippingCountry').trigger("change");
    });

    Dropdowns.ShippingOptions = $('#ctl00_cBody_ddShippingMethods option');
    



});


