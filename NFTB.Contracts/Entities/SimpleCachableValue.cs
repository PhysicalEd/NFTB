using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Cache;

namespace NFTB.Contracts.Entities
{
	public class SimpleCachableValue<T> : ICachable
	{
		public T Value { get; set; }
		public string CacheKey { get; set; }
		

		private List<string> _Tags = new List<string>();
		public List<string> Tags
		{
			get { return _Tags; }
			set { _Tags = value; }
		}
	}
}
