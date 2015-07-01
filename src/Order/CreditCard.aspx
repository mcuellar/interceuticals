<%@ Page language="c#" Codebehind="CreditCard.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Order.CreditCard" %>
<%
this.m_page.OpenHeader();
%>
<script src="//cdn.optimizely.com/js/199776721.js"></script>
<meta http-equiv="Expires" content="0"/>
<%
this.m_page.CloseHeader();
this.m_page.Start();
%>
<!-- Google Tag Manager -->
<noscript><iframe src="//www.googletagmanager.com/ns.html?id=GTM-MX6MWT"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<script>(function (w, d, s, l, i) {
w[l] = w[l] || []; w[l].push({
'gtm.start':
new Date().getTime(), event: 'gtm.js'
}); var f = d.getElementsByTagName(s)[0],
j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
'//www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
})(window, document, 'script', 'dataLayer', 'GTM-MX6MWT');</script>
<!-- End Google Tag Manager -->

<!--<form name="f1" id="f1" action="https://payflowlink.paypal.com" method="post" onsubmit="javascript:__utmLinkPost(this)">-->
<form name="f1" id="f1" action="PostTest.aspx" method="post">
 <input type="hidden" name="ORDERFORM" value="FALSE">
 <input type="hidden" name="SHOWCONFIRM" value="FALSE"> 
 <input type="hidden" name="METHOD" value="C">
 <input type="hidden" name="login" value="Interce">
 <input type="hidden" name="partner" value="Paypal">
 <input type="hidden" name="TYPE" value="S">
 <input type="hidden" name="name" value="<%=Member.FirstName + " " + Member.LastName%>">
 <input type="hidden" name="AMOUNT" value="<%=Order.TotalCost%>">
 <input type="hidden" name="ADDRESS" value="<%=Member.Address%>">
 <input type="hidden" name="CITY" value="<%=Member.City%>">
 <input type="hidden" name="STATE" value="<%=Member.State%>">
 <input type="hidden" name="EMAIL" value="<%=Member.EmailAddress%>">
 <input type="hidden" name="EXPDATE" value="<%=(Card.ExpirationMonth.ToString().Length == 1 ? "0" + Card.ExpirationMonth : Card.ExpirationMonth) + Card.ExpirationYear.Substring(2,2)%>">
 <input type="hidden" name="ZIP" value="<%=Member.Zip%>">
 <input type="hidden" name="CARDNUM" value="<%=Card.CardNumber%>">
 <input type="hidden" name="user1" value="<%=Order.OTCSiteMemberId%>">
 <input type="hidden" name="user2" value="<%=Order.OTCSalesOrderId%>">
<table cellpadding="3" cellspacing="0" width="100%">  
 <tr>
  <td>Please Confirm Your Order</td>
 </tr>
 <tr valign="top">
  <td colspan="2">
   <%this.WriteProductInformation();%>
  </td>
 </tr>
</table>
<table cellpadding="3" cellspacing="0">  
 <tr>
  <td>Email Address: </td>
  <td><%=Member.EmailAddress%></td>
 </tr>
 <tr>
  <td>First Name: </td>
  <td><%=Member.FirstName%></td>
 </tr>
 <tr>
  <td>Last Name: </td>
  <td><%=Member.LastName%></td>
 </tr>
 <tr>
    <td>Address:</td>
    <td><%=Member.Address%></td>
 </tr>
 <tr>
  <td>City: </td>
  <td><%=Member.City%></td>
 </tr>
 <tr>
  <td>State: </td>
  <td><%=Member.State%></td>
 </tr>
 <tr>
  <td>Zip: </td>
  <td><%=Member.Zip%></td>
 </tr>
 <tr>
  <td>Phone: </td>
  <td><%=Order.Phone%></td>
 </tr>
 <tr>
  <td>Country: </td>
  <td><%=Order.Country%></td>
 </tr>
 <tr>
  <td>Comments: </td>
  <td><%=Order.Comments%></td>
 </tr>
 <tr>
  <td><hr></td>
 </tr>
 <tr>
  <td>Shipping to:</td>
 </tr>
 <tr>
  <td>First Name: </td>
  <td><%=Order.ShippingFirstName%></td>
 </tr>
 <tr>
  <td>Last Name: </td>
  <td><%=Order.ShippingLastName%></td>
 </tr>
 <tr>
   <td>Address:</td>
   <td><%=Order.ShippingAddress%></td>
 </tr>
 <tr>
  <td>City: </td>
  <td><%=Order.ShippingCity%></td>
 </tr>
 <tr>
  <td>State: </td>
  <td><%=Order.ShippingState%></td>
 </tr>
 <tr>
  <td>Zip: </td>
  <td><%=Order.ShippingZip%></td>
 </tr>
 <tr>
  <td>Country: </td>
  <td><%=Order.ShippingCountry%></td>
 </tr>
 <tr>
  <td><hr></td>
 </tr>
 <tr>
  <td>Card Type: </td>
  <td><%=Card.CardType%></td>
 </tr>
 <tr>
  <td>Credit Number: </td>
  <td><%=Card.CardNumber%></td>
 </tr>
 <tr>
  <td>Expiration: </td>
  <td><%=(Card.ExpirationMonth.ToString().Length == 1 ? "0" + Card.ExpirationMonth : Card.ExpirationMonth) + " " + Card.ExpirationYear.Substring(2,2)%></td>
 </tr>
</table>
<table>
 <tr>
  <td><INPUT type=button value=Back onclick="submitForms()"></td>
  <td><INPUT type="button" name="btnSubmit" id="btnSubmit" onclick="javascript: setProgressLabel()" value="Click here to proceed" title="Please do not hit the back button on your web browser, processing could take several minutes. Thank you for your patience!"></td>
 </tr>
 <tr>
    <td align="right" colspan="2" align="right"><label id="lblProgress"></label></td>
 </tr>
<!-- <tr>
  <td colspan="2">Please <b><font color="red"><i>DO NOT</i></b></font> hit the back button! It may take several minutes for the transaction to complete. <br> Thank you for your patience.</td>
 </tr>-->
</table>
</form>
<div align="right">

<!-- MSN Code for purchase Conversion Page -->
<script>
    microsoft_adcenterconversion_domainid = 80240;
    microsoft_adcenterconversion_cp = 5050;
</script>
<script SRC="https://0.r.msn.com/scripts/microsoft_adcenterconversion.js"></script>
<noscript><IMG width=1 height=1 SRC="https://80240.r.msn.com/?type=1&cp=1"/></noscript><a href="http://advertising.msn.com/MSNadCenter/LearningCenter/adtracker.asp" target="_blank"><div class="hidden">::adCenter::</div></a>

<script language="JavaScript" type="text/javascript"> 
<!-- Yahoo! Search Marketing 
    window.ysm_customData = new Object();
    window.ysm_customData.conversion = "transId=<%=Order.OTCSalesOrderId%>,currency=US,amount=<%=Convert.ToDouble(Order.TotalCost).ToString("c").Replace("$","")%>";
var ysm_accountid = "1CC0B2QUH7IOUN24UH2O40R0B4G";
document.write("<SCR" + "IPT language='JavaScript' type='text/javascript' "
+ "SRC=//" + "srv2.wa.marketingsolutions.yahoo.com" + "/script/ScriptServlet" + "?aid=" + ysm_accountid
+ "></SCR" + "IPT>");
// -->
</script> 
</div>
<%
this.m_page.End();
%>



