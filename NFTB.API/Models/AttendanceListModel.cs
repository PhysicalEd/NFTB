using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class AttendanceListModel
    {
        public List<TermCasualPlayerSummary> CasualPlayers { get; set; }
        public List<TermPermanentPlayerSummary> PermanentPlayers { get; set; }

    }
}
