using System;
using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class AttendanceListModel
    {
        public List<AttendanceSummary> Attendances { get; set; }
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; }

    }
}
