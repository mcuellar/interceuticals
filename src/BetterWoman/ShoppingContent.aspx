<%@ Page Language="C#" MasterPageFile="~/Shared/LayoutSecure.Master" AutoEventWireup="true" CodeBehind="ShoppingContent.aspx.cs" Inherits="Interceuticals.BetterWoman.ShoppingContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BetterWoman Cross Sell</title>
    <script language="javascript" type="text/javascript">
        function validateProductSelection(source, args) {
            var prodChecked = 0;
            var f = document.forms[0];
            products = f.chkProducts.length

            for (i = 0; i < products; i++) {
                prodChecked += f.chkProducts[i].checked == true ? 1 : 0;
            }

            if (prodChecked > 0) {
                args.IsValid = true;
                return;
            }

            args.IsValid = false;
        }
</script>
</asp:Content>
<asp:Content ID="cShopping" ContentPlaceHolderID="cBody" runat="server">
    <div class="sidebar">
        <table border="0" width="265px">
            <tr>
            <asp:CustomValidator ID="valCheckBoxes" ClientValidationFunction="validateProductSelection" runat="server" ErrorMessage="You must select a product."></asp:CustomValidator>
                <td valign="top">
                    <%Response.Write(this.ProductImage); %>
                </td>
                <td align="left">
                    <%Response.Write(this.ProductContent); %><br>
                    <div align="center">
                    <asp:button runat="server" text="Add to Cart" ID="btnAddCart" 
                        ToolTip="Add Product to Shopping Cart" onclick="btnAddCart_Click" /><br><br>
                    <input type="button" onclick="history.go(-1)" value="Back" />
                    </div>
                </td>
            </tr>
            </table>
    </div>
    <div id="mainContainer">
         <table>
            <tr>
                <td>

                    <% this.RenderHtmlContent();%>
                    <br /><br />
                </td>
            </tr>
         </table>
    </div>      
</asp:Content>