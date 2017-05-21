using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Cache
{
	public interface ICachable
	{
		string CacheKey { get; set; }
		List<string> Tags { get; set; }
	}

	
}
