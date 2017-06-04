using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using NFTB.Common.Extensions;
using NFTB.Contracts;
using NFTB.Contracts.Cache;
using NFTB.Contracts.DataManagers;
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
                            Name = term.TermName,
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

	    public TermSummary GetTerm(int termID)
	    {
	        return this.GetTerms().FirstOrDefault(x=>x.TermID == termID);
	    }

        public TermSummary SaveTerm(int? termID, string termName, DateTime termStart, DateTime? termEnd, int bondAmount, int casualRate, bool includeOrganizer)
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var term = cxt.GetOrCreateTerm(termID);
                if (term.IsNew)
                {
                    term.TermName = termName;
                    term.TermStart = termStart;
                    term.TermEnd = termEnd;
                    term.BondAmount = bondAmount;
                    term.CasualRate = casualRate;
                    term.IncludeOrganizer = includeOrganizer;
                    cxt.SubmitChanges();
                }
                return this.GetTerm(term.TermID);
            }

        }
    }
}
