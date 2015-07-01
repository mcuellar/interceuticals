<%@ Page Language="C#"  MasterPageFile="~/Shared/LayoutSecure.Master" AutoEventWireup="true" CodeBehind="PreCheckOut.aspx.cs" Inherits="Interceuticals.Order.PreCheckOut" %>
<asp:Content ID="cTitle" ContentPlaceHolderID="head" runat="server">
    <title>Pre-Checkout</title>
     <link href="../Common/ie.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../Shared/Global.js"></script>
</asp:Content>
<%--<asp:Content ID="cLeftSide" ContentPlaceHolderID="cLeftSide" runat="server">
    <img alt="Call Us at 888-686-2698" src="../Images/Shared/OrderLeftNav.png"/>
</asp:Content> --%>  
<asp:Content ID="contentOrder" ContentPlaceHolderID="cBody" runat="server">
<div id="mainContainer">
    <table cellpadding="0" cellspacing="10">
        <tr>
          <td>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td width="600px" align="left">
                        <%this.buildStep1();%>
                        <br/><br/>
                    </td>
                </tr>
            </table>
          </td>
        </tr>
        <tr>
            <td>
                 <div align="center">
                     <asp:LinkButton id="btnCheckout1" runat=server ToolTip="Final Checkout" onclick="btnCheckout_Click"><img src="../Images/Shared/buy_it_now_en.gif" /></asp:LinkButton>
                 </div>
                <!-- X-Selling Products Starts Here -->
                <table>
                     <tr>
                        <td><br /><br /><br /><br /><br />
                            <div class="labelUnderlined">You may also be interested in:</div><br />
                            <%Response.Write(this.CrossSellContent); %>
                        </td>
                    </tr>
                </table><br>                 
                    <div align="center">
                        <asp:LinkButton id="btnCheckout" runat=server ToolTip="Final Checkout" onclick="btnCheckout_Click"><img src="../Images/Shared/buy_it_now_en.gif" /></asp:LinkButton>
                    </div>
            </td>
        </tr>
     </table>
    </div>

<%
if(Request.ServerVariables["HTTP_HOST"] == "localhost")
	Response.Write("<div align=\"center\"><a href=\"../admin/promotionlist.aspx\">promotion list</a></div>");
%>
</asp:Content>