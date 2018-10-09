using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;

namespace NFTB.Contracts.DataManagers
{
    public partial interface IPlayerManager
    {
        List<PlayerSummary> GetPlayers(int? playerID, bool? includeDeleted);
        List<TermPlayerSummary> GetTermPlayers(int? termPlayerID, int termID);
        PlayerSummary SavePlayer(int? playerID, string firstName, string lastName, string phone, string email);
        PlayerSummary GetPlayer(int playerID);
        void DeletePlayer(int playerID);


    }
}
