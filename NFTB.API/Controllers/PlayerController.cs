using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.API.Models;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Exceptions;
using NFTB.Dep;

namespace NFTB.API.Controllers
{
    [RoutePrefix("api/player")]
    public class PlayerController : Basecontroller
    {
        [Route("players")]
        [HttpGet]
        public PlayerListModel PlayerList()
        {
            var model = new PlayerListModel();
            model.Players = Dependency.Resolve<IPlayerManager>().GetPlayers(null, null);
            return model;
        }

        [Route("players/{playerid}")]
        [HttpGet]
        public PlayerSummary PlayerDetails(int playerID)
        {
            var player = Dependency.Resolve<IPlayerManager>().GetPlayer(playerID);
            if (player == null) throw new UserException("The player could not be retrieved from the datastore");
            return player;
        }

        //[Route("playerlist/{playerid}")]
        //[HttpGet]
        //public PlayerSummary PlayerEditor(int? playerID)
        //{
        //    var player = Dependency.Resolve<IPlayerManager>().GetPlayer(playerID.GetValueOrDefault(0)) ?? new PlayerSummary();
        //    return player;
        //}

        [Route("players")]
        [HttpPost]
        public PlayerSummary SavePlayer([FromBody]PlayerSummary player)
        {
            var playerMgr = Dependency.Resolve<IPlayerManager>();
            // Save player
            return playerMgr.SavePlayer(player.PlayerID, player.FirstName, player.LastName, player.Phone, player.Email);
        }

        [Route("players/{playerID}")]
        [HttpPut]
        public PlayerSummary SavePlayer(int playerID, [FromBody]PlayerSummary player)
        {
            player.PlayerID = playerID;
            // We now need to check if the player exists first...
            var existingPlayer = Dependency.Resolve<IPlayerManager>().GetPlayer(player.PlayerID);
            if (existingPlayer == null) throw new UserException("The player could not be retrieved from the datastore");
            return this.SavePlayer(player);
        }

        [Route("players/{playerID}")]
        [HttpDelete]
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
