using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;

namespace BuildViewer
{
	public partial class GraphViewer : UserControl
	{		
		private string csvSourceFolder = WebConfigurationManager.AppSettings["csvSourceFolder"];
		private string csvLocalFolder = WebConfigurationManager.AppSettings["csvLocalFolder"];

		public string CsvFileName { get; set; }

		public int? DisplayInfoOnNLastDays { get; set; }

		private int StartingLine { get; set; }

		private string CsvPath
		{
			get
			{
				return string.Concat(HttpContext.Current.Request.PhysicalApplicationPath, csvLocalFolder, CsvFileName);
			}
		}

		private string CsvPathHtml
		{
			get
			{
				return string.Concat(csvLocalFolder, @"\", CsvFileName);
			}
		}

		private string CsvHtmlName
		{
			get { return CsvFileName.Replace(".", "_"); }
		}

		private string CsvScriptVar
		{
			get { return "csv_" + CsvHtmlName; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			string sourceCsvFile = csvSourceFolder + CsvFileName;

            var lastWriteTime = File.GetLastWriteTime(CsvPath);

            // TODO AV - Why not read directly from server?
            // Access only with domain user for the moment.
            if (IsNewerFile(lastWriteTime))                 
            {
                // Unauthorized exception ? R:Uncheck readonly from tfs.
                File.Copy(sourceCsvFile, CsvPath, true);
            }

            int defaultValue = (this.Page.Master as MasterGraphs).LastDays;

			var lines = File.ReadAllLines(CsvPath);
			StartingLine = 1;
			if (defaultValue < lines.Count())
			{
				StartingLine = lines.Count() - defaultValue;
			}

			InjectDataDiv(lines);
			InjectJs();
			DisplaySummary(lines);
		}

		private static bool IsNewerFile(DateTime lastWriteTime)
		{
			//Maybe it is a better ideea to compare local file with sa file, to check times directly.
			return lastWriteTime.Day < DateTime.Now.Day || lastWriteTime.Month <= DateTime.Now.Month || lastWriteTime.Year <= DateTime.Now.Year;
		}

		private void InjectDataDiv(string[] lines)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = StartingLine; i < lines.Length; i++)
			{
				if (string.IsNullOrEmpty(lines[i]))
				{
					continue;
				}
				var date = lines[i].Split(',').First();
				var formatedDate = FormatDate(date);
				var newLine = lines[i].Replace(date, formatedDate);

				sb.AppendLine(newLine);
			}
			divData.InnerText = sb.ToString();
		}

		private string FormatDate(string date)
		{
			try
			{
				return date.Substring(0, 4); // Get rid of year.
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void DisplaySummary(string[] lines)
		{
			if (!lines.Any())
			{
				return;
			}
			var header = lines.FirstOrDefault();
			var lastValues = lines.LastOrDefault(f => f.Length > 1);

			var columns = header.Split(',');
			var lastestValues = lastValues.Split(',');

			if (lastestValues.Length == 1)
			{   // Future dev - try to get the last working day instead. There may be empty lines at the end.
				summary.InnerText = "No values for today.";
				return;
			}
			StringBuilder summaryText = new StringBuilder();
			for (int i = 0; i < columns.Length; i++)
			{
				summaryText.AppendLine(columns[i] + " = " + lastestValues[i] + " ");
			}
			summary.InnerText = summaryText.ToString();
		}

		private void InjectJs()
		{
			StringBuilder sb = new StringBuilder();

			sb = sb.AppendLine("<script type = \"text/javascript\">")
						// .AppendLine(" $(document).ready(function() { ")
						//.AppendLine("alert('"+ CsvHtmlName +"')")
						//.AppendLine("var csv = new RGraph.CSV('" + CsvPath + "', function(csv) {")
						//.AppendLine("var " + CsvScriptVar + " = new RGraph.CSV('" + CsvPathHtml + "', function(" + CsvScriptVar + ") {")
						.AppendLine("var " + CsvScriptVar + " = new RGraph.CSV('id:" + divData.ClientID + "', function(" + CsvScriptVar + ") {")
						// Get the first column which becomes the labels
						.AppendLine("var dates = " + CsvScriptVar + ".getCol(0, 1);")
						//.AppendLine("alert('" + CsvHtmlName + "');")
						// Get the second column which becomes the data
						.AppendLine("dataPassed = " + CsvScriptVar + ".getCol(3, 1);")
						.AppendLine("dataFailed = " + CsvScriptVar + ".getCol(5, 1);")

					.AppendLine("var lineSvg = new RGraph.SVG.Line({")
							.AppendLine("id: '" + chartContainer.ClientID + "',")
							.AppendLine("data: [dataPassed, dataFailed],")
							.AppendLine("options:")
					.AppendLine("{")
						.AppendLine("xaxisLabels: dates,")
								.AppendLine("tooltips: dataPassed.concat(dataFailed),")
								.AppendLine("colors: ['green', 'red'],")
								.AppendLine("spline: 'true',")
								.AppendLine("tickmarksStyle: 'endcircle',")
								.AppendLine("tickmarksFill: 'white',")
								.AppendLine("tickmarksLinewidth: 1,")
								.AppendLine("tickmarksSize: 2,")
								.AppendLine("gutterLeft: 100,")
							.AppendLine("}")
					.AppendLine("}).draw();")

					.AppendLine("});")
			//.AppendLine("});")
			.AppendLine("</script>");

			Page.ClientScript.RegisterStartupScript(typeof(GraphViewer), CsvHtmlName, sb.ToString());
		}
	}
}