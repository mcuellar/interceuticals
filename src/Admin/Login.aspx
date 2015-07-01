<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Admin.Login" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<form name="f1" runat="server" method="post" id="Form1">
<table>
 <tr>
  <td class="tableFont">username: </td>
  <td><asp:textbox id=txtUserName runat="server" class="textbox"></asp:textbox></td>
 </tr>
 <tr>
  <td class="tableFont">password: </td>
  <td><input id=txtPassword type=password name=Password1 runat="server" class="textbox"></td>
 </tr>
 <tr>
  <td colspan="2"><asp:button id=btnSave runat="server" text="Click Here To Login"></asp:button></td>
 </tr>
</table>
</form>
<%
this.m_page.End();
%>



