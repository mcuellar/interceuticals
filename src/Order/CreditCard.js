
function submitForms()
{
	history.back();
}

function setProgressLabel()
{
    var msg = "Your order is processing ... please wait ....";
    
    var innerHtml = "<font color='red'><b>";
    innerHtml += msg;
    innerHtml += "</b></font>";

    try
    {
     document.getElementById("lblProgress").innerHTML = innerHtml;
     document.f1.btnSubmit.disabled = true;
     document.f1.submit();
    }
    catch(e)
    {
      alert("Error setting an error label: " + e);
    }
}	