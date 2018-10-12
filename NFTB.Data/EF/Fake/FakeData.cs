using System;
using System.Collections.Generic;
using NFTB.Contracts.Cache;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Repositories;
using NFTB.Dep;

namespace NFTB.Data.EF.Fake {
    
    public partial class FakeData : IRepository
    {

        public int SaveChanges() {
			var storage = Dependency.Resolve<IPersistentStorage>();
			storage.Save(this, "validstubfakedata");
            return 1;
        }

        /// <summary>
        /// Saves the changes back to the data store
        /// </summary>
        public void SubmitChanges()
        {
            this.SaveChanges();
        }

		public static FakeData FromCache()
		{
			var storage = Dependency.Resolve<IPersistentStorage>();
			var fake = storage.Load<FakeData>("validstubfakedata");
			return fake;
		}

        public void Dispose() {
		
        }
    }
}