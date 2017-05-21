using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Common
{
	public class Configuration
	{

		#region Static Methods

		public static Configuration Current
		{
			get
			{
				return new Configuration();
			}
		}

		#endregion

#region Configuration Accessors

		private NFTB.Contracts.IAppSettingsRetriever _Config = null;

		private NFTB.Contracts.IAppSettingsRetriever Config
		{
			get
			{
				if (_Config == null) { _Config = Dependency.Resolve<NFTB.Contracts.IAppSettingsRetriever>(); }
				return _Config;
			}
		}

		/// <summary>
		/// Returns a string representation of this application setting
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		private string GetString(string key)
		{
			return this.Config.GetValue(key) ?? "";
		}

		/// <summary>
		/// Returns a boolean representation of this application setting
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		private bool GetBool(string key, bool defaultValue = false)
		{
			string val = this.Config.GetValue(key);
			if (string.IsNullOrEmpty(val)) { return defaultValue; }
			return bool.Parse(val);
		}

		/// <summary>
		/// Returns an integer representation of this application setting
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		private int GetInt(string key)
		{
			string val = this.Config.GetValue(key);
			if (string.IsNullOrEmpty(val)) { return 0; }
			return int.Parse(val);
		}

#endregion

		#region Application Settings

		/// <summary>
		/// Do we use the cache in the current system?
		/// </summary>
		public bool UseCache { get { return this.GetBool("UseCache"); } }

		/// <summary>
		/// The base URL of this website
		/// </summary>
		public string SiteRoot
		{
			get
			{
				var env = Dependency.Resolve<NFTB.Contracts.IEnvironment>();
				return env.SiteRoot;
			}
		}

		

		#endregion

	}
}
