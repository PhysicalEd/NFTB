using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Cache
{
    public interface IPersistentStorage
    {
		T Load<T>(string key);
		void Clear();
        void Save(object itemToSave, string key);
    }
}
