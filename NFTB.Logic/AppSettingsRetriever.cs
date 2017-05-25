using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Logic
{

	/// <summary>
	/// Returns values from the application configuration file
	/// </summary>
	public class AppSettingsRetriever : NFTB.Contracts.IAppSettingsRetriever
	{
		public AppSettingsRetriever()
		{ }


		public string GetValue(string key)
		{
			return System.Configuration.ConfigurationManager.AppSettings[key];
		}

		public string GetValueOrDefault(string key, string fallbackDefault)
		{
			return GetValue(key) ?? fallbackDefault;
		}
	}
}
