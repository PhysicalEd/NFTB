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
                        join p in cxt.Player on a.PlayerID equals p.PlayerID
                        join pn in cxt.Person on p.PlayerID equals pn.PersonID
                        select new AttendanceSummary()
                        {
                            AttendanceID = a.AttendanceID,
                            TermID = a.TermID,
                            PlayerID = a.PlayerID,
                            DateAttended = a.DateAttended,
                            FirstName = pn.FirstName,
                            LastName = pn.LastName
                        }
                    );
	            return data.ToList();
	        }
	    }

        public List<TermCasualPlayerSummary> GetTermCasualPlayers()
        {
            using (var cxt = DataStore.CreateBlackBallArchitectureContext())
            {
                var data = (
                        from tcp in cxt.TermCasualPlayer
                        join t in cxt.Term on tcp.TermID equals t.TermID
                        join p in cxt.Player on tcp.PlayerID equals p.PlayerID
                        join pn in cxt.Person on p.PersonID equals pn.PersonID
                        select new TermCasualPlayerSummary()
                        {
                            TermCasualPlayerID = tcp.TermCasualPlayerID,
                            TermID = tcp.TermID,
                            HasPaid = tcp.Paid,

                        }
                    );
                return data.ToList();
            }
        }

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
    }
}
