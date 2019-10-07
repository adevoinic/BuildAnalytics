using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuildViewer
{
	public partial class MasterGraphs : System.Web.UI.MasterPage
	{
		public int LastDays
		{
			get {
				int lastDays;
				var parsedOK = int.TryParse(txtLastDays.Text, out lastDays);
				if (!parsedOK)
				{
					lastDays = 22;
				}
				return lastDays;
			}
		}		 
	}
}