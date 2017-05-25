using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Common.Extensions;
using NFTB.Contracts;
using NFTB.Contracts.Cache;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;
using NFTB.Contracts.Enums;


namespace NFTB.Logic.DataManagers
{
	public partial class TermManager : ITermManager
	{
	    public List<TermSummary> GetTerms()
	    {
	        using (var cxt = DataStore.CreateBlackBallArchitectureContext())
	        {
	            var data = (
                        from term in cxt.Term
                        select new TermSummary()
                        {
                            TermID = term.TermID,
                            BondAmount = term.BondAmount,
                            CasualRate = term.CasualRate,
                            IncludeOrganizer = term.IncludeOrganizer,
                            TermStart = term.TermStart,
                            TermEnd = term.TermEnd
                        }
                    );
	            return data.ToList();
	        }
	    }
    }
}
