<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCardPost.aspx.cs" Inherits="Interceuticals.Order.CreditCardPost" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreditCardPost</title>
        <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script>
    <%--
    <script type="text/javascript">
        $(document).ready(function () {
            $("a").click(function () {
                var cDomainUrl = "interceuticals.com";
                var aUrl = this.host;
                //alert("HREF is: " + this.href + " Host is: " + aUrl);
                var dUrl = "www.betterwomannow.com";
                var sUrl = "www.bettermannow.com";
                if (aUrl == dUrl || aUrl == sUrl) {
                    _gaq.push(['_link', this.href]); return false;
                }
            });
        });
    </script>
    --%>
	<%-- Disabled 2014-06-20 by Dirigo
    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-39805742-1']);
        _gaq.push(['_setDomainName', 'interceuticals.com']);
        _gaq.push(['_setAllowLinker', true]);
        _gaq.push(['_trackPageview']);
        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
    --%>
    <%--
         Gabriel Nascimento
         06-12-2013. 
         Added the two scripts folow.
    --%>
    <script type="text/javascript">        
        if (!window.mstag) mstag = { loadTag: function () { }, time: (new Date()).getTime() };</script> 
    <script id="mstag_tops" type="text/javascript" src="//flex.atdmt.com/mstag/site/0b962a91-cdba-4985-9fec-a34f81587f49/mstag.js"></script> 
    <script type="text/javascript">        mstag.loadTag("analytics", { dedup: "1", domainId: "2402724", type: "1", revenue: "", actionid: "134477" })</script>
    <noscript> <iframe src="//flex.atdmt.com/mstag/tag/0b962a91-cdba-4985-9fec-a34f81587f49/analytics.html?dedup=1&domainId=2402724&type=1&revenue=&actionid=134477" frameborder="0" scrolling="no" width="1" height="1" style="visibility:hidden;display:none"> </iframe> </noscript>

    <%-- Disabled 2014-06-20 by Dirigo
    <script type="text/javascript">
            var _gaq = _gaq || [];
            _gaq.push(['_setAccount', 'UA-39805742-1']);
            _gaq.push(['_setDomainName', 'interceuticals.com']);
            _gaq.push(['_setAllowLinker', true]);
            _gaq.push(['_trackPageview']);
            _gaq.push(['_addTrans',
           <%=Order.OTCSalesOrderId%>,           // transaction ID - required
           '<%=SiteName%>', // affiliation or store name
           <%=Order.TotalCost%>,          // total - required
           <%=Order.SalesTax%>,           // tax
           <%=Order.ShippingCost%>,          // shipping
           '<%=Member.City%>',       // city
           '<%=Member.State%>',     // state or province
           '<%=Order.ShippingCountry%>'             // country
        ]);
                _gaq.push(['_addItem',
           <%=Order.OTCSalesOrderId%>,           // transaction ID - necessary to associate item with transaction
           <%=Order.OTCSalesOrderId%>,           // SKU/code - required
           '<%=SiteName%>',        // product name
           '<%=SiteName%>',   // category or variation
           <%=Order.TotalCost%>,          // unit price - required
           '1'               // quantity - required
        ]);
                _gaq.push(['_trackTrans']);
                (function () {
                    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
                    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
                })();
    </script>
    --%>
</head>
<body>
  <!-- Google Tag Manager dataLayer for Google Analytics Ecommerce Tracking -->
    <script>
        dataLayer = [{
            'transactionId': '(Pre Transactions) <%=Order.OTCSalesOrderId%>',
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


 <form name="f1" id="f1" action="https://payflowlink.paypal.com" method="post">
 <!--<form name="f1" id="f1" action="../Verisign/SilentTest.aspx" method="post">-->
         <input type="hidden" name="ORDERFORM" value="FALSE">
         <input type="hidden" name="SHOWCONFIRM" value="FALSE"> 
         <input type="hidden" name="METHOD" value="C">
         <input type="hidden" name="login" value="Interce">
         <input type="hidden" name="partner" value="Paypal">
         <input type="hidden" name="TYPE" value="S">
         <input type="hidden" name="name" value="<%=Member.FirstName + " " + Member.LastName%>">
         <input type="hidden" name="AMOUNT" value="<%=Order.TotalCost%>">
         <input type="hidden" name="ADDRESS" value="<%=Member.Address%>">
         <input type="hidden" name="CITY" value="<%=Member.City%>">
         <input type="hidden" name="STATE" value="<%=Member.State%>">
         <input type="hidden" name="EMAIL" value="<%=Member.EmailAddress%>">
         <input type="hidden" name="EXPDATE" value="<%=(Card.ExpirationMonth.ToString().Length == 1 ? "0" + Card.ExpirationMonth : Card.ExpirationMonth) + Card.ExpirationYear.Substring(2,2)%>">
         <input type="hidden" name="ZIP" value="<%=Member.Zip%>">
         <input type="hidden" name="CARDNUM" value="<%=Card.CardNumber%>">
         <input type="hidden" name="user1" value="<%=Order.OTCSiteMemberId%>">
         <input type="hidden" name="user2" value="<%=Order.OTCSalesOrderId%>">
         <input type="hidden" name="user3" value="<%=SiteName%>">
         <input type="hidden" name="user4" value="<%=Request.QueryString["_ga"]%>">
        
         <input type="hidden" name="NAMETOSHIP" value="<%=Order.ShippingFirstName + " " + Order.ShippingLastName%>">
         <input type="hidden" name="ADDRESSTOSHIP" value="<%=Order.ShippingAddress%>">
         <input type="hidden" name="CITYTOSHIP" value="<%=Order.ShippingCity%>">
         <input type="hidden" name="STATETOSHIP" value="<%=Order.ShippingState%>">
         <input type="hidden" name="COUNTRYCODE" value="<%=Order.ShippingCountry%>">
         <input type="hidden" name="ZIPTOSHIP" value="<%=Order.ShippingZip%>">

        <div align="center">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr height="275">
              <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="20%">&nbsp;</td>
                <td width="60%" valign="middle" align="center" style="border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid">
                         <font size="5" style="font-family:Century; background-color: Silver"><b><%=this.OrderMessage %></b></font><br /><br />
                         <%if (this.CurrentSession != "") { %>
                         <img src="../Images/progress1.gif" /> 
                         <%} %> 
                </td>
                <td width="20%">&nbsp;</td>
            </tr>
        </table>
        </div>
    </form>
        
    <div align="right">
    
    <!-- MSN Code for purchase Conversion Page -->
    <script>
    microsoft_adcenterconversion_domainid = 80240;
    microsoft_adcenterconversion_cp = 5050;
    </script>
    <script SRC="https://0.r.msn.com/scripts/microsoft_adcenterconversion.js"></script>
    <noscript><IMG width=1 height=1 SRC="https://80240.r.msn.com/?type=1&cp=1"/></noscript><a href="http://advertising.msn.com/MSNadCenter/LearningCenter/adtracker.asp" target="_blank"><div class="hidden">::adCenter::</div></a>

    <%-- Disabled 2014-06-20 by Dirigo
    <!-- Google Code for purchase Conversion Page -->
    <script language="JavaScript" type="text/javascript">
    
        var google_conversion_id = 1072257769;
        var google_conversion_language = "en_US";
        var google_conversion_format = "1";
        var google_conversion_color = "FFFFFF";
        if (<%=Order.TotalCost%>) {
          var google_conversion_value = <%=Order.TotalCost%>;
        }
        var google_conversion_label = "purchase";
    
    </script>
    <script language="JavaScript" src="https://www.googleadservices.com/pagead/conversion.js"></script>
    
    <noscript><img height=1 width=1 border=0 src="https://www.googleadservices.com/pagead/conversion/1072257769/?value=<%=Order.TotalCost%>&label=purchase&script=0"></noscript>
    --%>

    <script language="JavaScript" type="text/javascript"> 
    <!-- Yahoo! Search Marketing 
    window.ysm_customData = new Object(); 
    window.ysm_customData.conversion = "transId=<%=Order.OTCSalesOrderId%>,currency=US,amount=<%=Convert.ToDouble(Order.TotalCost).ToString("c").Replace("$","")%>"; 
    var ysm_accountid  = "1CC0B2QUH7IOUN24UH2O40R0B4G";
    document.write("<SCR" + "IPT language='JavaScript' type='text/javascript' " 
    + "SRC=//" + "srv2.wa.marketingsolutions.yahoo.com" + "/script/ScriptServlet" + "?aid=" + ysm_accountid 
    + "></SCR" + "IPT>"); 
    // -->
    </script> 

    <%-- Disabled 2014-06-20 by Dirigo
    <!--  GA Code To Capture Transaction Details -->
    <form style="display:none;" id="utmform" name="utmform">
    <textarea id="utmtrans" style="display:none;">
    <%=this.SiteString%>
    </textarea>
    </form>
    --%>
    <script type="text/javascript">
        function submitForm() {
            var currentSession = '<%=CurrentSession%>';

            if (currentSession != "") {
                setTimeout("document.f1.submit()", 2000);
            }
        } 
        //Gabriel Nascimento - 23/07/2013
        setTimeout(function() { submitForm(); }, 3000);
        //submitForm();
    </script>
    </div>

</body>
</html>
