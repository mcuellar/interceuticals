<%@ Page language="c#" MasterPageFile="~/Shared/LayoutSecure.Master" Codebehind="CheckOut.aspx.cs" AutoEventWireup="false" EnableEventValidation="false" Inherits="Interceuticals.Order.CheckOut" %>
<%@ Register TagPrefix="OTCControls" Namespace="OTC.Web.Controls.DropDown" Assembly="OTC" %>
<%@ Register TagPrefix="OTCControlsList" Namespace="OTC.Web.Controls.ListBox" Assembly="OTC" %>

<asp:Content ID="cTitle" ContentPlaceHolderID="head" runat="server">
    <title>Checkout</title>
     <script type="text/javascript" src="Checkout.js"></script>
     <link href="../Common/ie.css" rel="stylesheet" type="text/css" />
     </asp:Content>
<asp:Content ID="contentCheckout" ContentPlaceHolderID="cBody" runat="server">
    <div id="mainContainer">
    <div id="checkout" class="<%=this.Website%>">
        
        <div id="banner">
            <div class="bw">
                <img src="/interceuticals/images/shared/left_betterwoman.png" align="left" />
                <h2>Since 2002, BetterWOMAN has helped thousands of women regain bladder control.</h2>
            </div>
            <div class="bm">
                <img src="/interceuticals/images/shared/left_betterman.png" align="left" />
                <h2>Since 1998, BetterMAN has helped thousands of men regain bladder control.</h2>
            </div>
        </div>

        <div id="cart">
            <%
                this.buildStep1();
            %>
            <div class="cart-error">
                <input type="hidden" value="<%=this.OriginalQueryString%>" id="txtOrginialQueryString" runat="server">
                <asp:Label id="lblErrorMessage" runat="server" Font-Size="X-Small" Font-Names="verdana" ForeColor="Red" Visible="False">Label</asp:Label>
            </div>
            
            <p>The more you buy, the more you save! Save on shipping when you purchase several bottles at a time.</p>
        </div>
        
        <div id="billing">
            <h3>Step 1 of 3: Enter Your Billing & Shipping Info</h3>
            <p>Please note that all fields marked with an <font color="red">*</font> are required fields to complete your order.</p>
            <h4>Bill To: (name & address on credit card statement)</h4>
            <table border="0" width="370px">
           
                <tr>
                    <td class="productInfo" width="150" height=26><font color="red"><b>*</b></font>First Name:</td>
                    <td height=26>
                        <asp:TextBox id="txtFirstName" runat="server" class="textbox" 
                            ontextchanged="txtFirstName_TextChanged"></asp:TextBox> 
                        <asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                    </td>
 
                </tr>
                <tr>
                 <td class="productInfo"><font color="red"><b>*</b></font>Last Name:</td>
                 <td>
                     <asp:TextBox id="txtLastName" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator2 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLastName" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                      </td>
                </tr>
                <tr>
                 <td class="productInfo"><font color="red"><b>*</b></font>Country:</td>
                 <td><OTCControls:otcdropdown id="ddCountry" runat="server" class="textbox" AutoPostBack="false"></OTCControls:otcdropdown></td>
                </tr>
                <tr>
                 <td class="productInfo"><font color="red"><b>*</b></font>Billing Address:</td>
                 <td><asp:TextBox id="txtAddress" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator4 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr>
                 <td class="productInfo"><font color="red"><b>*</b></font>City:</td>
                 <td><asp:TextBox id="txtCity" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator6 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCity" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr class="stateSelect">
                 <td class="productInfo"><font color="red"><b>*</b></font>State/Province</td>
                 <td><OTCControls:otcdropdown id="ddState" runat="server" class="textbox states" autopostback="false"></OTCControls:otcdropdown>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator9 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddState" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr class="province">
                 <td class="productInfo">Province:</td>
                 <td height=26><asp:TextBox id="txtStateProvince" runat="server" class="textbox"></asp:TextBox></td>
                </tr>
                <tr>
                 <td class="productInfo"><font color="red"><b>*</b></font>Zip/Postal Code:</td>
                 <td>
                     <asp:TextBox id="txtZipPostalCode" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator5 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtZipPostalCode" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr>
                 <td class="productInfo"><font color="red"><b>*</b></font>Daytime Phone:</td>
                 <td>
                     <asp:TextBox id="txtPhone" runat="server" class="textbox"></asp:TextBox> 
                     <asp:RequiredFieldValidator id="Requiredfieldvalidator15" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPhone" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                     
                 </td>
                </tr>
                <tr>
                 <td class="productInfo"><font color="red"><b>*</b></font>Email Address:</td>
                 <td><asp:TextBox id="txtEmailAddress" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator3 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmailAddress" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator id=RegularExpressionValidator1 runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="RegularExpressionValidator" Font-Names="verdana" Font-Size="XX-Small" ValidationExpression=".*@.*">check email</asp:RegularExpressionValidator>
                     

                 </td>
                </tr>
                
           </table>
           <div class="aside">
               <div class="text-centered">
                   <img src="/Interceuticals/images/security.jpg" />
                <p>Your privacy is important to us. BetterWOMAN does not rent, sell or share your personal information with any third parties.</p>
               </div> 
          </div>
        </div>
        
        <div id="shipping" class="section">
            <h4>Ship To: Check box if same as billing address <input type="checkbox" onclick="javacript: setShipping(this)"></h4>
            <table width="370px" border="0">
              
                <tr>
                    <td class="productInfo">First Name:</td>
                    <td><asp:TextBox id="txtShippingFirstName" runat="server" class="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator id=RequiredFieldValidator7 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtShippingFirstName" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                 <td class="productInfo">Last Name:</td>
                 <td><asp:TextBox id="txtShippingLastName" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator8 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtShippingLastName" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr>
                 <td class="productInfo">Shipping Country:</td>
                 <td><OTCControls:otcdropdown class=textbox id="ddShippingCountry" name="ddShippingCountry" runat="server" autopostback="false"></OTCControls:otcdropdown> </td>
                        </tr>
                <tr>
                 <td class="productInfo">Shipping Address:</td>
                 <td><asp:TextBox id="txtShippingAddress" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator10 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtShippingAddress" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr>
                 <td class="productInfo">Shipping City:</td>
                 <td><asp:textbox id="txtShippingCity" runat="server" class="textbox"></asp:textbox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator11 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtShippingCity" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr class="stateSelect">
                  <td class="productInfo" height=26>State Shipping&nbsp;:</td>
                  <td height=26><OTCControls:otcdropdown id="ddStateShip" runat="server" class="textbox states" autopostback="false"></OTCControls:otcdropdown></td>
                </tr>
                <tr class="province">
                 <td class="productInfo" height=26>Province:</td>
                 <td height=26><asp:TextBox id="txtShippingStateProvince" runat="server" class="textbox"></asp:TextBox></td>
                </tr>
                <tr>
                 <td class="productInfo">Zip / Postal Code:</td>
                 <td><asp:TextBox id="txtShippingZipPostalCode" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id=RequiredFieldValidator13 runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtShippingZipPostalCode" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr>
                 <td class="productInfo">Shipping Phone:</td>
                 <td><asp:TextBox id="txtShippingPhone" runat="server" class="textbox"></asp:TextBox>
                     <asp:RequiredFieldValidator id="Requiredfieldvalidator18" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtShippingPhone" Display="Dynamic" SetFocusOnError="True">Required</asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr>
                 <td class="productInfo">Email Address:</td>
                 <td><asp:TextBox id="txtShippingEmailAddress" runat="server" class="textbox"></asp:TextBox></td>
                </tr>
                
                    <td colspan="2">
                        <asp:Label id="lblErrorMessage2" runat="server" Visible="False" ForeColor="Red" Font-Names="verdana" Font-Size="X-Small">Label</asp:Label>
                    </td>
                </tr>
            </table>

            <div class="aside">
                <div class="text-centered">
                <p>Military Orders: To avoid any delays shipping to your military address, please type in APO or FPO for your city, choose AA, AE or AP from the pull-down menu for your state, type in your zip code, and finally select United States as your country.</p>
               </div> 
            </div>

        </div>
        
        
        <div class="section" id="shippingMethod">
            <h3>Step 2 of 3: Select Your Shipping Method</h3>
            <OTCControlslist:otclistbox id="ddShippingMethods" runat="server" class="textbox"  width="350px" Height="80px" onclick="javascript:updatePricing()"></OTCControlslist:otclistbox>
            
            <p>Your package will be shipped via US postal service. The estimated delivery time for US packages will be 7-10 business days for regular S/H and 5-7 business days for rush S/H. For international mail, the delivery time may vary depending on the country.</p>
        </div>
        
        <div id="payment" class="section">
            <div>
                <h3>Step 3 of 3: Enter Payment Info</h3>
                <img src="/interceuticals/images/cc.jpg"/>
            </div>
            <div class="card">
                <p>Card Type</p>
                <OTCControls:otcdropdown id="ddCCType" runat="server" class="textbox" width="203px"></OTCControls:otcdropdown>
                <p>Card Number</p>
                <asp:RequiredFieldValidator id=RequiredFieldValidator16 runat="server" ErrorMessage="*Enter Card Number*" ControlToValidate="txtCardNumber" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:TextBox id="txtCardNumber" runat="server" width="200px"></asp:TextBox>
                
                <p>Expiration</p>
                <OTCControls:otcdropdown id="ddMonth" runat="server" class="textbox" width="90px"></OTCControls:otcdropdown>
                <OTCControls:otcdropdown id="ddYear" runat="server" class="textbox"  width="103px"></OTCControls:otcdropdown>
            </div>
            <div class="total">
                <%this.BuildCartTotals();%>
            </div>
            <div>
                <img src="/interceuticals/images/verisign.jpg"/>
            </div>
           
        </div>
        
        <div id="marketing" class="section">
            <h3>Optional Information</h3>
            <p>This information is not required to complete your order. This voluntary information helps us to better understand our customers and meet your needs in the future.</p>
            <%this.DrawMemberQuestions();%>
       
                <p>Comments:</p>
                <textarea rows=5 cols=60 runat="server" id="txtComments"></textarea>
   
        </div>
        
        <div class="final text-centered">
            <asp:Button id="btnCheckout" runat="server" Style="background-image: url(../Images/Shared/placeorder.gif); background-repeat: no-repeat;" BackColor="Transparent" BorderStyle="None" ForeColor="Transparent" Height="25px" Width="275px" ></asp:Button>
        </div>
        <div class="quotes text-centered">
            <div class="bm">
                <p>“It is very annoying and embarrassing to lose control. I tried BetterMAN and saw dramatic differences. I was very impressed. Not only are the dripping and leakage getting better, I feel more energetic and can sleep much better. I have been on this ever since. A great product.” - Bob K.</p>
            </div>
            <div class="bw">
                <p>“I have been using BetterWOMAN for 4 months and only wish I had this product years ago!!!! What a difference it is making in my life. My life is no longer ‘in the toilet'!” - Tina M.</p>
            </div>
        </div>
    </div>
    </div>


<%
if(Request.ServerVariables["HTTP_HOST"] == "localhost")
	Response.Write("<div align=\"center\"><a href=\"../admin/promotionlist.aspx\">promotion list</a></div>");
%>
</asp:Content>

