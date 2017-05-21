using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Common.Extensions
{
	public static class ObjectExtensions
	{
		public static string ToJSON(this object obj)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
			return json;
		}

	}
}
