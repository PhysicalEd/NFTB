using System;
using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class AttendanceEditorModel
    {
        public AttendanceSummary Attendance { get; set; } = new AttendanceSummary();
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        public List<PlayerAttendanceSummary> TermPlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        public List<PlayerAttendanceSummary> CasualPlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        public List<PlayerSummary> PlayerList { get; set; } = new List<PlayerSummary>();
    }
}
