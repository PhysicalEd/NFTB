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
using NFTB.Dep;


namespace NFTB.Logic.DataManagers
{
	public partial class PlayerManager : IPlayerManager
	{
        public List<PlayerSummary> GetPlayers(int? playerID, bool? includeDeleted)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var data = (
                        from player in cxt.Player
                        join person in cxt.Person on player.PersonID equals person.PersonID

                        //join tp in cxt.TermPlayer on player.PlayerID equals tp.PlayerID into tps
                        //from tp in tps.DefaultIfEmpty()

                        //where player.IsDeleted == false
                        
                        select new PlayerSummary()
                        {
                            PlayerID = player.PlayerID,
                            PersonID = player.PersonID,
                            IsDeleted = player.IsDeleted,
                            FirstName = person.FirstName,
                            LastName = person.LastName,

                            // Term player related
                            //TermPlayerID = tp !=null ? tp.TermPlayerID : 0,
                            //TermID = tp != null ? tp.TermID : 0,
                            //BondPaid = tp != null ? tp.BondPaid : false,
                            //TermDue = tp.TermDue,
                            //TermOwing = tp.TermOwing
                        }
                    );

                // Apply filters
                if (playerID.HasValue) data = data.Where(x => x.PlayerID == playerID);
                return data.ToList();
            }
        }

        public List<TermPlayerSummary> GetTermPlayers(int? termPlayerID, int termID)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var data = (
                        from tp in cxt.TermPlayer
                        join p in cxt.Player on tp.PlayerID equals p.PlayerID
                        join person in cxt.Person on p.PersonID equals person.PersonID
                        where tp.TermID == termID
                        select new TermPlayerSummary()
                        {
                            TermID = tp.TermID,
                            BondPaid = tp.BondPaid,
                            TermDue = tp.TermDue,
                            TermOwing = tp.TermOwing,
                            PlayerID = p.PlayerID,
                            FirstName = person.FirstName,
                            LastName = person.LastName
                        }
                    );

                // Apply term filter
                data = termPlayerID.HasValue ? data.Where(x => x.TermPlayerID == termPlayerID) :data;
                return data.ToList();
            }
        }
        public PlayerSummary GetPlayer(int playerID)
	    {
	        return this.GetPlayers(playerID, null).FirstOrDefault();
	    }

        public void DeletePlayer(int playerID)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var player = cxt.Player.FirstOrDefault(x => x.PlayerID == playerID);
                if (player == null) return;

                // Check if this player has been either marked as a term player before or has been marked in attendances
                var hasBeenAAtermPlayerBefore = cxt.TermPlayer.Any(x => x.PlayerID == player.PlayerID);
                var hasAttendances = cxt.PlayerAttendance.Any(x => x.PlayerID == playerID);

                if (hasBeenAAtermPlayerBefore || hasAttendances)
                {
                    player.IsDeleted = true;

                }
                else
                {
                    cxt.Player.DeleteObject(player);
                }

                cxt.SubmitChanges();
            }

        }

        /// <summary>
        /// Saves this person to the data store
        /// </summary>
        public PlayerSummary SavePlayer(int? playerID, string firstName, string lastName, string phone, string email)
        {         
            // Now load new one for updates
            using (var cxt = DataStore.GetDataStore())
            {
                var player = cxt.GetOrCreatePlayer(playerID);
                var person = Dependency.Resolve<IPersonManager>().SavePerson(null, firstName, lastName, phone, email, false);
                player.PersonID = person.PersonID;
                cxt.SubmitChanges();

                // Log this update
                return this.GetPlayer(player.PlayerID);
            }
        }
    }
}
