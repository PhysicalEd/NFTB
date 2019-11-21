using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;

namespace NFTB.Contracts.DataManagers
{
    public partial interface IAttendanceManager
    {
        void DeleteAttendance(int attendanceID);

        List<AttendanceSummary> GetAttendances(int attendanceID);
        //List<AttendanceSummary> GetEmptyPlayerAttendances(int sessionID);

        AttendanceSummary SaveAttendance(int attendanceID, int playerID, decimal amountPaid);


    }
}
