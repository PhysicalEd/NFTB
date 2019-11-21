using System;
using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class AttendanceListModel
    {
        public List<SessionSummary> Attendances { get; set; }
        public List<AttendanceSummary> PlayerAttendances { get; set; }

    }
}
