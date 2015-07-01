<%@ Register TagPrefix="dtzDropDown" Namespace="OTC.Web.Controls.DropDown" Assembly="OTC" %>
<%@ Register TagPrefix="dtzListBox"  Namespace="OTC.Web.Controls.ListBox"  Assembly="OTC" %>
<%@ Page language="c#" Codebehind="Product.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Admin.Product" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
%>
<form id="f1" method="post" runat="server" enctype="multipart/form-data">
	<input type="hidden" id="txtProductId" runat="server" value="0"> <input type="hidden" id="txtSortChar" runat="server" value="A">
	<table border="0" width="100%">
		<tr>
			<td colspan="3"><div class="productDiv"><%this.DrawProducts();%></div>
			</td>
		</tr>
		<tr valign="top">
			<td class="tableNote" nowrap width="20%">Product Name</td>
			<td width="380"><asp:textbox id="txtProductName" runat="server" Width="280px" class="textbox"></asp:textbox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtProductName"></asp:RequiredFieldValidator></td>
			<td rowspan="15"><%=this.ImageTag%></td>
		</tr>
		<tr>
			<td class="tableNote">Category</td>
			<td width="380"><dtzdropdown:otcdropdown id="ddCategory" runat="server" class="textbox" width="280px" autopostback="true"></dtzdropdown:otcdropdown></td>
		</tr>
		<tr>
			<td class="tableNote">SKU</td>
			<td width="380"><asp:textbox id="txtSku" runat="server" Width="56px" class="textbox"></asp:textbox><asp:RequiredFieldValidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="*" ControlToValidate="txtPrice"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="*" ControlToValidate="txtSku"
					ValidationExpression="^-?\d+(\.\d{2})?$"></asp:RegularExpressionValidator></td>
		</tr>
		<tr>
			<td class="tableNote">Price</td>
			<td width="380"><asp:textbox id="txtPrice" runat="server" Width="56px" class="textbox">0.00</asp:textbox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPrice"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtPrice"
					ValidationExpression="^-?\d+(\.\d{2})?$"></asp:RegularExpressionValidator></td>
		</tr>
		<tr valign="top">
			<td class="tableNote">Description</td>
			<td width="380"><textarea id="txtDescription" name="txtDescription" rows="10" cols="43" runat="server" class="textbox"></textarea></td>
		</tr>
		<tr>
			<td class="tableNote">Photo</td>
			<td width="380"><input id="filePhoto" type="file" name="File1" runat="server" class="textbox" size="27"></td>
		</tr>
		<tr>
			<td><asp:Button id="btnDelete" runat="server" Text="Delete"></asp:Button>
			</td>
			<td width="380"><asp:Button id="btnSave" runat="server" Text="Save"></asp:Button>
			</td>
		</tr>
	</table>
</form>
<%
this.m_page.End();
%>
