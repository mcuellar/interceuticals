//========================
//
//========================
function setPercentage(o)
{
	var percentageTextBox = document.getElementById("txtDiscountPercentage");
	var amountCheckBox    = document.getElementById("chkDiscountAmount");
	var amountTextBox      = document.getElementById("txtDiscountAmount");
	
	if(!o.checked)
	{
		percentageTextBox.disabled  = true;
	}
	else 
	{
		percentageTextBox.disabled	= false;
		percentageTextBox.focus();
		amountCheckBox.checked		= false;
		amountTextBox.disabled		= true
	}
}


function setAmount(o)
{
	var amountTextBox      = document.getElementById("txtDiscountAmount");
	var percentageCheckBox = document.getElementById("chkDiscountPercentage");
	var percentageTextBox  = document.getElementById("txtDiscountPercentage");
	if(!o.checked)
		amountTextBox.disabled = true;
	else 
	{
		amountTextBox.disabled		= false;
		amountTextBox.focus();
		percentageCheckBox.checked	= false;
		percentageTextBox.disabled  = true;
	}
}
