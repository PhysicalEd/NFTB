using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class AttendanceSummary
	{
        public int AttendanceID { get; set; }
        public int TermID { get; set; }
        public string TermName { get; set; }
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; }
        public int TotalPlayersAttended => this.PlayerAttendances.Count();
        public int CasualsAttended =>this.PlayerAttendances.Count(x => x.IsCasual);
	    public int TermPlayersAttended => this.PlayerAttendances.Count(x => !x.IsCasual);
        public DateTime AttendanceDate { get; set; }

    }
}
