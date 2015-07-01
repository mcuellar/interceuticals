<%@ Page language="c#" Codebehind="X.aspx.cs" AutoEventWireup="false" Inherits="Interceuticals.Product.X" %>
<%
this.m_page.OpenHeader();
this.m_page.CloseHeader();
this.m_page.Start();
Response.Write("This is a test");
this.m_page.End();
%>