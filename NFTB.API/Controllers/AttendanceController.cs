using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Controllers
{
    public class AttendanceController : ApiController
    {
        [HttpGet]
        public List<AttendanceSummary> AttendanceList()
        {
			return Dependency.Resolve<IAttendanceManager>().GetAttendances();
        }

        [HttpGet]
        public AttendanceSummary AttendanceEditor()
        {
            //return Dependency.Resolve<IAttendanceManager>().SaveAttendance();
            return null;
        }

        [HttpGet]
        public void DeleteAttendance(int attendanceID)
        {
            Dependency.Resolve<IAttendanceManager>().DeleteAttendance(attendanceID);
        }
    }
}
