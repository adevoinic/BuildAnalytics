using System;

namespace BuildAnalytics
{
	class Program
	{
		static void Main(string[] args)
		{ 
			if (args.Length != 2)
			{
				throw new ArgumentException("Expected 2 params: projectTrxFolder and outputCsvFolder");
			}
			var projectTrxFolder = args[0];
			var outputCsvFolder = args[1];

			var trxParser = new CsvBuilder();			 
			trxParser.ProcessTrxFiles(projectTrxFolder, outputCsvFolder);
		}		
	}
}
