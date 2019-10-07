using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace BuildAnalytics
{
	class TrxParser
	{
		internal TrxData ParseFile(FileInfo file)
		{
			using (var xreader = XmlReader.Create(file.FullName))
			{
				var xdoc = XDocument.Load(xreader);
				var counters = xdoc.Document.Descendants().FirstOrDefault(f => f.Name.LocalName == "Counters");
				if (counters == null)
				{
					return null;
				}
				var trxData = FetchAttributes(counters);
				trxData.FileName = file.Name;
				return trxData;
			}			
		}

		private TrxData FetchAttributes(XElement counters)
		{
			var trxData = new TrxData();

			foreach (var attribute in counters.Attributes())
			{
				if (attribute.Name == "total")
				{
					trxData.Total = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "executed")
				{
					trxData.Executed = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "passed")
				{
					trxData.Passed = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "error")
				{
					trxData.Error = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "failed")
				{
					trxData.Failed = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "timeout")
				{
					trxData.Timeout = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "aborted")
				{
					trxData.Aborted = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "inconclusive")
				{
					trxData.Inconclusive = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "passedButRunAborted")
				{
					trxData.PassedButRunAborted = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "notRunnable")
				{
					trxData.NotRunnable = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "notExecuted")
				{
					trxData.NotExecuted = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "disconnected")
				{
					trxData.Disconnected = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "warning")
				{
					trxData.Warning = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "completed")
				{
					trxData.Completed = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "inProgress")
				{
					trxData.InProgress = int.Parse(attribute.Value);
				}
				else if (attribute.Name == "pending")
				{
					trxData.Pending = int.Parse(attribute.Value);
				}
			}
			return trxData;
		}
	}
}
