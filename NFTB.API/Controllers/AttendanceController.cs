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
        [HttpGet]
        public List<AttendanceSummary> AttendanceList(int? termID)
        {
            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
            var attendances = attendanceMgr.GetAttendances(null, termID);

            return attendances;
        }
        
        [HttpGet]
        public AttendanceEditorModel AttendanceEditor(int? attendanceID)
        {
            var model = new AttendanceEditorModel();

            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
            var termMgr = Dependency.Resolve<ITermManager>();
            var playerMgr = Dependency.Resolve<IPlayerManager>();

            // Get the attendance
            model.Attendance = attendanceMgr.GetAttendance(attendanceID.GetValueOrDefault(0)) ?? new AttendanceSummary();

            if (model.Attendance.AttendanceID > 0)
            {
                // Get the player attendance
                model.PlayerAttendances = attendanceMgr.GetPlayerAttendances(model.Attendance.AttendanceID);
                model.PlayerList = playerMgr.GetPlayers(null, false);
            }
            
            return model;
        }
        
        [HttpPost]
        public AttendanceSummary SaveAttendance([FromBody] AttendanceSummary attendance) //, List<int> listOfNumbers)
        {
            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
            return attendanceMgr.SaveAttendance(attendance);
        }

        [HttpPost]
        public PlayerAttendanceSummary SavePlayerAttendance([FromBody]PlayerAttendanceSummary playerAttendance)
        {
            return Dependency.Resolve<IAttendanceManager>().SavePlayerAttendance(playerAttendance.AttendanceID, playerAttendance.PlayerID, playerAttendance.AmountPaid);
        }

        [HttpPost]
        public void DeletePlayerAttendance(int playerAttendanceID)
        {
            Dependency.Resolve<IAttendanceManager>().DeletePlayerAttendance(playerAttendanceID);
        }


        //[HttpGet]
        //public List<PlayerAttendanceSummary> TermPlayerAttendanceList()
        //{
        //    var attendanceMgr = Dependency.Resolve<IAttendanceManager>();

        //    var attendances = attendanceMgr.GetAttendances();
        //    foreach (var attendance in attendances)
        //    {
        //        attendance.TermPlayerAttendances = attendanceMgr.GetTermPlayerAttendances(attendance.AttendanceID);
        //    }

        //    return attendances;
        //}


        //public AttendanceEditorModelResult AttendanceEditor(int? attendanceID)
        //{
        //    var attendanceMgr = new AttendanceManager();
        //    var playerMgr = new PlayerManager();
        //    var attendanceEditorModel = new AttendanceEditorModelResult();

        //    attendanceEditorModel.PlayerList = playerMgr.GetPlayers(null);

        //    if (!attendanceID.HasValue)
        //    {
        //        foreach (var player in attendanceEditorModel.PlayerList)
        //        {

        //            var playerAttendance = new PlayerAttendanceSummary()
        //            {
        //                PlayerID = player.PlayerID,
        //                DisplayName = player.DisplayName
        //            };
        //            attendanceEditorModel.PlayerAttendances.Add(playerAttendance);
        //        }

        //    }

        //    //attendanceEditorModel.PlayerAttendances
        //    return attendanceEditorModel;
        //}

        //[HttpGet]
        //public void DeleteAttendance(int attendanceID)
        //{
        //    Dependency.Resolve<IAttendanceManager>().DeleteAttendance(attendanceID);
        //}

        //[HttpGet]
        //public List<PlayerAttendanceSummary> PlayerAttendanceList(int? attendanceID)
        //{
        //    var attendanceMgr = Dependency.Resolve<IAttendanceManager>();


        //    var attendance = attendanceMgr.GetAttendance(attendanceID.GetValueOrDefault(0));
        //    if (attendance == null) attendanceMgr.Save

        //    return Dependency.Resolve<IAttendanceManager>().GetPlayerAttendances(attendanceID);
        //}

    }




}
