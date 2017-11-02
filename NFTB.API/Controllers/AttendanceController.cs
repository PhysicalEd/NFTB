using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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
        public AttendanceEditorModelResult AttendanceEditor(int? attendanceID)
        {
            var model = new AttendanceEditorModelResult();

            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();
            var termMgr = Dependency.Resolve<ITermManager>();
            var playerMgr = Dependency.Resolve<IPlayerManager>();
            // Get term
            var activeTerm = termMgr.GetLatestActiveTerm();
            
            // Get the attendnace
            model.Attendance = attendanceMgr.GetAttendance(attendanceID.GetValueOrDefault(0)) ?? new AttendanceSummary();

            var emptyAttendances = attendanceMgr.GetEmptyPlayerAttendances(model.Attendance.AttendanceID);
            var playerAttendances = attendanceMgr.GetPlayerAttendances(model.Attendance.AttendanceID);



            foreach (var pa in playerAttendances)
            {
                // Remove all attended players from the empty attendances...
                emptyAttendances.RemoveAll(x=>x.PlayerID == pa.PlayerID);
            }
            
            // Combine both unattended and attended
            model.PlayerAttendances.AddRange(emptyAttendances);
            model.PlayerAttendances.AddRange(playerAttendances);

            foreach (var pas in model.PlayerAttendances)
            {
                if (!pas.IsCasual) model.TermPlayerAttendances.Add(pas);
                if (pas.IsCasual) model.CasualPlayerAttendances.Add(pas);
            }


            foreach (var ea in model.PlayerAttendances)
            {

            }

            // We will throw an exception if there is a value sent but cannot be found in the system
            //if (attendanceID.HasValue && model.Attendance == null) throw new Exception();

            // Load player attendances. If attendanceID is null, this will simply return empty player attendances
            // model.PlayerAttendances = attendanceID.HasValue ? attendanceMgr.GetPlayerAttendances((int)attendanceID) : attendanceMgr.GenerateEmptyPlayerAttendances(termID);

            // Load all attendances. If there is an attendanceID do not include them.
            //var emptyAttendances = attendanceMgr.GetEmptyPlayerAttendances(termID);


            //var playersAttended = attendanceMgr.GetPlayerAttendances(attendanceID.GetValueOrDefault(0));
            //playersAttended.AddRange(unattended);
            //var playerAttendances = unattended.AddRange(attended);
            
            // This should return empty if
            // Go through each attendance and separate them
            //foreach (var playerAttendance in playersAttended)
            //{
            //    if (playerAttendance.IsCasual) model.CasualPlayerAttendances.Add(playerAttendance);
            //    if (!playerAttendance.IsCasual) model.TermPlayerAttendances.Add(playerAttendance);
            //}

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
