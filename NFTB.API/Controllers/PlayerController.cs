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
    public class PlayerController : ApiController
    {
        [HttpGet]
        public List<TermSummary> PlayerList()
        {
			return Dependency.Resolve<ITermManager>().GetTerms();
        }

        [HttpGet]
        public TermSummary TermPlayerList(int? termID)
        {
            return null;
        }
    }
}
