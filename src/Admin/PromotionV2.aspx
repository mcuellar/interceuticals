<%@ Page language="c#" Codebehind="PromotionV2.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Admin.PromotionV2" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<form id="f1" runat="server" method="post">
<input type="hidden" runat="server" id="txtPromotionId" value="0"> 
<asp:Label id=lblErrorMessage runat="server" Font-Size="Large" ForeColor="Red" Visible="False">Label</asp:Label>
<table cellpadding="10" cellspacing="0" width="725" class="tableWrapper" border="0">
 <tr>
  <td colspan="3" align="right"><table width="100%" cellpadding="2" cellspacing="0" background="/interceuticals/images/blue-bg.gif"><tr><td><a href="PromotionList.aspx"><font color="white">Promotion List</a></FONT></td></tr></table></td>
 </tr>
 <tr valign="top">
  <td title="Key should be cryptic and denote a series of campaigns TV-AD-18734"><b>Promotion Key</b><br><img src="/interceuticals/images/key.gif"><br><i>Key is typed into purchase form by customer at purchase time.</i></td>
  <td colspan="2"><asp:TextBox id=txtPromotionKey runat="server" Width="400px" class="textbox" title="promotion key TV-AD272007"></asp:TextBox><asp:RequiredFieldValidator id=RequiredFieldValidator2 runat="server" ErrorMessage="Please Enter Promotion Key" ControlToValidate="txtPromotionKey"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id=RegularExpressionValidator2 runat="server" ControlToValidate="txtPromotionKey" ErrorMessage="No spaces or non alpha numeric characters" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator></td>
 </tr>
 <tr valign="top">
  <td title="Promotion Name should be description - TV AD running on 2/7/2007"><b>Promotion Name</b><br><i>Descriptive Name assigned to distingish the campaign</i></td>
  <td colspan="2"><asp:TextBox id=txtPromotionName runat="server" Width="400px" class="textbox"></asp:TextBox><asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ErrorMessage="Please Name Promotion" ControlToValidate="txtPromotionName"></asp:RequiredFieldValidator></td>
 </tr>
 <tr valign="top">
  <td><b>Promotion Description</b><br><i>Explain in detail what this campign is/does/represents</i></td>
  <td colspan="2"><TEXTAREA rows=2 cols=34 id=txtPromotionDescription name=TEXTAREA1 runat="server" style="WIDTH: 400px; HEIGHT: 38px" class="textbox"></TEXTAREA></td>
 </tr>
 <tr>
  <td colspan="2"><b>Run Dates</b><br><i>Please select the dates this campaign will run. If no end date is entered, it will run continously</i></td>
 </tr>
 <tr valign="top">
  <td><table><tr valign="top"><td nowrap><b>Start Date</b></td><td><asp:Calendar id=cldStartDate runat="server" Width="115px" BorderStyle="Solid" NextPrevFormat="ShortMonth" BackColor="White" ForeColor="Black" CellSpacing="1" Height="120px" Font-Size="9pt" Font-Names="Verdana" BorderColor="Black">
<TodayDayStyle ForeColor="White" BackColor="#999999">
</TodayDayStyle>

<DayStyle BackColor="#CCCCCC">
</DayStyle>

<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White">
</NextPrevStyle>

<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="SlateGray">
</TitleStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle></asp:Calendar></td></tr></table>
  <td width=132><asp:TextBox id=txtStartDate runat="server" Width="90px" class="textbox"></asp:TextBox></td>
  <td rowspan="2"><b>Select Products</b><br><i>Select the products you want associated with this campaign<br> <asp:ListBox id="lstProducts" runat="server" Width="277px" Height="384px" SelectionMode="Multiple" class="textbox"></asp:ListBox></i></td>
 </tr>
 <tr valign="top">
  <td><table><tr valign="top"><td><b>End Date</b></td><td><asp:Calendar id=cldEndDate runat="server" Width="144px" BorderStyle="Solid" NextPrevFormat="ShortMonth" BackColor="White" ForeColor="Black" CellSpacing="1" Height="72px" Font-Size="9pt" Font-Names="Verdana" BorderColor="Black">
<TodayDayStyle ForeColor="White" BackColor="#999999">
</TodayDayStyle>

<DayStyle BackColor="#CCCCCC">
</DayStyle>

<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White">
</NextPrevStyle>

<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="SlateGray">
</TitleStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle></asp:Calendar></td>
</tr></table>
  <td width=132><asp:TextBox id=txtEndDate runat="server" Width="90px" class="textbox"></asp:TextBox></td>
 </tr>
 <tr valign="top">
  <td><b>Number of Uses</b><BR><i>How many times do you want this promotion to be used? Leave blank for campaigns that will not be limited by number of uses.</i></td>
  <td colspan="2"><asp:TextBox id=txtNumberOfUses runat="server" Width="72px" class="textbox"></asp:TextBox><asp:RegularExpressionValidator id=RegularExpressionValidator1 runat="server" ControlToValidate="txtNumberOfUses" ErrorMessage="Please enter in a numeric value." ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
 </tr>
 <tr valign="top">
  <td><b>Minimum Purchase Amount</b><br><i>Does this 
      campaign require the user to purchase a certain dollar value?</i></td>
  <td colspan="2"><asp:TextBox id=txtMinimumPurchaseAmount runat="server" Width="72px" class="textbox"></asp:TextBox></td>
 </tr>
 <tr>
  <td colspan="3"><b>Discount Amount</b><i> - Please enter how you want to discount this campaign</i></td>
 </tr>
 <tr>
  <td><table cellpadding="0" cellspacing="0" width="100%"><tr><td width="90%">&nbsp;&nbsp;Percentage Discount - <i> <font color="gray">take a % off</font></i></td><td><asp:CheckBox id="chkDiscountPercentage" runat="server" onclick="javascript:setPercentage(this)"></asp:CheckBox></td></tr></table></td>
  <td colspan="2"><asp:TextBox id=txtDiscountPercentage runat="server" Width="48px" Enabled="False" class="textbox"></asp:TextBox></td>
 </tr>
 <tr>
  <td><table cellpadding="0" cellspacing="0" width="100%"><tr><td width="90%">&nbsp;&nbsp;Discount Amount - <i> <font color="gray">take a $ value off</font></i></td><td><asp:CheckBox id="chkDiscountAmount" runat="server"  onclick="javascript:setAmount(this)"></asp:CheckBox></td></tr></table></td>
  <td colpsan="2" width=132><asp:TextBox id=txtDiscountAmount runat="server" Width="48px" Enabled="False" class="textbox"></asp:TextBox></td>
 </tr>
 <tr valign="top">
  <td><b>Active</b><br><i>If the checkbox is checked, this campain is available for use by your customers. The checkbox indicates that the campaign is <font color="red">activate</font>.</i></td>
  <td colspan="2"><asp:CheckBox id=chkActivateImmedietly runat="server"></asp:CheckBox></td>
 </tr>
 <tr>
  <td colspan="4" align="center"><asp:Button id=btnSave runat="server" Text="Save Campaign / Promotion"></asp:Button></td>
 </tr>
 <tr>
  <td colspan="4" align="center"><asp:RegularExpressionValidator id=RegularExpressionValidator3 runat="server" ControlToValidate="txtPromotionKey" ErrorMessage=" ** Your promtion key has invalid characters. Please use ONLY numbers & letters.a-z,A-Z,0,1,2,3,4,5,6,7,8,9" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator></td>
 </tr>
</table>
</form>
<%
this.m_page.End();
%>























