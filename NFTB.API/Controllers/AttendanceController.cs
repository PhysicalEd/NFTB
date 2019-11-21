using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using NFTB.API.Models;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Dep;
using NFTB.Logic.DataManagers;

namespace NFTB.API.Controllers
{

    public class AttendanceController : ApiController
    {

        [HttpPost]
        public AttendanceSummary SavePlayerAttendance([FromBody]AttendanceSummary attendance)
        {
            return Dependency.Resolve<IAttendanceManager>().SaveAttendance(attendance.SessionID, attendance.PlayerID, attendance.AmountPaid);
        }

        [HttpPost]
        public void DeleteAttendance(int playerAttendanceID)
        {
            Dependency.Resolve<IAttendanceManager>().DeleteAttendance(playerAttendanceID);
        }



    }




}
