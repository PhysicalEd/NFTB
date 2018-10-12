using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NFTB.Common.Extensions;
using NFTB.Contracts.Web;
using NFTB.Dep;

namespace NFTB.Common.Navigation
{
	public class LinkManager
	{
		/// <summary>
		/// Formats the prefix and postfix of the given URL
		/// </summary>
		/// <param name="relativeUrl"></param>
		/// <returns></returns>
		private string Format(string relativeUrl)
		{
			var siteRoot = Dependency.Resolve<NFTB.Contracts.IEnvironment>().SiteRoot;
			relativeUrl = siteRoot + relativeUrl;
			return relativeUrl;
		}

		public string Contact(string defaultSubject = "")
		{
			return this.Format("contact.aspx".AppendQueryString(QueryKeys.CONTACT_SUBJECT, defaultSubject));
		}

		public string Home()
		{
			return this.Format("default.aspx");
		}
	}
}
