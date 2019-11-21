using System;
using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class SessionEditorModel
    {
        public SessionSummary Session { get; set; } = new SessionSummary();
        public List<AttendanceSummary> Attendances { get; set; } = new List<AttendanceSummary>();
        //public List<SessionSummary> TermPlayerAttendances { get; set; } = new List<SessionSummary>();
        //public List<SessionSummary> CasualPlayerAttendances { get; set; } = new List<SessionSummary>();
        public List<PlayerSummary> PlayerList { get; set; } = new List<PlayerSummary>();
    }
}
