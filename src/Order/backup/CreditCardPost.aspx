<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCardPost.aspx.cs" Inherits="Interceuticals.Order.CreditCardPost" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreditCardPost</title>
        <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script>
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
</head>
<body>
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

    <!--  GA Code To Capture Transaction Details -->
    <form style="display:none;" id="utmform" name="utmform">
    <textarea id="utmtrans" style="display:none;">
    <%=this.SiteString%>
    </textarea>
    </form>
    <script type="text/javascript">
        function submitForm() {
            var currentSession = '<%=CurrentSession%>';

            if (currentSession != "") {
                setTimeout("document.f1.submit()", 2000);
            }
        } 

        submitForm();
    </script>
    </div>

</body>
</html>
