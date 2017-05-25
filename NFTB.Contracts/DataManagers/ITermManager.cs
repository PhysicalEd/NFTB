using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;

namespace NFTB.Contracts.DataManagers
{
    public partial interface ITermManager
    {
        /// <summary>
        /// Saves this person to the data store
        /// </summary>
        List<TermSummary> GetTerms();

    }
}
