using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class PlayerListModel
    {
        public List<TermPlayerSummary> TermPlayers { get; set; }
    }
}
