using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

            var attendances = attendanceMgr.GetAttendances(null, false);
            foreach (var attendance in attendances)
            {
                //attendance.TermPlayerAttendances = attendanceMgr.GetTermPlayerAttendances(attendance.AttendanceID);
            }

            return attendances;
        }

        [HttpGet]
        public AttendanceEditorModelResult AttendanceEditor(int? attendanceID, int termID)
        {
            var model = new AttendanceEditorModelResult();

            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
            var playerMgr = Dependency.Resolve<IPlayerManager>();
            // Get the attendnace
            model.Attendance = attendanceMgr.GetAttendance(attendanceID.GetValueOrDefault(0));
            
            // We will throw an exception if there is a value sent but cannot be found in the system
            if (attendanceID.HasValue && model.Attendance == null) throw new Exception();

            // Load player attendances. If attendanceID is null, this will simply return empty player attendances
            model.PlayerAttendances = attendanceID.HasValue ? attendanceMgr.GetPlayerAttendances((int)attendanceID) : attendanceMgr.GenerateEmptyPlayerAttendances(termID);
            
            // Go through each attendance and separate terms from casual attendances
            foreach (var playerAttendance in model.PlayerAttendances)
            {
                if (playerAttendance.TermID > 0) model.TermPlayerAttendances.Add(playerAttendance);
                if (playerAttendance.TermID <= 0) model.CasualPlayerAttendances.Add(playerAttendance);
            }
            
            return model;
        }

        //[HttpGet]
        //public AttendanceSummary SaveAttendance(int? attendanceID, DateTime attendanceDate, List<PlayerAttendanceSummary> playerAttendance)
        //{
        //    var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
        //    var attendance = attendanceMgr.SaveAttendance(attendanceID, attendanceDate);
        //    //var playerAttendances = 
        //    return null;
        //}

       
        [HttpPost]
        public AttendanceSummary SaveAttendance([FromBody] AttendanceSummary attendance) //, List<int> listOfNumbers)
        {
            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
            return attendanceMgr.SaveAttendance(attendance);

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
