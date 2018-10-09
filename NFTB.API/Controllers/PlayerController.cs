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
    public class PlayerController : Basecontroller
    {
        [HttpGet]
        public List<PlayerSummary> PlayerList()
        {
			return Dependency.Resolve<IPlayerManager>().GetPlayers(null, null);
        }

        [HttpGet]
        public List<PlayerSummary> TermPlayerList(int? termID)
        {
            //return Dependency.Resolve<IPlayerManager>().GetTermPlayers(null, termID.GetValueOrDefault(0));
            return null;
        }

        [HttpGet]
        public PlayerSummary SavePlayer(int? playerID, string firstName, string lastName, string phone, string email)
        {
            var playerMgr = Dependency.Resolve<IPlayerManager>();
            // Save player
            return playerMgr.SavePlayer(playerID, firstName, lastName, phone, email);
        }

        [HttpGet]
        public void DeletePlayer(int playerID)
        {
            // Check if player is deleteable..ieE. not being used in other tables..
            Dependency.Resolve<IPlayerManager>().DeletePlayer(playerID);
        }




    }
}
