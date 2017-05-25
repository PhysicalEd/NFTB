using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackBallArchitecture.Contracts.Cache;

namespace BlackBallArchitecture.Test.Fakes
{
	class NoCache : ICacheManager
	{
		public int MinutesToRemainInCache { set {  } }

		public bool UseSlidingExpiration { set { } }

		public string DependsOnFileName { set {  } }

		public void Clear<T>(T itemToCache) where T : ICachable
		{
			
		}

		public T Load<T>(T objectWithKeySet, Func<string, T> dataStoreDelegate) where T : ICachable
		{
			return dataStoreDelegate.Invoke(objectWithKeySet.CacheKey);
		}

		public void Save<T>(T itemToCache) where T : ICachable
		{
		}

		public void ClearType<T>() where T : ICachable
		{
		}

		public void ClearTag(CacheTags tag, dynamic id)
		{
		}
	}
}
