<%@ Page language="c#" Codebehind="Newsletter.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Contact.Newsletter" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<form id=f1 method=post runat="server">
<table cellpadding="0" cellspacing="0" border="0">
<tr>
      <td width="20" valign="top"><img src="/interceuticals/images/lev2/whiteheader.gif" width="20" height="43"></td>
      <td width="388" valign="top">
        <p><img src="/interceuticals/images/lev2/newsletterheader.gif" width="388" height="43"></p>
        <p>All customer information is confidential.</p>
        <p> <b>Please fill out the following information to receive our FREE Newsletter 
          with offers, news and information. Thank you.</b> </p>
        <p>&nbsp;</p>
      <tr></tr>
   </table>
<table height="20"><tr><td></td></tr></table>
<center>
<table border="0" width="200">
  <tr>
    <td align="right"><b>Where did you 
      hear about us?</b></td>
    <td><asp:textbox id=txtHowDidYouHear runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Email 
      Address:</b></td>
    <td><asp:textbox id=txtEmailAddress runat="server" Width="250px"></asp:textbox><asp:requiredfieldvalidator id=vldEmail runat="server" ErrorMessage="*****" ControlToValidate="txtEmailAddress"></asp:requiredfieldvalidator></td></tr>
  <tr>
    <td nowrap align="right"><b>First 
      Name:</b></td>
    <td><asp:textbox id=txtFirstName runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Last 
      Name:</b></td>
    <td><asp:textbox id=txtLastName runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Company:</b></td>
    <td><asp:textbox id=txtCompany runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Street 
      Address:</b></td>
    <td><asp:textbox id=txtAddress runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td>&nbsp;</td>
    <td><asp:textbox id=txtAddress2 runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>City:</b></td>
    <td><asp:textbox id=txtCity runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>State:</b></td>
    <td><asp:textbox id=txtState runat="server" Width="30px" maxlength="2"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Zip:</b></td>
    <td><asp:textbox id=txtZip runat="server" Width="60px" maxlength="5"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Country:</b></td>
    <td><asp:textbox id=txtCountry runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Phone:</b></td>
    <td><asp:textbox id=txtPhone runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Subject:</b></td>
    <td><asp:textbox id=txtSubject runat="server" Width="250px"></asp:textbox></td></tr>
  <tr valign="top">
    <td nowrap align="right"><b>Comments:</b></td>
  <td><TEXTAREA rows=5 cols=30 id=txtComments name=txtComments runat="server"></TEXTAREA></td>
  </tr>
 <tr>
  <td colspan="2" align="center"><asp:Button id=btnSave runat="server" Text="Send It Now!"></asp:Button>&nbsp;<INPUT type=reset value=Reset></td>
 </tr></table>
 </form>
<%
this.m_page.End();
%>
</CENTER>
