<%@ Page language="c#" Codebehind="PromotionTest.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Admin.PromotionTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>PromotionTest</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
	<a href="promotionlist.aspx">Promotion List</a>
    <form id="Form1" method="post" runat="server"><asp:ListBox id=lstProducts style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 80px" runat="server" Width="184px" Height="224px" SelectionMode="Multiple"></asp:ListBox><asp:TextBox id=txtPromotionPrice style="Z-INDEX: 105; LEFT: 464px; POSITION: absolute; TOP: 152px" runat="server" Width="112px"></asp:TextBox><asp:DropDownList id=ddPromotions style="Z-INDEX: 102; LEFT: 360px; POSITION: absolute; TOP: 80px" runat="server" Width="224px"></asp:DropDownList><asp:TextBox id=txtProductPrice style="Z-INDEX: 103; LEFT: 464px; POSITION: absolute; TOP: 112px" runat="server" Width="112px"></asp:TextBox><asp:Label id=Label1 style="Z-INDEX: 104; LEFT: 368px; POSITION: absolute; TOP: 112px" runat="server">Product Price</asp:Label><asp:Label id=Label2 style="Z-INDEX: 106; LEFT: 352px; POSITION: absolute; TOP: 152px" runat="server">Promotion Price</asp:Label><asp:Button id=Button1 style="Z-INDEX: 107; LEFT: 472px; POSITION: absolute; TOP: 200px" runat="server" Text="Button"></asp:Button>

     </form>
	
  </body>
</HTML>
