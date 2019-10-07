using System;

namespace BuildAnalytics
{
	public class TrxData
	{
		public string FileName { get; set; }

		public int Total { get; set; }

		public int Executed { get; set; }

		public int Passed { get; set; }

		public int Error { get; set; }

		public int Failed { get; set; }

		public int Timeout { get; set; }

		public int Aborted { get; set; }

		public int Inconclusive { get; set; }

		public int PassedButRunAborted { get; set; }

		public int NotRunnable { get; set; }

		public int NotExecuted { get; set; }

		public int Disconnected { get; set; }

		public int Warning { get; set; }

		public int Completed { get; set; }

		public int InProgress { get; set; }

		public int Pending { get; set; }

		public string ToCsvLine()
		{
			return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}{17}",
								GetCurrentDateAsString(), Total, Executed, Passed,
								Error, Failed, Timeout, Aborted, 
								Inconclusive, PassedButRunAborted, NotRunnable, NotExecuted, 
								Disconnected, Warning, Completed, InProgress, 
								Pending, Environment.NewLine);
		}
		
		public static string CsvHeader
		{	//This has to be kept in sync with ToCsv!!!
			get
			{
				return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}",
								"Date", "Total", "Executed", "Passed", 
								"Error", "Failed", "Timeout", "Aborted", 
								"Inconclusive", "PassedButRunAborted", "NotRunnable", "NotExecuted", 
								"Disconnected", "Warning", "Completed", "InProgress", 
								"Pending");
			}
		}

		internal static string GetCurrentDateAsString()
		{
			return DateTime.Now.ToString("ddMMyyyy");
		}
	}
}
