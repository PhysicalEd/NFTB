using System.Collections.Generic;
using BlackBallArchitecture.Contracts.Cache;

namespace BlackBallArchitecture.Test.Fakes
{
	/// <summary>
	/// Class for unit testing which stores our 'persistent' objects in memory where required. In particular, it stores
	/// a database context so that we don't have to keep building the model
	/// </summary>
	public class StoreDatabaseContextInMemoryForUnitTests : IPersistentStorage
	{
		public static Dictionary<string, object> MemoryCache = new Dictionary<string, object>();

		public T Load<T>(string key)
		{
			return Load(key, default(T));
		}

		public void Clear()
		{
			MemoryCache.Clear();
		}

		public T Load<T>(string key, T defaultValue)
		{
			if (!MemoryCache.ContainsKey(key)) return defaultValue;
			object thing = MemoryCache[key];
			return (T)thing;
		}

		public void Save(object itemToSave, string key)
		{
			MemoryCache[key] = itemToSave;
		}
	}
}
