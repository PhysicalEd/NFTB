using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;

namespace NFTB.Contracts.DataManagers
{
    public partial interface ISessionManager
    {
        SessionSummary GetSession(int sessionID);

        void DeleteSession(int sessionID);
        SessionSummary SaveSession(SessionSummary session);
        List<SessionSummary> GetSessions(int? sessionID, int? termID);


    }
}
