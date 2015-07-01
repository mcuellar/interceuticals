<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Contact._Default" %>
<%
this.WriteHeader();
%>
<form id=f1 method=post runat="server">
<table>
  <tr>
    <td>Where did you hear about us?</TD>
    <td><asp:textbox id=txtHowDidYouHear runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Email Address</TD>
    <td><asp:textbox id=txtEmailAddress runat="server" Width="275px"></asp:textbox><asp:requiredfieldvalidator id=vldEmail runat="server" ErrorMessage="*" ControlToValidate="txtEmailAddress"></asp:requiredfieldvalidator></TD></TR>
  <tr>
    <td>First Name</TD>
    <td><asp:textbox id=txtFirstName runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Last Name</TD>
    <td><asp:textbox id=txtLastName runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Company</TD>
    <td><asp:textbox id=txtCompany runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Street Address</TD>
    <td><asp:textbox id=txtAddress runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>&nbsp;</TD>
    <td><asp:textbox id=txtAddress2 runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>City</TD>
    <td><asp:textbox id=txtCity runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>State</TD>
    <td><asp:textbox id=txtState runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Zip</TD>
    <td><asp:textbox id=txtZip runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Country</TD>
    <td><asp:textbox id=txtCountry runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Phone</TD>
    <td><asp:textbox id=txtPhone runat="server" Width="275px"></asp:textbox></TD></TR>
  <tr>
    <td>Subject</TD>
    <td><asp:textbox id=txtSubject runat="server" Width="275px"></asp:textbox><asp:requiredfieldvalidator id=vldSubject runat="server" ErrorMessage="*" ControlToValidate="txtSubject"></asp:requiredfieldvalidator></TD></TR>
  <tr valign="top">
    <td>Comments</td>
  <td><TEXTAREA rows=5 cols=30 id=txtComments name=txtComments runat="server"></TEXTAREA> 
<asp:RequiredFieldValidator id=vldComments runat="server" ErrorMessage="*" ControlToValidate="txtComments"></asp:RequiredFieldValidator> </td></tr>
 <tr>
  <td colspan="2" align="center"><asp:Button id=btnSave runat="server" Text="Submit"></asp:Button> </td>
 </tr></TABLE></FORM>
<%
this.WriteFooter();
%>