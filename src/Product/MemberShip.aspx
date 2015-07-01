<%@ Page language="c#" Codebehind="MemberShip.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Product.MemberShip" %>
<html>
<head>
 <script language="javascript" src="/Interceuticals/Product/MemberShip.sct"></script>
 <script language="javascript" src="/Interceuticals/Product/MemberShip.js"></script>
 <title>Membership Program</title>
</head>
<body onLoad="<%=this.OnLoad%>" rightmargin="50" leftmargin="50" topmargin="50">
<form name="f1" method="post" runat="server">
<input type="hidden" name="site" value="<%=this.Site%>" id="site">
<input type="hidden" name="productId" value="<%=this.ProductId%>" id="productId">
<table cellpadding="10">
 <tr>
  <%
  if(this.ProductId < 618)
  {
   if(this.Site != "bw" && this.Site != "_bw")
   {
   %>
   <td><font face="verdana" size="2"><b>BetterMAN 90-day Membership Program </b> &ndash; When you order this 90-day-kit (4 bottles) today, 
    you will receive a FREE membership in the BetterMAN club for the future savings and convenience. After 90 days, you will 
    automatically receive a new supply of 4 bottles of BetterMAN, and every 90 days thereafter, and you'll lock in the low price
    of $134.97 (that is <font color="red">buy-3-get-1-FREE</font> for every shipment), plus only <font color="red">$6.99 for s/h</font> (compare with 10.99 s/h) charged to the credit card you provide 
      today. You have no obligation to meet any minimum purchase quantity and 
      can cancel or customize your order at anytime with a 7-day advanced notice 
      before next shipment.</font>  </td>
   <%
   }
   else
   {
   %>
   <td>
    <font face="verdana" size="2"><b>BetterWOMAN 90-day Membership Program </b> &ndash; When you order this 90-day-kit (4 bottles) today, 
    you will receive a FREE membership in the BetterWOMAN club for your future savings and convenience. After 90 days, you will 
    automatically receive a new supply of 4 bottles of BetterWOMAN, and every 90 days thereafter, and you’ll lock in the low price 
    of $104.97 (that is <font color="blue">buy-3-get-1-FREE</font> for every shipment), plus only <font color="blue">$6.99 for s/h</font> (compare with $10.99 s/h) charged to the credit card you provide 
    today. You have no obligation to meet any minimum purchase quantity and can cancel or customize your order at anytime with a 7-day advanced notice before next shipment.</font>  </td>
    <%
   }
  }
  else
  {
   if(this.Site != "bw" && this.Site != "_bw")
   {
   %>
   <td>
   <div align="center">Join today and <font color="red">save 16%</font> for your future shipment!</div><br><br>
   <font face="verdana" size="2"><b>BetterMAN 30-day Membership Program </b> &ndash; When
you order one (1) bottle of BetterMAN today, you will receive a FREE membership
in the BetterMAN club for your future savings and convenience. After 30 days,
you will automatically receive a new supply of one (1) bottle of BetterMAN, and
every 30 days thereafter, and you'll lock in the low price of <span
style='color:red'>$39.99/btl</span> plus only <span style='color:red'>$6.99 for
s/h</span> (that’s 16% saving per shipment as compared with the regular cost of
$44.99/btl plus $10.99 s/h) charged to the credit card you provide today. You
have no obligation to meet any minimum purchase quantity and can cancel or
customize your order at anytime with a 7-day advanced notice before next
shipment.</span></font>  </td>
   <%
   }
   else
   {
   %>
   <td>
    <div align="center">Join today and <font color="red">save 20%</font> for your future shipment!</div><br><br>
    <font face="verdana" size="2"><b>BetterWOMAN 30-day Membership Program </b> &ndash; When you order one (1) bottle of BetterWOMAN today, 
    you will receive a FREE membership in the BetterWOMAN club for your future savings and convenience. 
    After 30 days, you will automatically receive a new supply of one (1) bottle of BetterWOMAN, and every 30 days thereafter, 
    and you’ll lock in the low price of <font color="red">$29.99/btl</font> plus only <font color="red">$6.99</font> for s/h 
    (that’s a 20% saving per shipment as compared with the regular cost of $34.99/btl plus $10.99 s/h) charged to the credit card you provide today. 
    You have no obligation to meet any minimum purchase quantity and can cancel or customize your order at anytime with a 7-day advanced notice before next shipment. 
    (Standard s/h costs will apply for non-US shipping addresses.)</font>
    </td>
    <%
   }
  }
  %>
 </tr>
</table>
<table>
 <tr>
  <td><input type="radio" name="rdoMemberShip" value="1" id="rdoMemberShip" checked></td>
  <td><font face="verdana" size="2">Yes, I 
      want to participate in this membership for savings and convenience with 
      the understanding that I can cancel anytime.</font></td>
 </tr>
 <tr>
  <td><input type="radio" name="rdoMemberShip" value="0" id="rdoMemberShip"></td>
  <td><font face="verdana" size="2">No, I prefer placing the order myself.</font></td>
 </tr>
</table>
<table width="100%">
 <tr>
  <td align="right"><a href="javascript:processForm('<%=this.Site%>','<%=this.ProductId%>')"><font face="verdana" size="2">Back To Order</a></td>
 </tr>
</table>
</form>
</body>
</HTML>
