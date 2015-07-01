<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Interceuticals.Shared.UserControls.Footer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccAjax" %>
<%@ Register src="~/WebContent/UserControls/PrivacyPolicy.ascx" tagname="privacy" tagprefix="ucPrivacy" %>
<footer>
  <span>
            Copyright © 1998-<%=System.DateTime.Now.Year %> Interceuticals, Inc &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="/interceuticals/WebContent/Company.aspx">About the Company</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="/interceuticals/WebContent/ContactUs.aspx">Contact Us</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="/interceuticals/WebContent/PrivacyPolicy.aspx">Privacy Policy</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">Terms of Use</a> &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">Disclaimer</a>
  </span> 
</footer>
