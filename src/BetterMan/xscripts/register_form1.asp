<%
	Dim recipient,email,body,firstName,lastName,company,address1,address2,city,state,zip,country,phone,whereHeard,comments,contactType
	contactType = Request.QueryString("contactType")
	email       = Request.Form("email")
	firstName	= Request.Form("firstName")
	lastName	= Request.Form("lastName")
	company		= Request.Form("company")
	address1	= Request.Form("address1")
	address2	= Request.Form("address2")
	city		= Request.Form("city")
	state		= Request.Form("state")
	zip			= Request.Form("zip")
	country		= Request.Form("country")
	phone		= Request.Form("phone")
	whereHeard  = Request.Form("whereHeard")

	If Len(whereHeard) = 0 Then
		whereHeard = Request.Form("whereHeard")
	End If

	comments    = "Comments" &  ":^~^:" & Request.Form("comments")

	call SaveEmail()
	recipient = "service@interceuticals.com"

	Set mailer = Server.CreateObject("SMTPsvg.Mailer")
	mailer.FromName		= "BetterMAN.BetterWOMAN"
	mailer.FromAddress	= "info1@interceuticals.com"
	mailer.remoteHost   = "scriptmail.intermedia.net"
	'mailer.AddRecipient "chris@olympictcs.com","chris@olympictcs.com"
	mailer.AddRecipient "pwishnow@interceuticals.com","pwishnow@interceuticals.com"
	mailer.Subject		= "Product Order Form Reply"

	'=================================================================================================
	'Depricated
	'--------------
	'email = "service@interceuticals.com" '"service@interceuticals.com"   '"btester@wrightsoft.com" '
	'Dim JMail
	'Set JMail = Server.CreateObject("JMail.SMTPMail")
	'if Request.ServerVariables("SERVER_NAME") = "lubov.res.cmu.edu" then
	'	JMail.ServerAddress = "smtp.andrew.cmu.edu"
	'elseif Request.ServerVariables("SERVER_NAME") = "localhost" then
	'	JMail.ServerAddress = "smtp.gis.net"
	'else
	'	JMail.ServerAddress = "moltok.wrightsoft.com:25"
	'end if
	'JMail.Sender = "service@interceuticals.com"
	'JMail.SenderName = Request.Form("email")
	'JMail.Subject = "Product Order Form Reply"
	'JMail.AddRecipient email
	'JMail.AddRecipient "skramer@wrightsoft.com"
	'JMail.AddRecipient "service@interceuticals.com"
	'==================================================================================================

	body = "-----------------------------------------" & vbcrlf
	body = body & "Source Form: " & Request.QueryString("tag") & vbcrlf
	body = body & "Project: BetterMAN" & vbcrlf
	body = body & "-----------------------------------------" & vbcrlf
	body = body & "Contact Email: " & Request.Form("email") & vbcrlf
	body = body & "First Name: " & Request.Form("firstName") & vbcrlf
	body = body & "Last Name: " & Request.Form("lastName") & vbcrlf
	body = body & "Company: " & Request.Form("company") & vbcrlf
	body = body & "Address: " & Request.Form("address1") & vbcrlf
	body = body & "Address: " & Request.Form("address2") & vbcrlf
	body = body & "City: " & Request.Form("city") & vbcrlf
	body = body & "State: " & Request.Form("state") & vbcrlf
	body = body & "Zip: " & Request.Form("zip") & vbcrlf
	body = body & "Country: " & Request.Form("country") & vbcrlf
	body = body & "Contact Phone: " & Request.Form("phone") & vbcrlf
	body = body & "Where Heard: " & Request.Form("whereHeard") & vbcrlf
	body = body & "-------------------------------------" & vbcrlf
	body = body & REPLACE(comments,":^~^:"," : ")

	mailer.BodyText = body
	mailer.SendMail()
	mailer = null

	'If lcase(Request.QueryString("tag")) = "prize" then
	'	body = body & "Where heard: " & Request.Form("betterman") & vbcrlf
	'	body = body & "Comments: " & Request.Form("comments") & vbcrlf
	'else
	'	body = body & "Where heard: " & Request.Form("betterman") & vbcrlf
	'	body = body & "Subject: " & Request.Form("subject") & vbcrlf
	'	body = body & "Comments: " & Request.Form("comments") & vbcrlf
	'end if

	'On Error Resume Next

	'JMail.Execute
	if Err <> 0 then
		%>
			Error!!! Please contact your Webserver Administrator.

		<p>Try sending mail to
			<a href="mailto:support@interceuticals.com">support@interceuticals.com</a>
			using a conventional mail program and report this problem.
			Thank you very much!</p>
		<%
	else
		call thanks()
	End if
%>


<%
sub thanks()
%>
  <HTML>
<HEAD>
<TITLE>Thank You</TITLE>
</HEAD>

<style type="text/css">
h1 {font-family: Arial, Helvetica, sans-serif; font-size:18px; font-style: normal; line-height: 14px; font-weight: normal}
h2 {font-family: Arial, Helvetica, sans-serif; font-size:14px; font-style: normal; line-height: 14px; font-weight: normal}
p {font-family: Arial, Helvetica, sans-serif; font-size:12px; font-style: normal; line-height: 14px; font-weight: normal}
</style>
   <BODY BGCOLOR=#FFFFFF>

<H1><b>Thank You</b></H1>
<h2>Important notice: save <a href="mailto:info1@interceuticals.com">info1@interceuticals.com</a>
  in your email address book now to receive future notice about your winning of
  the prize, and our free bulletin and specials via email. Thank you. </h2>
   <HR>
<P> Your message has been sent. Thank You. Click here to go to the <A HREF="http://www.bettermannow.com/interceuticals/betterman/index.html">
  BetterMAN Home Page</A>.
</BODY></HTML>
<%end sub%>

<%
sub SaveEmail()
	Dim sql
	Set Conn= Server.CreateObject("ADODB.Connection")
	Conn.Open "Provider=SQLOLEDB;Persist Security Info=False;User ID=jstilwell1; Password=int2007; Initial Catalog=Interceuticals;Data Source=64.78.59.228"
	sql = "spInsertOTCContact "
	sql = sql & "@OTCSiteId = 7,"
	sql = sql & "@OTCContactTypeId = " & contactType & ","
	sql = sql & "@firstName = '" & REPLACE(firstName,"'","''") & "',"
	sql = sql & "@lastName = '" & REPLACE(lastName,"'","''") & "',"
	sql = sql & "@address1 = '" & REPLACE(address1,"'","''") & "',"
	sql = sql & "@address2 = '" & REPLACE(address2,"'","''") & "',"
	sql = sql & "@city = '" & REPLACE(city,"'","''") & "',"
	sql = sql & "@state = '" & REPLACE(state,"'","''") & "',"
	sql = sql & "@zip = '" & REPLACE(zip,"'","''") & "',"
	sql = sql & "@phoneNumber = '" & REPLACE(phone,"'","''") & "',"
	sql = sql & "@emailAddress = '" & REPLACE(email,"'","''") & "',"
	sql = sql & "@Page = '" + Request.QueryString("page") & "',"
	sql = sql & "@comment1 = '" & REPLACE(whereHeard,"'","''") & "',"
	sql = sql & "@comment2 = '" & REPLACE(company,"'","''") & "',"
	sql = sql & "@comment3 = '" & REPLACE(comments,"'","''") & "'"
	Conn.Execute(sql)
end sub
%>