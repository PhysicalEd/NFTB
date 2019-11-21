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

    public class SessionController : ApiController
    {
        [Route("api/term/{termID}/sessions")]
        [HttpGet]
        public List<SessionSummary> SessionList(int? termID)
        {
            var sessionManager = Dependency.Resolve<ISessionManager>();
            var attendances = sessionManager.GetSessions(null, termID);

            return attendances;
        }

        [Route("api/attendance/sessions/{sessionID}")]
        [HttpGet]
        public SessionEditorModel SessionDetails(int? sessionID)
        {
            var model = new SessionEditorModel();

            var sessionManager = Dependency.Resolve<ISessionManager>();
            var attendanceManager = Dependency.Resolve<IAttendanceManager>();
            var termMgr = Dependency.Resolve<ITermManager>();
            var playerMgr = Dependency.Resolve<IPlayerManager>();

            // Get the attendance
            model.Session = sessionManager.GetSession(sessionID.GetValueOrDefault(0)) ?? new SessionSummary();

            if (model.Session.SessionID > 0)
            {
                // Get the player attendance
                model.Attendances = attendanceManager.GetAttendances(model.Session.SessionID);
                model.PlayerList = playerMgr.GetPlayers(null, false);
            }
            
            return model;
        }

        //[Route("api/attendance/attendancelist")]
        //[HttpPost]
        //public SessionSummary SaveSession([FromBody] SessionSummary attendance) //, List<int> listOfNumbers)
        //{
        //    var attendanceMgr = Dependency.Resolve<ISessionManager>();
        //    return attendanceMgr.SaveSession(attendance);
        //}

        //[Route("api/term/{termID}/attendance/")]
        //[HttpPut]
        //public SessionSummary SaveSession(int termID, int sessionID, [FromBody]SessionSummary attendance)
        //{
        //    term.TermID = termID;
        //    // We now need to check if the term exists first...
        //    var existingTerm = Dependency.Resolve<ITermManager>().GetTerm(term.TermID);
        //    if (existingTerm == null) throw new UserException("The term could not be retrieved from the datastore ");
        //    return this.SaveTerm(term);
        //}

    }




}
