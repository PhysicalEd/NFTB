using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class AttendanceEditorModel
    {
        public List<TermCasualPlayerSummary> CasualPlayers { get; set; } = new List<TermCasualPlayerSummary>();
        public List<TermPermanentPlayerSummary> PermanentPlayers { get; set; } = new List<TermPermanentPlayerSummary>();

    }
}
