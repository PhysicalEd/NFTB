using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.API.Models;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        public List<Person> PeopleList()
        {
			return Dependency.Resolve<IPersonManager>().GetPerson(null);
        }

        [HttpGet]
        public PlayerListModel GetPeople()
        {
            var personMgr = Dependency.Resolve<IPersonManager>();
            var model = new PlayerListModel();

            model.CasualPlayers = new List<CasualPlayerSummary>()
            {
                new CasualPlayerSummary()
                {
                    CasualPlayerID = 1,
                    HasPaid = true
                }
            };

            model.PermanentPlayers = new List<PermanentPlayerSummary>()
            {
                new PermanentPlayerSummary()
                {
                    TermPlayerID = 1,
                    BondPaid = 100
                }
            };

            return model;
        }
    }
}
