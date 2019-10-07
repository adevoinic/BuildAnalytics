<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestAnalytics.aspx.cs" Inherits="BuildViewer.TestAnalytics" %>
<%@ Register TagPrefix="uc" TagName="GraphViewer" Src="~/GraphViewer.ascx"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
	<script src="Scripts/RGraph/full/RGraph.svg.common.core.js"></script>
	<script src="Scripts/RGraph/full/RGraph.svg.common.ajax.js"></script>
	<script src="Scripts/RGraph/full/RGraph.svg.common.key.js"></script>
	<script src="Scripts/RGraph/full/RGraph.svg.common.tooltips.js"></script>
	<script src="Scripts/RGraph/full/RGraph.svg.common.csv.js"></script>
	<script src="Scripts/RGraph/full/RGraph.svg.line.js"></script>
	 

	<%--<script src="Scripts/RGraph/libraries/RGraph.svg.common.core.js"></script>
	<script src="Scripts/RGraph/libraries/RGraph.svg.common.ajax.js"></script>
	<script src="Scripts/RGraph/libraries/RGraph.svg.common.key.js"></script>
	<script src="Scripts/RGraph/libraries/RGraph.svg.common.tooltips.js"></script>
	<script src="Scripts/RGraph/libraries/RGraph.svg.common.csv.js"></script>
	<script src="Scripts/RGraph/libraries/RGraph.svg.line.js"></script>
	--%> 

	<uc:GraphViewer runat="server" CsvFileName="UT_BC2ALibrary_TestDB.csv" />
	<uc:GraphViewer runat="server" CsvFileName="UT_BC2ALibrary_LoadTests_LoadTests.csv" />
	<uc:GraphViewer runat="server" CsvFileName="UT_BC2ALibrary_Test.csv" />

	<uc:GraphViewer runat="server" CsvFileName="UT_BC2AMIP4_BC2AMIP4.csv" />
	<uc:GraphViewer runat="server" CsvFileName="UT_BC2AMIP4_GeneratorsTests_BC2AMIP4.csv" />
	
	<uc:GraphViewer runat="server" CsvFileName="UT_BC2A_CONVERTORS_CmoConvertor.csv" id="UT_BC2A_CONVERTORS_CmoConvertor" />
	<uc:GraphViewer runat="server" CsvFileName="UT_BC2A_CONVERTORS_ISw.BC2A.Convertors.HQModelJc3iedm31.Tests.csv" ID ="UT_BC2A_CONVERTORS_ISw_BC2A_Convertors_HQModelJc3iedm31_Tests" />
	<uc:GraphViewer runat="server" CsvFileName="UT_BC2A_CONVERTORS_ISw.BC2A.Convertors.Jc3iedm30Jc3iedm31.Test.csv" />
	
	<uc:GraphViewer runat="server" CsvFileName="UT_DAL_HQ_ISW.DAL.Model.Test.csv" />
	<uc:GraphViewer runat="server" CsvFileName="UT_DAL_HQ_ISW.Dal.NHibernateRepository.Test.csv" />

	<uc:GraphViewer runat="server" CsvFileName="UT_C2RulesAndMappings_C2RulesAndMappings.csv" />

	<uc:GraphViewer runat="server" CsvFileName="UT_DAL_JC3IEDM_Isbc.Dal.Jc3iedm31.NHibernateRepository.Test.csv" />
	<uc:GraphViewer runat="server" CsvFileName="UT_DAL_JC3IEDM_Isbc.Jc3Iedm.Model.Test.csv" />
	 
	<%--	<script type="text/javascript">
		/**
		* This fetchs the CSV file and shows the Bar chart
		*/
		var csvaa = new RGraph.CSV('Content/UT_BC2A_CONVERTORS_CmoConvertor.csv', function (csv) {
			// Get the first column which becomes the labels
			var dates = csv.getCol(0, 1);
				// Get the second column which becomes the data
			dataPassed = csv.getCol(3, 1);
			dataFailed = csv.getCol(5, 1);
		 
			// Create the chart
			//var line = new RGraph.Line({
			//	id: 'cvs',
			//	data: [dataPassed, dataFailed],
			//	options: {
			//		labels: dates,
			//		textAccessible: true,
			//		filled: false,
			//		colors: ['green', 'red'],
			//	}
			//}).draw();

			var lineSvg = new RGraph.SVG.Line({
				id: 'chart-container',
				data: [dataPassed, dataFailed],
				options: {					 
					xaxisLabels: dates,			
					tooltips: dataPassed.concat(dataFailed),
					colors: ['green', 'red'],
					tickmarksStyle: 'endcircle',
					tickmarksFill: 'white',
					tickmarksLinewidth: 1,
					tickmarksSize: 2,
					gutterLeft: 100,
				}
			}).draw();

		});
	</script>
   
	<div style="width: 1250px; height: 700px" id="chart-container"></div>--%>

</asp:Content>
