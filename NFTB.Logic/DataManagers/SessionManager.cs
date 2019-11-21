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
    public partial class SessionManager : ISessionManager
    {
        public List<SessionSummary> GetSessions(int? sessionID, int? termID)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var data = (
                        from a in cxt.Session
                        join t in cxt.Term on a.TermID equals t.TermID
                        select new SessionSummary()
                        {
                            SessionID = a.SessionID,
                            TermID = a.TermID,
                            TermName = t.TermName,
                            AttendanceDate = a.Date,
                            IsDisabled = a.IsDisabled,
                            CasualsRate = t.CasualRate,
                        }
                    ).ToList();

                // Filters
                if (termID.HasValue) data = data.Where(x => x.TermID == termID).ToList();
                if (sessionID.HasValue) data = data.Where(x => x.SessionID == sessionID).ToList();
                return data;
            }
        }

        public SessionSummary GetSession(int sessionID)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var attendance = cxt.Session.FirstOrDefault(x => x.SessionID == sessionID);
                return this.GetSessions(sessionID, attendance?.TermID).FirstOrDefault();
            }

        }

        public void DeleteSession(int sessionID)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var attendance = (from a in cxt.Session
                                  where a.SessionID == sessionID
                                  select a
                    ).FirstOrDefault();
                if (attendance == null) return;
                cxt.Session.DeleteObject(attendance);
                cxt.SubmitChanges();
            }
        }

        public SessionSummary SaveSession(SessionSummary session)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var data = cxt.GetOrCreateSession(session.SessionID);
                if (data.IsNew)
                {

                    // TODO If there is no active term, throw error...
                }
                data.Date = session.AttendanceDate;
                data.TermID = session.TermID;
                cxt.SubmitChanges();
                //this.SavePlayerAttendances(data.SessionID, session.PlayerAttendances);

                return this.GetSession(data.SessionID);
            }
        }



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

        // EO TODO All new at this point... It might better doing it this way...


    }
}
