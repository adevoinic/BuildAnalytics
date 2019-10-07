<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GraphViewer.ascx.cs" Inherits="BuildViewer.GraphViewer"  %>

<div runat="server" id="ascxDiv" class="row">

	<%--<script type="text/html" >
		var csvFilePath = $("#csvFilePath");

		var csv = new RGraph.CSV(csvFilePath, function (csv) {
				// Get the first column which becomes the labels
				var dates = csv.getCol(0, 1);
				// Get the second column which becomes the data
				dataPassed = csv.getCol(3, 1);
				dataFailed = csv.getCol(5, 1);
		  
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
	</script>--%>
	<div class="col-md-10">
		<span style="font-weight:bold">
			<%Response.Write(this.CsvFileName); %>
		</span>
		<div runat="server" id="summary"></div>
		<div runat="server" id="divData" style="display:none"></div>
		<div style="width: 1050px; height: 400px; margin-bottom:35px" id="chartContainer" runat="server"></div>	
	</div>
	<div class="col-md-2">
		<span>Legend: Passed - green  Failed - red</span>
	</div>
</div>