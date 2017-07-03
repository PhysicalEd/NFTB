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


namespace NFTB.Logic.DataManagers
{
	public partial class PlayerManager : IPlayerManager
	{
        public List<PlayerSummary> GetPlayers()
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var data = (
                        from player in cxt.Player
                        join person in cxt.Person on player.PersonID equals person.PersonID

                        join tp in cxt.TermPlayer on player.PlayerID equals tp.PlayerID into tps
                        from tp in tps.DefaultIfEmpty()

                        select new PlayerSummary()
                        {
                            PlayerID = player.PlayerID,
                            PersonID = player.PersonID,
                            FirstName = person.FirstName,
                            LastName = person.LastName,

                            // Term player related
                            TermPlayerID = tp !=null ? tp.TermPlayerID : 0,
                            TermID = tp != null ? tp.TermID : 0,
                            BondPaid = tp != null ? tp.BondPaid : false,
                            TermDue = tp.TermDue,
                            TermOwing = tp.TermOwing
                        }
                    );
                return data.ToList();
            }
        }

        public List<TermPlayerSummary> GetTermPlayers(int? attendanceID)
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var data = (
                        from tp in cxt.TermPlayer
                        join p in cxt.Player on tp.PlayerID equals p.PlayerID
                        join person in cxt.Person on p.PersonID equals person.PersonID
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
                // data = attendanceID.HasValue ? data.Where(x => x.TermID == attendanceID) :data;
                return data.ToList();
            }
        }





        public PlayerSummary GetPlayer(int playerID)
	    {
	        return this.GetPlayers().FirstOrDefault(x=>x.PlayerID == playerID);
	    }

        public void DeletePlayer(int playerID)
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var player = (from p in cxt.Player
                            where p.PlayerID == playerID
                            select p
                    ).FirstOrDefault();
                if (player == null) return;
                //player.IsDeleted = true;
                cxt.SubmitChanges();
            }

        }
    }
}
