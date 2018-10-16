using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.API.Models;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Dep;

namespace NFTB.API.Controllers
{
    public class PlayerController : Basecontroller
    {
        [HttpPost]
        public PlayerListModel PlayerList()
        {
            var model = new PlayerListModel();
            model.Players = Dependency.Resolve<IPlayerManager>().GetPlayers(null, null);
            return model;
        }

        [HttpGet]
        public PlayerSummary PlayerEditor(int? playerID)
        {
            var player = Dependency.Resolve<IPlayerManager>().GetPlayer(playerID.GetValueOrDefault(0)) ?? new PlayerSummary();
            return player;
        }

        [HttpPost]
        public PlayerSummary SavePlayer(PlayerSummary player)
        {
            var playerMgr = Dependency.Resolve<IPlayerManager>();
            // Save player
            return playerMgr.SavePlayer(player.PlayerID, player.FirstName, player.LastName, player.Phone, player.Email);
        }

        [HttpGet]
        public void DeletePlayer(int playerID)
        {
            Dependency.Resolve<IPlayerManager>().DeletePlayer(playerID);
        }

        [HttpGet]
        public List<PlayerSummary> TermPlayerList(int? termID)
        {
            //return Dependency.Resolve<IPlayerManager>().GetTermPlayers(null, termID.GetValueOrDefault(0));
            return null;
        }






    }
}
