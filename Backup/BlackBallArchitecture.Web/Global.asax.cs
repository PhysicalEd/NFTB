using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Combres;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using BlackBallArchitecture.Common.Navigation;
using BlackBallArchitecture.Contracts.Exceptions;

namespace BlackBallArchitecture.Web
{
	public class Global : System.Web.HttpApplication, IContainerAccessor
	{

		#region Properties

		public static IUnityContainer Container { get; set; }
		IUnityContainer IContainerAccessor.Container
		{
			get { return Container; }
		}

		#endregion


		protected void Application_Start(object sender, EventArgs e)
		{
			// Build unity
			IUnityContainer container = new UnityContainer();
			BlackBallArchitecture.Dependency.Register(container);
			Container = container;
			RouteTable.Routes.AddCombresRoute("Combres Route");
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// Logs the last server error
		/// </summary>
		private void LogError()
		{
			try
			{
				var err = Server.GetLastError();
				if (err == null)
				{
					return;
				}

				// Load inner exception, it tends to have more info
				if (err.InnerException != null)
				{
					err = err.InnerException;
				}

				// Display message
				if (err is UserException || err.GetType().IsSubclassOf(typeof(UserException)))
				{
					return;
				}

				// Log critical errors
				var log = Dependency.Resolve<Contracts.ILogger>();
				log.Log(err, "Unhandled exception logged by Global");
			}
			catch (Exception ex)
			{
				// Not much we can do here :(
			}
		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{
			if (Container != null) Container.Dispose();
		}

		/// <summary>
		/// Handles the OutputCache custom variables
		/// </summary>
		/// <param name="context"></param>
		/// <param name="custom"></param>
		/// <returns></returns>
		public override string GetVaryByCustomString(HttpContext context, string custom)
		{
			if (custom == "Browser")
			{
				var browser = context.Request.Browser;
				var s = browser.Browser + browser.MobileDeviceModel + browser.Version.ToString();
				return s;
			}
			return String.Empty;
		}

	}
}