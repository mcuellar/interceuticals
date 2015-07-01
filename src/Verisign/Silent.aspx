<%@ Page language="c#" Codebehind="Silent.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Verisign.Silent" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>Silent</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body MS_POSITIONING="GridLayout">
    <!-- Google Tag Manager dataLayer for Google Analytics Ecommerce Tracking -->
    <script>
        dataLayer = [{
            'transactionId': '(PreTranactions) <%=Order.OTCSalesOrderId%>',
            'transactionAffiliation': '<%=SiteName%>',
            'transactionTotal': <%=Order.TotalCost%>,
            'transactionTax': <%=Order.SalesTax%>,
            'transactionShipping': <%=Order.ShippingCost%>,
            'transactionProducts': [{
                'sku': '<%=Order.OTCSalesOrderId%>',
                'name': '<%=SiteName%>',
                'category': '<%=SiteName%>',
                'price': <%=Order.TotalCost%>,
                'quantity': 1
            }]
        }];

      
</script>
<!-- End Google Tag Manager dataLayer for Google Analytics Ecommerce Tracking -->
<!-- Google Tag Manager -->
<noscript><iframe src="//www.googletagmanager.com/ns.html?id=GTM-MX6MWT"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'//www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-MX6MWT');</script>
<!-- End Google Tag Manager -->
    <form id="Form1" method="post" runat="server">

     </form>
	
  </body>
</html>
