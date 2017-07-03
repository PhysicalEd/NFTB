using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.API.Models;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Logic.DataManagers;

namespace NFTB.API.Controllers
{
    public class AttendanceController : ApiController
    {
        [HttpGet]
        public List<AttendanceSummary> AttendanceList()
        {
            //var attendanceListModel = new AttendanceListModel();
            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
            var attendances = attendanceMgr.GetAttendances();
            foreach (var attendance in attendances)
            {
                attendance.PlayerAttendances = attendanceMgr.GetPlayerAttendances(attendance.AttendanceID);
            }
            return attendances;
        }

        [HttpGet]
        public AttendanceEditorModel AttendanceEditor(int? attendanceID)
        {
            var attendanceMgr = new AttendanceManager();
            var playerMgr = new PlayerManager();
            var attendanceEditorModel = new AttendanceEditorModel();
            
            attendanceEditorModel.PlayerList = playerMgr.GetPlayers();

            if (!attendanceID.HasValue)
            {
                foreach (var player in attendanceEditorModel.PlayerList)
                {

                    var playerAttendance = new PlayerAttendanceSummary()
                    {
                        PlayerID = player.PlayerID,
                        PlayerName = player.PlayerName
                    };
                    attendanceEditorModel.PlayerAttendances.Add(playerAttendance);
                }

            }
            
            //attendanceEditorModel.PlayerAttendances
            return attendanceEditorModel;
        }

        [HttpGet]
        public void DeleteAttendance(int attendanceID)
        {
            Dependency.Resolve<IAttendanceManager>().DeleteAttendance(attendanceID);
        }
    }
}
