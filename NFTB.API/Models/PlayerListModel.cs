using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class PlayerListModel
    {
        public List<CasualPlayerSummary> CasualPlayers { get; set; }
        public List<PermanentPlayerSummary> PermanentPlayers { get; set; }

    }
}
