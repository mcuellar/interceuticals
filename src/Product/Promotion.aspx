<%@ Page language="c#" Codebehind="Promotion.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Product.Promotion" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<style type="text/css">
<!--
.style1 {color: #FF0000}
-->
</style>

<%
if(!(this.m_page.IsBetterWoman))
{
%>
<table cellpadding="3" cellspacing="0" border="0">
<tr>
  <td class="productPageFont"><p><strong>Welcome to our SECURED online store.</strong> For phone orders, please call 888-686-2698.<br />
  All products will be shipped without stating product names on the packages.</p>
  <p align="center"><img src="../BetterMan/Images/home/freetrialbutton.gif" alt="Free Trial &ndash; Join Now! button" width="246" height="27" /></p>
  <p>You will receive a full BetterMAN bottle for <span class="style1">FREE Trial</span> and <span class="style1">only pay $10.99 today</span> for s/h. You can use this bottle to jump-start the benefits by taking a loading dose of 2 capsules twice a day.</p>
  <p>If for whatever reason, you prefer not to continue using BetterMAN, simply call us at 888-686-2698 
within 20 days from the day you sign on this program to obtain a Return Merchandise 
Authorization (RMA) number, and mail the bottle back ( full or empty ) within 10 days after obtaining the RMA number. You will not be billed for one more cent.</p>
  <p>If you like to continue the product, you don&rsquo;t have to do anything. With this Free Trial, you also receive a FREE membership in our BetterMAN club with a <span class="style1">26% saving</span> for your future orders. After 20 days from the day you sign on for this program, you will automatically receive a new supply of 4 bottles of BetterMAN, and every 90 days thereafter, and you'll lock in the low price of <span class="style1">$33.74/btl</span> (compare with $44.99/btl), plus only <span class="style1">$6.99 for s/h</span> (compare with 10.99 s/h), charged to the credit card you provide today. You may cancel or customize your orders anytime before your next shipment. Suggested Dosage: Each bottle contains 40 capsules. 2 Capsules daily. Take a 3-day break between each bottle. Minimum dosage 4 bottles. Continue use thereafter for ongoing improvement and maintenance. You may also double the dosage for stronger benefits. </p>
  <p>Please note: One Free Trial bottle per household only. Standard s/h charge will apply for all non-US shipping addresses. Package returned without RMA number or received at the return address later than 25 days after the RMA being issued will be charged a regular cost of $44.99 for the Free Trial BetterMAN bottle. </p>
  <p>&nbsp;</p></td></tr>
    <tr><td align="center">
   <INPUT type=button value="Proceed To Order" onclick="javascript:doRedirect(620,'bm')">
  </td>
 </tr>
 </table>
<%
}
else
{
%>
 <table cellpadding="3" cellspacing="0" border="0">
  <tr>
   <td class="productPageFont"><p><strong>Welcome to our SECURED online store.</strong> For phone orders, please call 888-686-2698.<br />
   All products will be shipped without stating product names on the packages.</p>
   <p align="center"><img src="../BetterMan/Images/home/freetrialbutton.gif" alt="Free Trial &ndash; Join Now! button" width="246" height="27" /></p>
   <p>You will receive a full BetterWOMAN bottle for <span class="style1">FREE Trial</span> and <span class="style1">only pay $10.99 today</span> for s/h. You can use this bottle to jump-start the benefits by taking a loading dose of 2 capsules twice a day.</p>
   <p>If for whatever reason, you prefer not to continue using BetterWOMAN, simply call us at 888-686-2698 
   within 20 days from the day you sign on this program to obtain a Return Merchandise 
   Authorization (RMA) number, and mail the bottle back (full or empty) within 10 days after obtaining the RMA number. You will not be billed for one more cent.</p>
   <p>If you like to continue the product, you don&rsquo;t have to do anything. With this Free Trial, you also receive a FREE membership in our BetterWOMAN club with a <span class="style1">26% saving</span> for your future orders. After 20 days from the day you sign on for this program, you will automatically receive a new supply of 4 bottles of BetterWOMAN, and every 90 days thereafter, and you&rsquo;ll lock in the low price of <span class="style1">$26.24/btl</span> (compared with $34.99/btl), plus only <span class="style1">$6.99 for s/h</span> (compare with $10.99 s/h), charged to the credit card you provide today. You may cancel or customize your orders anytime before your next shipment. Suggested Dosage: Each bottle contains 40 capsules. 2 Capsules daily. Take a 3-day break between each bottle. Minimum dosage 4 bottles. Continue use thereafter for ongoing improvement and maintenance. You may also double the dosage for stronger benefits.&nbsp;&nbsp;&nbsp; </p>
   <p>Please note: </p>
   <ul>
        <li>      One Free Trial bottle per household only.&nbsp; </li>
        <li>Standard s/h charge will apply for all non-US shipping addresses.</li>
        <li>Package returned without RMA number or received at the return address later than 25 days after the RMA being issued will be charged a regular cost of $44.99 for the Free Trial BetterWOMAN bottle. </li>
  </ul>  
   <p>&nbsp;</p></td>
  </tr>
  <tr>
   <td align="center">
    <INPUT type=button value="Proceed To Order" onclick="javascript:doRedirect(621,'_bw')">
  </td>
 </tr>
 </table>
<%
}
%>
<script type="text/javascript" language="javascript">
var sc_project=1740123; 
var sc_invisible=1; 
var sc_partition=16; 
var sc_security="3d63102b"; 
</script>
  
<script type="text/javascript" language="javascript" src="http://www.statcounter.com/counter/counter.js"></script>
<noscript>
 <a href="http://www.statcounter.com/" target="_blank"><img  src="http://c17.statcounter.com/counter.php?sc_project=1740123&amp;java=0&amp;security=3d63102b&amp;invisible=1" alt="free web stats" border="0"></a>
</noscript>  <!-- End of StatCounter Code -->    <!-- Start of HitTail Code -->

<script src="http://13440.hittail.com/mlt.js" type="text/javascript"></script>    <!-- End of HitTail Code -->    <!-- Start of Google Analytics Code -->
<%
this.m_page.End();
%>

