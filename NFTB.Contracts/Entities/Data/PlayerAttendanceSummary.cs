using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class PlayerAttendanceSummary
	{
	    public int PlayerAttendanceID { get; set; }
        public int AttendanceID { get; set; }
        public int PlayerID { get; set; }
        public bool IsCasual { get; set; }
        public int? AmountPaid { get; set; }

        // Player details
        public string PlayerName { get; set; }

    }
}
