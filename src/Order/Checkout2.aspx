<%@ Page language="c#" MasterPageFile="~/Shared/Layout.Master" Codebehind="Checkout2.aspx.cs" AutoEventWireup="true" Inherits="Interceuticals.Order.Checkout2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccAjax" %>
<%@ Register TagPrefix="OTCControls" Namespace="OTC.Web.Controls.DropDown" Assembly="OTC" %>
<%@ Register TagPrefix="OTCControlsList" Namespace="OTC.Web.Controls.ListBox" Assembly="OTC" %>

<asp:Content ID="cTitle" ContentPlaceHolderID="head" runat="server">
    <title>Checkout</title>
     <link href="../Common/ie.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="Checkout.js"></script>
     </asp:Content>
<asp:Content ID="contentCheckout" ContentPlaceHolderID="cBody" runat="server">
<p>
Military Orders: To avoid any delays shipping to your military address, please type in APO or FPO for your city, choose AA, AE or AP from the pull-down menu for your state, type in your zip code, and finally select United States as your country.<br><br>
Your package will be shipped via US postal service. The estimated delivery time for US packages will be 7-10 business days for regular S/H and 5-7 business days for rush S/H. For international mails, the delivery time may vary depending on the country.<br><br>
</p>
<p>
Please note that all fields marked with an <font color="red">*</font> are required fields to complete your order. 

   <table border="0" width="100%">
    <tr valign="top">
     <td colspan="2" class="rowWrapper" height="25" valign="middle">Bill To: (on credit card statement)</td>
    </tr>
    <tr>
     <td class="productInfo" width=105 height=26><font color="red"><b>*</b></font>First Name:<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator></td>
     <td height=26><asp:TextBox id="txtFirstName" runat="server" class="textbox"></asp:TextBox> </td>
    </tr>
    </table>

      <table border="0" cellSpacing=0 cellPadding=0>
       <tr>
        <td><OTCControls:otcdropdown id="ddMonth" runat="server" class="textbox"  width="90px"></OTCControls:otcdropdown></td>
       </tr>
      </table>

<input type="hidden" value="<%=this.OriginalQueryString%>" id="txtOrginialQueryString" runat="server">
<%
if(Request.ServerVariables["HTTP_HOST"] == "localhost")
	Response.Write("<div align=\"center\"><a href=\"../admin/promotionlist.aspx\">promotion list</a></div>");
%>
</asp:Content>
