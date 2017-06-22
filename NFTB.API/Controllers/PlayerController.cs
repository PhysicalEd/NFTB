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
        public List<PlayerSummary> PlayerList()
        {
			return Dependency.Resolve<IPlayerManager>().GetPlayers();
        }

        [HttpGet]
        public PlayerSummary TermPermanentPlayerList(int? termID)
        {
            return null;
        }


    }
}
