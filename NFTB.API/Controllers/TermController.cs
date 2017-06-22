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
        public List<TermSummary> TermList()
        {
			return Dependency.Resolve<ITermManager>().GetTerms();
        }

        [HttpGet]
        public TermSummary TermEditor(int? termID, string termName, DateTime termStart, DateTime? termEnd, int bondAmount, int casualRate, bool includeOrganizer)
        {
            return Dependency.Resolve<ITermManager>().SaveTerm(termID, termName, termStart, termEnd, bondAmount, casualRate, includeOrganizer);
        }

        [HttpGet]
        public void DeleteTerm(int? termID)
        {
            Dependency.Resolve<ITermManager>().DeleteTerm(termID);
        }
    }
}
