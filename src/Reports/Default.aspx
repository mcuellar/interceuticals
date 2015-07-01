<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Reports._Default" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
this.m_page.HideWest = true;
%>
<br>
<form name="f1" method="post" runat="server">
	<input type="hidden" name="txtReportTypeId" id="txtReportTypeId" runat="server">
	<table width="100%" border="0" cellpadding="3" cellspacing="0" class="tableWrapper">
		<tr valign="top">
			<td class="gridHeader" width="50%">
				<b><asp:Label id="lblReportHeader" runat="server" Font-Names="Tahoma" Font-Size="X-Small"></asp:Label></b>&nbsp;:<i><asp:Label id="lblDescription" runat="server" Font-Names="Tahoma" Font-Size="X-Small"></asp:Label><br><br></i>
				Please select the dates in which you want this report to run.<br><br>
				<asp:CheckBox id="chkExport" runat="server" Text="Export to Excel <i>Will remember your setting</i>"></asp:CheckBox>
			</td>
			<td align="right" class="gridHeader">[ <a href="reportpicker.aspx">&lt;&lt; select report</a> ]</td>
		</tr>
		<tr>
		 <td>&nbsp;</td>
		</tr>
		<tr>
			<td>Start Date <br>
				<asp:Calendar id="cldStartDate" runat="server" BorderStyle="Solid" NextPrevFormat="ShortMonth"
					BackColor="White" Width="100px" ForeColor="Black" CellSpacing="1" Height="77px" Font-Size="9pt"
					Font-Names="Verdana" BorderColor="Black">
					<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
					<DayStyle BackColor="#CCCCCC"></DayStyle>
					<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
					<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
					<SelectedDayStyle ForeColor="White" BackColor="#FFCC00"></SelectedDayStyle>
					<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="Black" BackColor="#FFCC00"></TitleStyle>
					<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
				</asp:Calendar>
			</td>
			<td align="right">End Date <br>
			    <asp:Calendar id="cldEndDate" runat="server" BorderStyle="Solid" NextPrevFormat="ShortMonth" BackColor="White"
					Width="18px" ForeColor="Black" CellSpacing="1" Height="72px" Font-Size="9pt" Font-Names="Verdana" BorderColor="Black">
					<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
					<DayStyle BackColor="#CCCCCC"></DayStyle>
					<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
					<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
					<SelectedDayStyle ForeColor="White" BackColor="#FFCC00"></SelectedDayStyle>
					<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="Black" BackColor="#FFCC00"></TitleStyle>
					<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
				</asp:Calendar>
			</td>
		</tr>
		<tr><td>&nbsp;</td></tr>
		<tr>
			<td colspan="2" align="center"><asp:Button id="btnBuild" runat="server" Text="Select Report" class="button"></asp:Button></td>
		</tr>
		<tr><td>&nbsp;</td></tr>
	</table>
</form>
<%
this.m_page.End();
%>

