using System;
using System.IO;
using System.Linq;

namespace BuildAnalytics
{
	public class CsvBuilder
	{
		public void ProcessTrxFiles(string projectTrxFolder, string outputCsvFolder)
		{
			if (!Directory.Exists(projectTrxFolder))
			{
				throw new DirectoryNotFoundException(projectTrxFolder);
			}

			if (!Directory.Exists(outputCsvFolder))
			{
				throw new DirectoryNotFoundException(projectTrxFolder);
			}

			var dirInfo = new DirectoryInfo(projectTrxFolder);
			var trxParser = new TrxParser();

			foreach (var file in dirInfo.GetFiles("*.trx"))
			{
				if (!IsTestFileForToday(file.Name))
				{
					continue;
				}
				var trxData = trxParser.ParseFile(file);
				UpdateResults(trxData, outputCsvFolder);
			}
		}
	
		private static void UpdateResults(TrxData trxData, string outputCsvFolder)
		{
			var csvFile = GetCsvName(trxData.FileName);
			if (string.IsNullOrEmpty(csvFile))
			{
				Console.WriteLine("No csv file determined to do updates.");
				return;// NO build for today.
			}
			var completePath = outputCsvFolder + "\\" + csvFile;
			UpdateSummaryCsv(trxData, completePath);			
		}

		private static void UpdateSummaryCsv(TrxData trxData, string completePath)
		{
			if (!File.Exists(completePath))
			{
				StreamWriter file = File.CreateText(completePath);
				file.WriteLine(TrxData.CsvHeader);
				file.Close();
				file.Dispose();
			}

			var lines = File.ReadAllLines(completePath);

			var lastLine = lines.LastOrDefault();	 
			var currentDate = TrxData.GetCurrentDateAsString();

			if (string.IsNullOrEmpty(lastLine) || lastLine.StartsWith(currentDate))
			{   // Overwrite last results in the same day.
				using (var sw = new StreamWriter(completePath))
				{
					if (!lines.Any())
					{
						sw.WriteLine(TrxData.CsvHeader);
					}
					var dataEntered = false;
					foreach (var line in lines)
					{
						if (string.IsNullOrEmpty(line))
						{
							continue;
						}
						if (line.StartsWith(currentDate))
						{	//Overwrite in case there are multiple runs in the same day.
							sw.WriteLine(trxData.ToCsvLine());
							dataEntered = true;
						}
						else
						{
							sw.WriteLine(line);
						}
					}
					if (!dataEntered)
					{
						sw.WriteLine(trxData.ToCsvLine());
					}
				}
			}
			else
			{   // Fresh new day.
				File.AppendAllText(completePath, trxData.ToCsvLine());
			}
		}
	
		private static bool IsTestFileForToday(string trxName)
		{			
			var currentDate = GetCurrentDateInBuildFormat();

			var index = trxName.IndexOf(currentDate);
			if (index < 0)
			{
				Console.WriteLine("No trx found for today.");
				return false;
			}
			return true;
		}

		private static string GetCsvName(string trxName)
		{
			string currentDate = GetCurrentDateInBuildFormat();

			var index = trxName.IndexOf(currentDate);
			if (index == -1)
			{
				Console.WriteLine("No trx found for today.");
				return null;
			}
			var next_Index = trxName.IndexOf("_", index);
			var lastIndex = trxName.LastIndexOf(".");

			var csvName = trxName.Substring(0, index) + trxName.Substring(next_Index + 1, lastIndex - next_Index - 1);
			return csvName + ".csv";
		}

		private static string GetCurrentDateInBuildFormat()
		{	// The format has to be the same as for UT BUILD. Do not use GetCurrentDateAsString.
			return DateTime.Now.ToString("yyyyMMdd");			
		}
	}
}
