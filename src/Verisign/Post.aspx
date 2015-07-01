<%@ Page language="c#" Codebehind="Post.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Verisign.Post" %>!--
<body onload="javascript:document.forms[0].submit()">
    <form name="f1" id="f1" action="https://payflowlink.paypal.com" method="post">
    <input type="hidden" name="ORDERFORM" value="TRUE">
    <input type="hidden" name="SHOWCONFIRM" value="FALSE"> 
    <table>
		<tr>
		<td><input type="hidden" name="login" value="Interce"></td>
		</tr>
		<tr>
		<td><input type="hidden" name="partner" value="Paypal"></td>
		</tr>
		<tr>
		<td><input type="hidden" name="TYPE" value="S"></td>
		</tr>
       <tr>
       <td><input type="hidden" name="amount" value="<%=Order.TotalCost%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="name" value="<%=Order.FirstName + " " + Order.LastName%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="address" value="<%=Order.Address%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="city" value="<%=Order.City%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="state" value="<%=Order.State%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="zip" value="<%=Order.Zip%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="PHONE" value="<%=Order.Phone%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="country" value="<%=Order.Country%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="EMAIL" value="<%=Order.EmailAddress%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="NAMETOSHIP" value="<%=Order.ShippingFirstName + " " + Order.ShippingLastName%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="ADDRESSTOSHIP" value="<%=Order.ShippingAddress%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="CITYTOSHIP" value="<%=Order.ShippingCity%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="STATETOSHIP" value="<%=Order.ShippingState%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="ZIPTOSHIP" value="<%=Order.ShippingZip%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="COUNTRYTOSHIP" value="<%=Order.ShippingCountry%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="PHONETOSHIP" value="<%=Order.ShippingPhone%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="CARDNUM" value="<%=Card.CardNumber%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="EXPDATE" value="<%=this.ExpirationDate%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="user1" value="<%=Order.OTCSiteMemberId%>"></td>
      </tr>
      <tr>
       <td><input type="hidden" name="user2" value="<%=Order.OTCSalesOrderId%>"></td>
      </tr>
      <!--tr>
       <td>
        <table>
         <tr>
          <td>Test Visa Card Numbers - Cut and Paste</td>
         </tr>
         <tr>
          <td>4222222222222</td>
         </tr>
         <tr>
          <td>4111111111111111</td>
         </tr>
         <tr>
          <td>4012888888881881</td>
         </tr>
        </table>
       </td>
      </tr>
      <tr>
       <td><input type="submit"></td>
      </tr-->
    </form>
</body>