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
        [HttpPost]
        [Authorize]
        public List<Person> PeopleList()
        {
			return Dependency.Resolve<IPersonManager>().GetPerson(null);
        }

        //[HttpGet]
        //public PlayerListModel GetPeople()
        //{
        //    var personMgr = Dependency.Resolve<IPersonManager>();
        //    var model = new PlayerListModel();

        //    model.CasualPlayers = new List<TermCasualPlayerSummary>()
        //    {
        //        new TermCasualPlayerSummary()
        //        {
        //            TermCasualPlayerID = 1,
        //            HasPaid = true
        //        }
        //    };

        //    model.PermanentPlayers = new List<PlayerSummary>()
        //    {
        //        new PlayerSummary()
        //        {
        //            PlayerID = 1,
        //            BondPaid = 100
        //        }
        //    };

        //    return model;
        //}
        //[HttpGet]
        [HttpGet]
        public Person SavePerson(int? personID, string firstName, string lastName, string phone, string email, bool isDeleted)
        {
            return Dependency.Resolve<IPersonManager>().SavePerson(personID, firstName, lastName, phone, email, isDeleted);
        }



        //[HttpGet]
        //public Person DeletePerson(int personID)
        //{
        //    // Check if person is deleteable..ieE. not being used in other tables..
        //    return Dependency.Resolve<IPersonManager>().DeletePerson(personID);
        //}

    }
}
