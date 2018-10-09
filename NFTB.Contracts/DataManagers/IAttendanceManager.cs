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
        List<AttendanceSummary> GetAttendances(int? attendanceID, int? termID);
        AttendanceSummary GetAttendance(int attendanceID);
        void DeletePlayerAttendance(int playerAttendanceID);

        void DeleteAttendance(int attendanceID);
        //List<PlayerAttendanceSummary> GetTermPlayerAttendances(int? attendanceID);
        List<PlayerAttendanceSummary> GetAttendedPlayerAttendances(int attendanceID);
        List<PlayerAttendanceSummary> GetPlayerAttendances(int attendanceID);
        AttendanceSummary SaveAttendance(AttendanceSummary attendance);
        List<PlayerAttendanceSummary> GetEmptyPlayerAttendances(int termID);

        PlayerAttendanceSummary SavePlayerAttendance(int attendanceID, int playerID, decimal amountPaid);


    }
}
