<%@ Register TagPrefix="OTCControls" Namespace="OTC.Web.Controls.DropDown" Assembly="OTC" %>
<%@ Register TagPrefix="OTCControlsList" Namespace="OTC.Web.Controls.ListBox" Assembly="OTC" %>
<%@ Page language="c#" Codebehind="CheckOut.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Order.CheckOut" %>
<%@ Page language="c#" Codebehind="CCEdit.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Verisign.CCEdit" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<table border="0" cellSpacing=0 cellPadding=1 width="100%">
 <tr>
  <td class="formHeader" colspan="5"><b>Complete Credit Card Info</b></td>
 </tr>
 <tr><td>&nbsp;</td></tr>
 <tr valign="top">
  <td width="20%">Select Card Type</td>
  <td width="40%"><OTCControls:otcdropdown id="ddCCType" runat="server" class="textbox" width="200px"></OTCControls:otcdropdown></td>
  <td rowspan="3" align="right"><%this.BuildCartTotals();%></td>
 </tr>
 <tr valign="top">
  <td>Card Number</td>
  <td><asp:TextBox id="txtCardNumber" runat="server" width="200px"></asp:TextBox></td>
 </tr>
 <tr>
  <td colspan="2"><asp:RequiredFieldValidator id=RequiredFieldValidator16 runat="server" ErrorMessage="Enter Card Number" ControlToValidate="txtCardNumber"></asp:RequiredFieldValidator></td>
 </tr>
 <tr valign="top">
  <td>Expiration</td>
  <td>
   <table cellpadding="1" cellspacing="0">
    <tr valign="top">
     <td>
      <table border="0" cellSpacing=0 cellPadding=0>
       <tr>
        <td><OTCControls:otcdropdown id="ddMonth" runat="server" class="textbox"  width="90px"></OTCControls:otcdropdown></td>
       </tr>
      </table>
     </td>
     <td>
     <table border="0" cellSpacing=0 cellPadding=0>
       <tr>
        <td><OTCControls:otcdropdown id="ddYear" runat="server" class="textbox"  width="92px"></OTCControls:otcdropdown></td>
       </tr>
      </table>
     </td>
    </tr>
   </table>
  </td>
 </tr>
</table>
<br>
<%
this.m_page.End();
%>

