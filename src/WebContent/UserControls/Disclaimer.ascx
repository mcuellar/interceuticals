<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Disclaimer.ascx.cs" Inherits="Interceuticals.WebContent.UserControls.Disclaimer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ccAjax" %>
<asp:Panel ID="pnlDisclaimer" runat="server" CssClass="ModalPopup" Width="750px" Height="205px">
    <div class="ModalPopupTitle">
    <strong>Disclaimer</strong>
    </div>

    <div class="ModalPopupLineBreak"></div>
    <div class="ModalPopupContent">
    <p>Information on this website is provided for educational purposes and is not meant to substitute for the advice provided by your own physician or other medical professional.<//p>

    <p>The statements on this website have not been evaluated by the Food and Drug Administration. The product offered on this website is not intended to diagnose, treat, cure, or prevent any disease.</p>
    </div>
    <div class="ModalPopupLineBreak"></div>

    <div class="ModalPopupFooter">
        <asp:Button ID="btnClose" runat="server" Text="Close" width="100"/>
    </div>
</asp:Panel>
<ccAjax:ModalPopupExtender BackgroundCssClass="ModalBackground" CancelControlID="btnClose" runat="server" 
PopupControlID="pnlDisclaimer" id="disclaimerPopup" TargetControlID="disclaimerLink"/>