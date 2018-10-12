﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Repositories;
using NFTB.Dep;

namespace NFTB.Logic
{
    public class DataStore
    {
        /// <summary>
        /// Creates a connection to the database or a test data store, depending on our unity configuration
        /// </summary>
        /// <returns></returns>
		public static IRepository GetDataStore(string activityOfDescription = "")
        {
            var initializer = Dependency.Resolve <IRepositoryInitializer>();
            return initializer.Create(activityOfDescription);
        }
    }
}
