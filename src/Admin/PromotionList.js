function deleteCampaign(id,name)
{
	var c = confirm("You are about to delete \"" + name + "\" from you campaign history. This action can only be completed if no sales for this campaign have been recorded.")
	if(c)
	{
		window.location = "promotionlist.aspx?thread=delete&PID=" + id;
	}
}

function addNew()
{
	window.location = "PromotionV2.aspx";
}