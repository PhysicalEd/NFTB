using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class SessionSummary
	{
        public int SessionID { get; set; }
        public int TermID { get; set; }
        public int CasualsRate { get; set; }
        public string TermName { get; set; }
	    public List<AttendanceSummary> PlayerAttendances { get; set; } = new List<AttendanceSummary>();

        public List<AttendanceSummary> TermPlayerAttendances { get; set; } = new List<AttendanceSummary>();
        public List<AttendanceSummary> CasualPlayerAttendances { get; set; } = new List<AttendanceSummary>();
	    public int TotalPlayersAttended => this.TermPlayerAttendances.Count;
	    public int CasualsAttended => this.CasualPlayerAttendances.Count;
	    public int TermPlayersAttended => this.TermPlayerAttendances.Count;
        public DateTime AttendanceDate { get; set; }
        public bool IsDisabled { get; set; }
	    public int ExpectedAmountFromCasuals => this.CasualsAttended * this.CasualsRate;
	    public decimal ActualAmountFromCasuals => this.CasualPlayerAttendances.Sum(x => x.AmountPaid);

	}
}
