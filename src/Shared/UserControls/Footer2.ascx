<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer2.ascx.cs" Inherits="Interceuticals.Shared.UserControls.Footer2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccAjax" %>
<%@ Register src="~/WebContent/UserControls/PrivacyPolicy.ascx" tagname="privacy" tagprefix="ucPrivacy" %>
<%@ Register src="~/WebContent/UserControls/TermsOfUse.ascx" tagname="terms" tagprefix="ucTerms" %>
<%@ Register src="~/WebContent/UserControls/Disclaimer.ascx" tagname="disclaimer" tagprefix="ucDisclaimer" %>
<footer>
  <span>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
          <ContentTemplate>
              Copyright © 1998-<%=System.DateTime.Now.Year %> Interceuticals, Inc &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <a href="#" onclick="javascript:redirectTo('http://www.interceuticals.com/interceuticals/WebContent/Company.aspx')">About the Company</a>&nbsp;&nbsp;|&nbsp;&nbsp;
              <asp:LinkButton ID="privacyLink" runat="server" Visible="true" Text="Privacy Policy"/>&nbsp;&nbsp;|&nbsp;&nbsp;
                <ucPrivacy:privacy ID="Privacy" runat="server" />
              <asp:LinkButton ID="termsLink" runat="server" Visible="true" Text="Terms of Use"/>&nbsp;&nbsp;|&nbsp;&nbsp;
                <ucTerms:terms ID="Terms" runat="server" />
              <asp:LinkButton ID="disclaimerLink" runat="server" Visible="true" Text="Disclaimer"/>
                <ucDisclaimer:disclaimer ID="Disclaimer" runat="server" />              
          </ContentTemplate>
      </asp:UpdatePanel>
  </span> 
</footer>
