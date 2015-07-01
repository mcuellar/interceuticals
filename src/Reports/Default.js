
function enableDropDown(o)
{
	var partnerDD    = document.getElementById("ddPartner");
	var lineOrderDD = document.getElementById("ddLineOrders");
	if(o.id == "partner")
	{
		partnerDD.disabled = false;
		lineOrderDD.disabled = true;
	}
	
	if(o.id == "lineOrder") 
	{
		partnerDD.disabled = true;
		lineOrderDD.disabled = false;
	}
}
