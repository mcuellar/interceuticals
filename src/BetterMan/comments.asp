<%@ Language=VBScript %>
<%
Option Explicit
If IsEmpty(Request.Form("recurse")) Then
'	Response.Redirect "./shopping_cart.asp"
End If
Dim conn
Dim RSPageText
Dim RSFooter
Dim PageText
Dim RSItems
Dim RSProducts
Dim OrderNum
Dim RSSession
Dim ShippingPrice
Dim InvoiceHdr
Dim InvoiceItems
Dim RSTotal
Dim strConnect
Dim Sess
Dim EdtDate
Dim EmailBody
%>
<!-- #include file="./script/PPlogon.inc" -->
<%
Sess = Request.QueryString("session")
set conn = Server.CreateObject("ADODB.Connection")
conn.Open strConnect
RSFooter="Built and Powered by PoleTech Systems"
'EdtDate = DateAdd("h", 3, Now())
conn.Execute "insert into PPProspects (FirstName, LastName, Email, " _
& "Phone, Address1, Address2, City, StateProv, Zip, Subject, Comments, " _
& "Country, CommentDate) " _
& " values ('" & Request.Form("firstName") & "', '" _
& Request.Form("lastName") & "', '" _
& Request.Form("email") & "', '" _
& Request.Form("phone") & "', '" _
& Request.Form("address1") & "', '" _
& Request.Form("address2") & "', '" _
& Request.Form("city") & "', '" _
& Request.Form("state") & "', '" _
& Request.Form("zip") & "', '" _
& Request.Form("subject") & "', '" _
& Request.Form("comments") & "', '" _
& Request.Form("country") & "', " _
& "'" & DateAdd("h", 3, Now()) & "')"
CreateEmail
SendEmail("johnw@poletechsystems.com")
SendEmail("pwishnow@interceuticals.com")
'SendEmail(Request.Form("EmailAddress"))
'SendEmail("jwielki@mediaone.net")
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">
<html>

<head>
<meta name="resource-type" content="document">
<meta name="description" content="Direct connection for your comments and suggestions.">
<meta name="keywords" content="impotence, incontinence, Viagra, testosterone, prostate symptoms, NuMAN">
<meta name="distribution" content="Global">
<meta name="copyright" content="Interceuticals, Inc. 1998">
<meta name="author" content>
<meta name="GENERATOR" content="Microsoft FrontPage 3.0">
<meta name="robots" content="Index">
<meta name="rating" content="General">
<title>Comments and Suggestions</title>
</head>

<body TEXT="#010101" BGCOLOR="#ffffff" LINK="#000080" VLINK="#551a8b" ALINK="#ff0000">
<div align="center"> 
  <table cellspacing="0" border="0" height="64" width="640">
    <tr></td>
    <h2>Your Comments have been sent to Interceuticals. </h2><br>
    To go back to BetterMANnow.com&nbsp;<a href src="regcopyfirst.html">Click Here</a>
   </td></tr>
  </table>
</div>
</body>
</html>
<%
'Session.Abandon
Function ConvertIt(StringToConvert, ReplaceChar, ConversionChar)
	Dim TempString
	Dim LastFound
	TempString = StringToConvert
	LastFound = instr(TempString, ReplaceChar)
	do until LastFound = 0
		TempString = left(TempString, LastFound - 1) & ConversionChar _
			& right(TempString, Len(TempString) - LastFound)
		LastFound = instr(TempString, ReplaceChar)
	loop
	ConvertIt = TempString
End Function
Function SendEmail(Address)
Dim objMail
Dim msgbody
set objMail=Server.CreateObject("CDONTS.NewMail")
objMail.From=Request.Form("email")
objMail.To=Address
objMail.Subject="BetterMAN Comments - Prospect"
objMail.body=EmailBody
objMail.Send
set objMail=nothing
End Function
Function WriteEmail 
Response.Write "Name: " & Request.Form("firstName") & " " & Request.Form("lastName") & "<br>"
Response.Write "Address1 : " & Request.Form("address1") & "  Phone : " & Request.Form("Phone1") & "<br>"
Response.Write "Address2 : " & Request.Form("address2") & "<br>"
Response.Write "City : " & Request.Form("city") & "<br>"
Response.Write "State/Province : " & Request.Form("state") & "<br>"
Response.Write "Zip : " & Request.Form("zip") & "<br>"
Response.Write "Country : " & Request.Form("country") & "<br>"
Response.Write "Email Address : " & Request.Form("email") & "<br>"
Response.Write "Subject : " & Request.Form("subject") & "<br>"
Response.Write "Comments : " & Request.Form("comments")
Response.Write "---------------------------------------------------------------------------------------------------------" & "<br>"
End Function
Function CreateEmail
EmailBody="Name: " & Request.Form("firstName") & " " & Request.Form("lastName") &  vbnewline _
& "Email Address : " & Request.Form("email") & "  Phone : " & Request.Form("phone") & vbnewline _
& "Address1 : " & Request.Form("address1") & vbnewline _
& "Address2 : " & Request.Form("address2") & vbnewline _
& "City : " & Request.Form("city") & vbnewline _
& "State/Province : " & Request.Form("state") & vbnewline _
& "Zip : " & Request.Form("zip") & vbnewline _
& "Country : " & Request.Form("country") & vbnewline _
& "Subject : " & Request.Form("subject") & vbnewline _
& "Comments : " & vbnewline _
& Request.Form("comments")
End Function
%> 