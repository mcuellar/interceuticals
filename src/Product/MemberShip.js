
function processForm(s,pid)
{
	var f = document.forms[0];
	f.action = "MemberShip.aspx?thread=save&site=" + s + "&PID=" + pid;
	f.submit();
}


function closeWindow(s,pid)
{
	window.opener.parent.location = "default.aspx?thread=refresh&site=" + s + "&PID=" + pid;
	self.close();
}