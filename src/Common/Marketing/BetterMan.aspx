<%@ Page language="c#" Codebehind="BetterMan.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Common.Marketing.BetterMan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
  <head>
    
<!-- MSN Code for purchase Conversion Page -->
<script>
    microsoft_adcenterconversion_domainid = 80240;
    microsoft_adcenterconversion_cp = 5050;
</script>
<script SRC="https://0.r.msn.com/scripts/microsoft_adcenterconversion.js"></script>
<noscript><IMG width=1 height=1 SRC="https://80240.r.msn.com/?type=1&cp=1"/></noscript><a href="http://advertising.msn.com/MSNadCenter/LearningCenter/adtracker.asp" target="_blank">::adCenter::</a>

<!-- MSN Code for purchase Conversion Page -->

<script>
    microsoft_adcenterconversion_domainid = 80240;
    microsoft_adcenterconversion_cp = 5050;
</script>
<script SRC="https://0.r.msn.com/scripts/microsoft_adcenterconversion.js"></script>
<noscript><IMG width=1 height=1 SRC="https://80240.r.msn.com/?type=1&cp=1"/></noscript><a href="http://advertising.msn.com/MSNadCenter/LearningCenter/adtracker.asp" target="_blank">::adCenter::</a>

  </head>
  <body MS_POSITIONING="GridLayout">	

<!-- Google Tag Manager dataLayer for Google Analytics Ecommerce Tracking -->
    <script>
        dataLayer = [{
            'transactionId': '<%=Order.OTCSalesOrderId%>',
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
