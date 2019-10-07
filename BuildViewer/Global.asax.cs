using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace BuildViewer
{
	public class Global : HttpApplication
	{
		// Copiezi web.config din proiect peste cel din inetpub.
		// Pui impersonate cu user si pass.
		// Copiezi webconfig in temp pt a executa in cmd ce e mai jos:
		//aspnet_regiis -pef system.web/identity C:\temp -prov DataProtectionConfigurationProvider
		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}