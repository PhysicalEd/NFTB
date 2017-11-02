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


namespace NFTB.Logic.DataManagers
{
    public partial class AttendanceManager : IAttendanceManager
    {
        public List<AttendanceSummary> GetAttendances(int? termID, bool includeDisabled = false)
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var data = (
                        from a in cxt.Attendance
                        join t in cxt.Term on a.TermID equals t.TermID
                        select new AttendanceSummary()
                        {
                            AttendanceID = a.AttendanceID,
                            TermID = a.TermID,
                            TermName = t.TermName,
                            AttendanceDate = a.AttendanceDate,
                            IsDisabled = a.IsDisabled,
                            CasualsRate = t.CasualRate,
                        }
                    ).ToList();

                // Filters
                if (termID.HasValue) data = data.Where(x => x.TermID == termID).ToList();
                return data;
            }
        }

        public List<PlayerAttendanceSummary> GetEmptyPlayerAttendances(int attendanceID)
        {
            // Grab the latest active term if there is no attendanceID specified
            var latestTermID = Dependency.Resolve<ITermManager>().GetLatestActiveTerm()?.TermID;
            var attendance = this.GetAttendance(attendanceID);

            //if (attendance == null) throw new UserException("Cannot find attendance");

            // Use latest term ID if there is no attendance. IE. it is a new attendance
            var termID = attendance?.TermID ?? latestTermID;

            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var data = (
                    from p in cxt.Player

                    join person in cxt.Person on p.PersonID equals person.PersonID

                    join tp in cxt.TermPlayer on p.PlayerID equals tp.PlayerID into tps
                    from tp in tps.DefaultIfEmpty()

                    select new PlayerAttendanceSummary()
                    {
                        // Set defaults
                        AttendanceID = attendance.AttendanceID,
                        TermID = termID,
                        PlayerID = p.PlayerID,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        HasAttended = false,
                        IsCasual = tp == null
                    }
                ).Distinct().ToList();

                return data.Where(x => x.TermID == termID || x.TermID == null).ToList();
            }
        }

        public List<PlayerAttendanceSummary> GetAttendedPlayerAttendances(int attendanceID)
        {
            // We will return a list of both players attended and not attended
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                //var playersAttended = cxt.PlayerAttendance.Where(x => x.AttendanceID == attendanceID);
                var data = (
                    from p in cxt.Player

                    join pa in cxt.PlayerAttendance on p.PlayerID equals pa.PlayerID into pas
                    //join pa in playersAttended on p.PlayerID equals pa.PlayerID into pas
                    from pa in pas.DefaultIfEmpty()

                    join att in cxt.Attendance on pa.AttendanceID equals att.AttendanceID into atts
                    from att in atts.DefaultIfEmpty()

                    join t in cxt.Term on att.TermID equals t.TermID into ts
                    from t in ts.DefaultIfEmpty()

                    join person in cxt.Person on p.PersonID equals person.PersonID
                    select new PlayerAttendanceSummary()
                    {
                        PlayerID = p.PlayerID,
                        AmountPaid = pa != null ? pa.AmountPaid : 0,
                        AttendanceID = att != null ? att.AttendanceID : 0,
                        IsCasual = pa == null,
                        PlayerAttendanceID = pa != null ? pa.PlayerAttendanceID : 0,
                        HasAttended = pa != null && pa.PlayerAttendanceID > 0,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        // These are left joins so if the player hasn't attended, use the termID provided...
                        TermID = t != null ? t.TermID : 0
                    }
                ).ToList();

                return data.Where(x => x.AttendanceID == attendanceID).ToList();
            }
        }
        // EO TODO For real...
        public List<PlayerAttendanceSummary> GetPlayerAttendances(int attendanceID)
        {
            // We will return a list of both players attended and not attended
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                //var attendedPlayers = (

                //    select new {pa, att, t, p, person}
                //);



                //var playersAttended = cxt.PlayerAttendance.Where(x => x.AttendanceID == attendanceID);
                var data = (
                    from pa in cxt.PlayerAttendance

                    join att in cxt.Attendance on pa.AttendanceID equals att.AttendanceID

                    join t in cxt.Term on att.TermID equals t.TermID

                    join p in cxt.Player on pa.PlayerID equals p.PlayerID

                    join person in cxt.Person on p.PersonID equals person.PersonID

                                        //from ap in attendedPlayers
                                        //from pa in cxt.PlayerAttendance

                                        //join att in cxt.Attendance on pa.AttendanceID equals att.AttendanceID

                                        //join t in cxt.Term on att.TermID equals t.TermID

                                        join tp in cxt.TermPlayer on p.PlayerID equals tp.PlayerID into tps
                    from tp in tps.DefaultIfEmpty()
                    where att.AttendanceID == attendanceID



                    select new PlayerAttendanceSummary()
                    {
                        PlayerID = p.PlayerID,
                        AmountPaid = pa.AmountPaid,
                        AttendanceID = pa.AttendanceID,
                        IsCasual = tp == null,
                        PlayerAttendanceID = pa.PlayerAttendanceID,
                        // EO TODO
                        HasAttended = true,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        // These are left joins so if the player hasn't attended, use the termID provided...
                        TermID = att.TermID
                    }
                ).Distinct().ToList();

                return data;
            }
        }






        //public List<TermCasualPlayerSummary> GetTermCasualPlayers()
        //{
        //    //using (var cxt = DataStore.CreateBlackBallArchitectureContext())
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

        public AttendanceSummary GetAttendance(int attendanceID)
        {
            return this.GetAttendances(null).FirstOrDefault(x => x.AttendanceID == attendanceID);
        }

        public void DeleteAttendance(int attendanceID)
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var attendance = (from a in cxt.Attendance
                                  where a.AttendanceID == attendanceID
                                  select a
                    ).FirstOrDefault();
                if (attendance == null) return;
                cxt.Attendance.DeleteObject(attendance);
                cxt.SubmitChanges();
            }
        }

        public AttendanceSummary SaveAttendance(AttendanceSummary attendance)
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var data = cxt.GetOrCreateAttendance(attendance.AttendanceID);
                if (data.IsNew)
                {

                    // TODO If there is no active term, throw error...
                }
                data.AttendanceDate = attendance.AttendanceDate;
                data.TermID = attendance.TermID;
                cxt.SubmitChanges();
                this.SavePlayerAttendances(data.AttendanceID, attendance.PlayerAttendances);

                return this.GetAttendance(data.AttendanceID);
            }
        }



        private List<PlayerAttendanceSummary> SavePlayerAttendances(int attendanceID, List<PlayerAttendanceSummary> playerAttendances)
        {
            // We will get the current player attendances first so we can delete the ones not passed in...
            var attendancesToBeRemoved = this.GetEmptyPlayerAttendances(attendanceID);
            if (attendancesToBeRemoved == null) throw new UserException("Cannot find player attendances for the attendance");



            // Create the PlayerAttendanceSummary items


            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                foreach (var attendance in playerAttendances)
                {
                    // Remove from current attendances
                    attendancesToBeRemoved.RemoveAll(x => x.PlayerID == attendance.PlayerID);

                    var data = cxt.GetOrCreatePlayerAttendance(attendance.PlayerAttendanceID);
                    data.AmountPaid = attendance.AmountPaid;
                    data.PlayerID = attendance.PlayerID;
                    data.AttendanceID = attendanceID;
                    cxt.SubmitChanges();
                }

                this.DeletePlayerAttendances(attendancesToBeRemoved);

            }
            return null;
        }

        private void DeletePlayerAttendances(List<PlayerAttendanceSummary> attendances)
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                // EO TODO We should do this bulk rather than calling per attendance
                foreach (var attendance in attendances)
                {
                    var data = cxt.PlayerAttendance.FirstOrDefault(x => x.PlayerID == attendance.PlayerID && x.AttendanceID == attendance.AttendanceID);
                    if (data == null) continue;
                    cxt.PlayerAttendance.DeleteObject(data);
                    cxt.SubmitChanges();
                }
            }

        }

        // EO TODO All new at this point... It might better doing it this way...


    }
}
