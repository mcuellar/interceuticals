<%@ Page language="c#" Codebehind="Promotion.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Admin.Promotion" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<form id="f1" runat="server" method="post">
<table><tr><td>[<a href="Links.aspx">Menu</a>]</td></tr></table>
<table>
 <tr>
  <td><asp:Label id="Label5" runat="server" Width="163px" Font-Size="X-Small" Font-Names="verdana">Select Promotion</asp:Label></td>
  <td><asp:DropDownList id="ddPromotion" runat="server" Width="344px" autopostback="true"></asp:DropDownList></td>
 </tr>
 <tr>
  <td><asp:Label id="Label2" runat="server" Width="163px" Font-Size="X-Small" Font-Names="verdana">Promotion Name</asp:Label></td><td><asp:TextBox id="txtPromotionName" runat="server"></asp:TextBox></td>
 </tr>
 <tr>
  <td><asp:Label id="Label6" runat="server" Font-Names="verdana" Font-Size="X-Small" Width="128px">Promotion Key</asp:Label></td><td><asp:TextBox id="txtPromotionKey" runat="server"></asp:TextBox></td>
 </tr>	
 <tr valign="top">
  <td><asp:Label id="Label1" runat="server" Width="168px" Font-Size="X-Small" Font-Names="verdana">Promotion Description</asp:Label></td><td height=43><TEXTAREA rows=4 cols=39 id=txtPromotionDescription name=TEXTAREA1 runat="server">
</TEXTAREA></td>
 </tr>
 <tr>
  <td><asp:Label id="Label3" runat="server" Width="151px" Font-Size="X-Small" Font-Names="verdana">Discount Rate %</asp:Label></td>
  <td><asp:TextBox id="txtDiscountRate" runat="server" Width="40px"></asp:TextBox></td>
 </tr>
 <tr>
  <td><asp:Label id="Label4" runat="server" Width="139px" Font-Size="X-Small" Font-Names="verdana">Number Of Uses</asp:Label></td>
  <td><asp:TextBox id="txtNumberOfUses" runat="server" Width="40px"></asp:TextBox>&nbsp;	<asp:CheckBox id="chkInfinate" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Text="Infinate"></asp:CheckBox></td>
 </tr>
 <tr>
  <td><asp:Button id="btnDeletePromotion" runat="server" Text="Delete Promotion"></asp:Button></td>
  <td><asp:Button id="btnSave" runat="server" Text="Save Promotion"></asp:Button></td>
 </tr>
</table>
</form>
<%
this.m_page.End();
%>





