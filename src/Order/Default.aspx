<%@ Page language="c#" MasterPageFile="~/Shared/Layout.Master" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Product._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Product</title>
    <script type="text/javascript" src="Default.js"></script>
    <script type="text/javascript" src="../Shared/Global.js"></script>
</asp:Content>
<asp:Content ID="contentProduct" ContentPlaceHolderID="cBody" runat="server">

        <input type="hidden" id="txtSite" value="<%=this.Site%>">
        <p><b>Welcome to our SECURED online store. Just select the product and start your order.</b><br>
            For phone&nbsp;order, please call&nbsp;888-686-2698. Order by mail or fax, 
            please <a href="/interceuticals/WebContent/PDF/INT0968OrderForm.pdf">click here</a> for the order form. 
            We provide a 120-day return policy to our first time customers.
        </p>
        <br />
        <p>Select Product: <asp:DropDownList id="ddProducts" runat="server" autopostback="true"></asp:DropDownList></p>
        <p>
            <div id="membershipInfoActive" style="display:block"><%=this.MemberShipHTML%></div>
        </p>
         <p><asp:CheckBox id=chkAutoship runat="server" Text="Uncheck this box if you do not wish to be enrolled into the program." Checked="true"></asp:CheckBox>
         </p>
         <br>
            <span class="buttonStyle"><a href="#" title="Buy it Now" onclick="javascript:doRedirect()"><img src="../Images/Shared/buy_it_now_en.gif"/></a></span>

     <!-- Start of StatCounter Code -->
        <script type="text/javascript" language="javascript">
            var sc_project=1740123; 
            var sc_invisible=1; 
            var sc_partition=16; 
            var sc_security="3d63102b"; 
        </script>
  
      <script type="text/javascript" language="javascript" src="http://www.statcounter.com/counter/counter.js"></script>
      <noscript>
      <a href="http://www.statcounter.com/" target="_blank"><img  src="http://c17.statcounter.com/counter.php?sc_project=1740123&amp;java=0&amp;security=3d63102b&amp;invisible=1" alt="free web stats" border="0"></a>
      </noscript>  
      <!-- End of StatCounter Code -->    
      <!-- Start of HitTail Code -->
        <script src="http://13440.hittail.com/mlt.js" type="text/javascript"></script>    
      <!-- End of HitTail Code -->    <!-- Start of Google Analytics Code -->
  
</asp:Content>
