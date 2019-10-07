<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterGraphs.master" AutoEventWireup="true" CodeBehind="AnalyticsConvertors.aspx.cs" Inherits="BuildViewer.AnalyticsConvertors" %>
<%@ Register TagPrefix="uc" TagName="GraphViewer" Src="~/GraphViewer.ascx"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="GraphsContent" runat="server">
   
	<uc:GraphViewer runat="server" CsvFileName="ResultTestFile.csv" id="ResultFile" />	
</asp:Content>
