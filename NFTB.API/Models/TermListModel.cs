using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class TermDetailModel
    {
        public List<CasualPlayerSummary> CasualPlayers { get; set; }
        public List<PermanentPlayerSummary> PermanentPlayers { get; set; }

        public int NumberOfCasuals
        {
            get { return this.CasualPlayers.Count; }
        }

        public int NumberOfPerms
        {
            get { return this.PermanentPlayers.Count; }
        }
    }
}
