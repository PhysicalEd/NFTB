using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using NFTB.Common.Extensions;
using NFTB.Contracts;
using NFTB.Contracts.Cache;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;
using NFTB.Contracts.Enums;
using NFTB.Contracts.Exceptions;
using NFTB.Dep;


namespace NFTB.Logic.DataManagers
{
    public partial class AttendanceManager : IAttendanceManager
    {
        //public List<AttendanceSummary> GetEmptyPlayerAttendances(int sessionID)
        //{
        //    // Grab the latest active term if there is no sessionID specified
        //    var latestTermID = Dependency.Resolve<ITermManager>().GetLatestActiveTerm()?.TermID;
        //    var sessionManager = Dependency.Resolve<ISessionManager>();
        //    var session = sessionManager.GetSessions(sessionID);

        //    //if (session == null) throw new UserException("Cannot find session");

        //    // Use latest term ID if there is no session. IE. it is a new session
        //    var termID = session?.TermID ?? latestTermID;

        //    using (var cxt = DataStore.GetDataStore())
        //    {
        //        var data = (
        //            from p in cxt.Player

        //            join person in cxt.Person on p.PersonID equals person.PersonID

        //            join tp in cxt.TermPlayer on p.PlayerID equals tp.PlayerID into tps
        //            from tp in tps.DefaultIfEmpty()

        //            select new AttendanceSummary()
        //            {
        //                // Set defaults
        //                SessionID = session.SessionID,
        //                TermID = termID,
        //                PlayerID = p.PlayerID,
        //                FirstName = person.FirstName,
        //                LastName = person.LastName,
        //                HasAttended = false,
        //                IsCasual = tp == null
        //            }
        //        ).Distinct().ToList();

        //        return data.Where(x => x.TermID == termID || x.TermID == null).ToList();
        //    }
        //}

        public List<AttendanceSummary> GetAttendedPlayerAttendances(int attendanceID)
        {
            // We will return a list of both players attended and not attended
            using (var cxt = DataStore.GetDataStore())
            {
                //var playersAttended = cxt.PlayerAttendance.Where(x => x.SessionID == sessionID);
                var data = (
                    from p in cxt.Player

                    join pa in cxt.Attendance on p.PlayerID equals pa.PlayerID into pas
                    //join pa in playersAttended on p.PlayerID equals pa.PlayerID into pas
                    from pa in pas.DefaultIfEmpty()

                    join att in cxt.Session on pa.AttendanceID equals att.SessionID into atts
                    from att in atts.DefaultIfEmpty()

                    join t in cxt.Term on att.TermID equals t.TermID into ts
                    from t in ts.DefaultIfEmpty()

                    join person in cxt.Person on p.PersonID equals person.PersonID
                    select new AttendanceSummary()
                    {
                        PlayerID = p.PlayerID,
                        AmountPaid = pa != null ? pa.AmountPaid : 0,
                        SessionID = att != null ? att.SessionID : 0,
                        IsCasual = pa == null,
                        AttendanceID = pa != null ? pa.AttendanceID : 0,
                        HasAttended = pa != null && pa.AttendanceID > 0,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        // These are left joins so if the player hasn't attended, use the termID provided...
                        TermID = t != null ? t.TermID : 0
                    }
                ).ToList();

                return data.Where(x => x.SessionID == attendanceID).ToList();
            }
        }
        public List<AttendanceSummary> GetAttendances(int sessionID)
        {
            // We will return a list of both players attended and not attended
            using (var cxt = DataStore.GetDataStore())
            {
                //var playersAttended = cxt.PlayerAttendance.Where(x => x.SessionID == sessionID);
                var data = (
                    from pa in cxt.Attendance
                    join att in cxt.Session on pa.AttendanceID equals att.SessionID
                    join t in cxt.Term on att.TermID equals t.TermID
                    join p in cxt.Player on pa.PlayerID equals p.PlayerID
                    join person in cxt.Person on p.PersonID equals person.PersonID

                    join tp in cxt.TermPlayer on p.PlayerID equals tp.PlayerID into tps
                    from tp in tps.DefaultIfEmpty()

                    where att.SessionID == sessionID

                    select new AttendanceSummary()
                    {
                        PlayerID = p.PlayerID,
                        AmountPaid = pa.AmountPaid,
                        SessionID = pa.AttendanceID,
                        IsCasual = tp == null,
                        AttendanceID = pa.AttendanceID,
                        HasAttended = true,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        TermID = att.TermID
                    }
                ).Distinct().ToList();

                return data;
            }
        }






        //public List<TermCasualPlayerSummary> GetTermCasualPlayers()
        //{
        //    //using (var cxt = DataStore.GetDataStore())
        //    //{
        //    //    var data = (
        //    //            from tcp in cxt.TermCasualPlayer
        //    //            join t in cxt.Term on tcp.TermID equals t.TermID
        //    //            join p in cxt.Player on tcp.PlayerID equals p.PlayerID
        //    //            join pn in cxt.Person on p.PersonID equals pn.PersonID
        //    //            select new TermCasualPlayerSummary()
        //    //            {
        //    //                TermCasualPlayerID = tcp.TermCasualPlayerID,
        //    //                TermID = tcp.TermID,
        //    //                HasPaid = tcp.Paid,

        //    //            }
        //    //        );
        //    //    return data.ToList();
        //    //}
        //    return null;
        //}


        //private List<SessionSummary> SavePlayerAttendances(int sessionID, List<SessionSummary> playerAttendances)
        //{
        //    // We will get the current player attendances first so we can delete the ones not passed in...
        //    var attendancesToBeRemoved = this.GetEmptyPlayerAttendances(sessionID);
        //    if (attendancesToBeRemoved == null) throw new UserException("Cannot find player attendances for the session");



        //    // Create the SessionSummary items


        //    using (var cxt = DataStore.GetDataStore())
        //    {
        //        foreach (var session in playerAttendances)
        //        {
        //            // Remove from current attendances
        //            attendancesToBeRemoved.RemoveAll(x => x.PlayerID == session.PlayerID);

        //            var data = cxt.GetOrCreatePlayerAttendance(session.SessionID);
        //            data.AmountPaid = session.AmountPaid;
        //            data.PlayerID = session.PlayerID;
        //            data.SessionID = sessionID;
        //            cxt.SubmitChanges();
        //        }

        //        this.DeletePlayerAttendances(attendancesToBeRemoved);

        //    }
        //    return null;
        //}

        public AttendanceSummary SaveAttendance(int attendanceID, int playerID, decimal amountPaid)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var playerAttendance = cxt.Attendance.FirstOrDefault(x => x.AttendanceID == attendanceID && x.PlayerID == playerID);
                var pa = cxt.GetOrCreateAttendance(playerAttendance?.AttendanceID);
                if (pa.IsNew)
                {
                    pa.AttendanceID = attendanceID;
                    pa.PlayerID = playerID;
                    pa.AmountPaid = amountPaid;
                }
                cxt.SaveChanges();
                return this.GetAttendances(pa.AttendanceID).FirstOrDefault(x => x.PlayerID == pa.PlayerID);
            }
        }

        public void DeleteAttendance(int attendanceID)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var pa = cxt.Attendance.FirstOrDefault(x => x.AttendanceID == attendanceID);
                if (pa == null) return;
                cxt.Attendance.DeleteObject(pa);
                cxt.SubmitChanges();
            }
        }

        private void DeletePlayerAttendances(List<AttendanceSummary> attendances)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                // EO TODO We should do this bulk rather than calling per session
                foreach (var attendance in attendances)
                {
                    var data = cxt.Attendance.FirstOrDefault(x => x.PlayerID == attendance.PlayerID && x.AttendanceID == attendance.SessionID);
                    if (data == null) continue;
                    cxt.Attendance.DeleteObject(data);
                    cxt.SubmitChanges();
                }
            }

        }

        // EO TODO All new at this point... It might better doing it this way...


    }
}
