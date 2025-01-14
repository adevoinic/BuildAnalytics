﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace BuildViewer
{
	public class BundleConfig
	{
		// For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
							"~/Scripts/WebForms/WebForms.js",
							"~/Scripts/WebForms/WebUIValidation.js",
							"~/Scripts/WebForms/MenuStandards.js",
							"~/Scripts/WebForms/Focus.js",
							"~/Scripts/WebForms/GridView.js",
							"~/Scripts/WebForms/DetailsView.js",
							"~/Scripts/WebForms/TreeView.js",
							"~/Scripts/WebForms/WebParts.js"));

			// Order is very important for these files to work, they have explicit dependencies
			bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
					"~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
					"~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
					"~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
					"~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

			//bundles.Add(new ScriptBundle("~/bundles/Rgraph").Include(
			//		"~/Scripts/RGraph/libraries/RGraph.common.core.js",
			//		"~/Scripts/RGraph/libraries/RGraph.line.js"));
			
			// Use the Development version of Modernizr to develop with and learn from. Then, when you’re
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
							"~/Scripts/modernizr-*"));

			ScriptManager.ScriptResourceMapping.AddDefinition(
				"respond",
				new ScriptResourceDefinition
				{
					Path = "~/Scripts/respond.min.js",
					DebugPath = "~/Scripts/respond.js",
				});
		}
	}
}