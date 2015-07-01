<%@ Page language="c#" Codebehind="Links.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Admin.Links" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<br>
<br>
<table class="tableWrapper" cellpadding="3" cellspacing="0" width="100%">
 <tr>
  <td class="tablefont">[<a href="PromotionList.aspx">Manage your promotions</a>]</td>
  <td class="tableFont"><i>Enter Promotion Codes</i></td>
 </tr>
 <tr>
  <td class="tablefont">[<a href="Orders.aspx">Manage your orders</a>]</td>
  <td class="tableFont"><i>Order Look Up By Date, OrderId or Verisign Id</i></td>
 </tr>
 <tr>
  <td class="tableFont">[<a href="/interceuticals/reports/reportpicker.aspx">General Reporting</a>]</td>
  <td class="tableFont"><i>Used for general reporting</td>
 </tr>
</table>
<%
this.m_page.End();
%>