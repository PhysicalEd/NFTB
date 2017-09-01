using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Controllers
{
    public class TermController : ApiController
    {
        [HttpGet]
        public List<TermSummary> TermList(bool? includeDeleted)
        {
			return Dependency.Resolve<ITermManager>().GetTerms(includeDeleted);
        }

        [HttpGet]
        public TermSummary ActiveTerm()
        {
            return Dependency.Resolve<ITermManager>().GetTerms(false).FirstOrDefault(x=>x.IsActive);
        }

 
        [HttpGet]
        public void DeleteTerm(int? termID)
        {
            Dependency.Resolve<ITermManager>().DeleteTerm(termID);
        }

        [HttpGet]
        public TermSummary SaveTerm(int? termID, string termName, DateTime termStart, DateTime? termEnd, int bondAmount, int casualRate, bool includeOrganizer, bool isDeleted, bool isActive, bool isInvoiced)
        {
            var termMgr = Dependency.Resolve<ITermManager>();
            // Save term
            return termMgr.SaveTerm(termID, termName, termStart, termEnd, bondAmount, casualRate, includeOrganizer, isInvoiced);
        }
    }
}
