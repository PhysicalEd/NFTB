using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackBallArchitecture.Contracts.Security;

namespace BlackBallArchitecture.Web
{
	public class Library
	{
		public static int? CurrentPersonID
		{
			get
			{
				return Dependency.Resolve<ICurrentUser>().PersonID;
			}
		}

		/// <summary>
		/// Returns the full root of this page, with the http prefix
		/// </summary>
		/// <param name="partUrl"></param>
		/// <returns></returns>
		public static string GetFullUrl(string partUrl)
		{
			return Dependency.Resolve<BlackBallArchitecture.Contracts.IEnvironment>().GetFullUrl(partUrl);
		}

	}
}
