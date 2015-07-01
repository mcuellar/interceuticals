<%@ Page language="c#" Codebehind="Win3_bw.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Contact.Win3_bw" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<form id=f1 method=post runat="server">
<table cellpadding="0" cellspacing="0">
<tr>
    <td width="20"><img src="/interceuticals/betterwoman/Images/level2/white1.gif" width="20" height="21"></td>
    <td width="389"><img src="/interceuticals/betterwoman/Images/level2/white1a.gif" width="389" height="21"></td>
	</tr>
	<tr><!-- added <tr> tag -->
      <td width="20" valign="top"><img src="/interceuticals/betterwoman/Images/level2/white1.gif" width="20" height="21"></td>
      <td width="388" valign="top">
        <p><img src="/interceuticals/betterwoman/images/level2/win3header.gif" width="389" height="22"></p>
        <h2><b>of BetterWOMAN™—ENTER NOW!<br >
          A $105 Value!!</b> </h2>
        <p>To participate in this drawing, please follow these simple rules. All 
          communications will be kept confidential. Your name and address will NOT 
          be sold or distributed to other companies. The Drawing will be held monthly. </p>
        <p>At the end of each month, we will collect all entries for that month 
          and randomly pick one (1) lucky winner. Winners will be contacted via 
          email to confirm delivery address for your <b>3 FREE</b> bottles of BetterWOMAN. </p>
        <ol>
          <li> You must be at least 18 years old to enter. 
          <li>Enter email if you wish to receive free 
        e-Newsletters. 
          <li> One entry only per email or household. 
          <li>Please enter the following information.<A HREF="http://localhost/Interceuticals/Contact/Win3.aspx">http://localhost/Interceuticals/Contact/Win3.aspx</A></li>
        </ol>
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
    <td><asp:textbox id=txtFirstName runat="server" Width="250px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="*****" ControlToValidate="txtFirstName"></asp:requiredfieldvalidator></td></tr>
  <tr>
    <td nowrap align="right"><b>Last 
      Name:</b></td>
    <td><asp:textbox id=txtLastName runat="server" Width="250px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="*****" ControlToValidate="txtLastName"></asp:requiredfieldvalidator></td></tr>
  <tr>
    <td nowrap align="right"><b>Company:</b></td>
    <td><asp:textbox id=txtCompany runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>Street 
      Address:</b></td>
    <td><asp:textbox id=txtAddress runat="server" Width="250px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="*****" ControlToValidate="txtAddress"></asp:requiredfieldvalidator></td></tr>
  <tr>
    <td>&nbsp;</td>
    <td><asp:textbox id=txtAddress2 runat="server" Width="250px"></asp:textbox></td></tr>
  <tr>
    <td nowrap align="right"><b>City:</b></td>
    <td><asp:textbox id=txtCity runat="server" Width="250px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="*****" ControlToValidate="txtCity"></asp:requiredfieldvalidator></td></tr>
  <tr>
    <td nowrap align="right"><b>State:</b></td>
    <td><asp:textbox id=txtState runat="server" Width="30px" maxlength="2"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" ErrorMessage="*****" ControlToValidate="txtState"></asp:requiredfieldvalidator></td></tr>
  <tr>
    <td nowrap align="right"><b>Zip:</b></td>
    <td><asp:textbox id=txtZip runat="server" Width="60px" maxlength="5"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" ErrorMessage="*****" ControlToValidate="txtZip"></asp:requiredfieldvalidator></td></tr>
  <tr>
    <td nowrap align="right"><b>Country:</b></td>
    <td><asp:textbox id=txtCountry runat="server" Width="250px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" ErrorMessage="*****" ControlToValidate="txtCountry"></asp:requiredfieldvalidator></td></tr>
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
  <td colspan="2" align="center"><asp:Button id=btnSave runat="server" Text="Send it Now!"></asp:Button>&nbsp;<INPUT type=reset value=Reset></td>
 </tr></table>
 </form></CENTER>
  <p>Thank you for your participation. Check our web site monthly for news 
          updates and special offers. </p>
        <p>&nbsp;</p>
        <p align="left"><a href="#top"><img src="/interceuticals/betterman/Images/lev2/backtotop.gif" width="79" height="15" border="0" alt="Back to Top" ></a></p>
        <p align="left">&nbsp;</p>
<%
this.m_page.End();
%>




