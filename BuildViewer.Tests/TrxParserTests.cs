using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildAnalytics;

namespace BuildViewer.Tests
{
	[TestClass]
	public class CsvBuilder
	{
		[TestMethod]
		public void CsvBuilderLibraryTrx()
		{
			var trxParser = new BuildAnalytics.CsvBuilder();
			trxParser.ProcessTrxFiles(@"D:\Date\trxParser", @"C:\Temp");
		}
	}
}
