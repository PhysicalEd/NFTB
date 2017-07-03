using System;
using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class AttendanceEditorModel
    {
        public List<PlayerSummary> PlayerList { get; set; } = new List<PlayerSummary>();
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();

    }
}
