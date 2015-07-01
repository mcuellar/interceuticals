<%@ Page language="c#" Codebehind="Orders.aspx.cs" AutoEventWireup="false" EnableViewState="true" Inherits="Interceuticals.Admin.Reports.Orders" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<form id=f1 method=post runat="server">
<table><tr><td>[<a href="Links.aspx">Menu</a>]</td></tr></table>
<table width="100%">
  <tr>
    <td align=center><asp:calendar id=cldStartDate runat="server" bordercolor="Black" font-names="Verdana" font-size="9pt" height="86px" cellspacing="1" forecolor="Black" width="48px" backcolor="White" nextprevformat="ShortMonth" borderstyle="Solid">
<todaydaystyle forecolor="White" backcolor="#999999">
</TodayDayStyle>

<daystyle backcolor="#CCCCCC">
</DayStyle>

<nextprevstyle font-size="8pt" font-bold="True" forecolor="White">
</NextPrevStyle>

<dayheaderstyle font-size="8pt" font-bold="True" height="8pt" forecolor="#333333">
</DayHeaderStyle>

<selecteddaystyle forecolor="White" backcolor="#333399">
</SelectedDayStyle>

<titlestyle font-size="12pt" font-bold="True" height="12pt" forecolor="White" backcolor="#333399">
</TitleStyle>

<othermonthdaystyle forecolor="#999999">
</OtherMonthDayStyle></asp:calendar></td>
    <td align=center><asp:calendar id="cldEndDate" runat="server" borderstyle="Solid" nextprevformat="ShortMonth" backcolor="White" width="112px" forecolor="Black" cellspacing="1" height="88px" font-size="9pt" font-names="Verdana" bordercolor="Black">
<todaydaystyle forecolor="White" backcolor="#999999">
</TodayDayStyle>

<daystyle backcolor="#CCCCCC">
</DayStyle>

<nextprevstyle font-size="8pt" font-bold="True" forecolor="White">
</NextPrevStyle>

<dayheaderstyle font-size="8pt" font-bold="True" height="8pt" forecolor="#333333">
</DayHeaderStyle>

<selecteddaystyle forecolor="White" backcolor="#333399">
</SelectedDayStyle>

<titlestyle font-size="12pt" font-bold="True" height="12pt" forecolor="White" backcolor="#333399">
</TitleStyle>

<othermonthdaystyle forecolor="#999999">
</OtherMonthDayStyle></asp:calendar></td></tr>
<tr>
 <td colspan="2"> 
  <table>
   <tr>
    <td class="textbox">OrderNumber:</td>
    <td><asp:TextBox id=TextBox1 runat="server"></asp:TextBox></td>
    <td><asp:Button id=btnOrderId runat="server" Text="Go Directly To Order !"></asp:Button> </td>
   </tr>
  </table><!--<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ErrorMessage="No Order Selected !" ControlToValidate="TextBox1" Font-Names="arial" Font-Size="X-Small" Font-Bold="True"></asp:RequiredFieldValidator>-->
         <br />&nbsp;<asp:Label id="lblVoidMessage" runat="server"></asp:Label>
 </td>
</tr></table></form>
<%
this.ShowOrders();
this.m_page.End();
%>