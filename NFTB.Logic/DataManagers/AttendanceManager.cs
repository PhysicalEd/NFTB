using System;
using System.Collections.Generic;
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


namespace NFTB.Logic.DataManagers
{
	public partial class AttendanceManager : IAttendanceManager
	{
	    public List<AttendanceSummary> GetAttendances()
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
                            AttendanceDate = a.AttendanceDate
                        }
                    ).ToList();
	            return data;
	        }
	    }

	    public List<PlayerAttendanceSummary> GetPlayerAttendances(int? attendanceID, int termID)
	    {
            

            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var playersAttended = cxt.PlayerAttendance.Where(x => x.AttendanceID == attendanceID);

                var data = (
                    from p in cxt.Player

                    join pa in playersAttended on p.PlayerID equals pa.PlayerID into pas
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
                        IsCasual = pa != null && pa.IsCasual,
                        PlayerAttendanceID = pa != null ? pa.PlayerAttendanceID: 0,
                        HasAttended = pa != null && pa.PlayerAttendanceID > 0,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        // These are left joins so if the player hasn't attended, use the termID provided...
                        TermID = t != null ? t.TermID: termID
                    }

                   
                ).ToList();

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
	        return this.GetAttendances().FirstOrDefault(x=>x.AttendanceID == attendanceID);
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
                    
                    data.TermID = Dependency.Resolve<ITermManager>().GetTerms(false).FirstOrDefault(x=>x.IsActive).TermID;
                    // TODO If there is no active term, throw error...
                    data.AttendanceDate = attendance.AttendanceDate;
                }
                cxt.SubmitChanges();
                this.SavePlayerAttendances(data.AttendanceID, attendance.PlayerAttendances);

                return this.GetAttendance(data.AttendanceID);
            }
        }

        private List<PlayerAttendanceSummary> SavePlayerAttendances(int attendanceID, List<PlayerAttendanceSummary> playerAttendances)
        {
            // Create the PlayerAttendanceSummary items


            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                foreach (var attendance in playerAttendances)
                {
                    var data = cxt.GetOrCreatePlayerAttendance(attendance.PlayerAttendanceID);
                    data.AmountPaid = attendance.AmountPaid;
                    data.IsCasual = attendance.IsCasual;
                    data.PlayerID = attendance.PlayerID;
                    data.AttendanceID = attendanceID;
                    cxt.SubmitChanges();
                }

            }
            return null;
        }
    }
}
