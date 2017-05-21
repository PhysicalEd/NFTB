using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Repositories
{
    public interface IRepositoryInitializer
    {
        IRepository Create();
        IRepository Create(string callerDescription);
    }
}
