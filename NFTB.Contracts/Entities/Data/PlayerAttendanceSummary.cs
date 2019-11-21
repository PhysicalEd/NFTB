using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class AttendanceSummary
	{
	    public int AttendanceID { get; set; }
        public int SessionID { get; set; }
        public int? TermID { get; set; }
        public int PlayerID { get; set; }
        public bool IsCasual { get; set; }
        public decimal AmountPaid { get; set; }
        public bool HasAttended { get; set; }

        // Player details
	    public string FirstName { get; set; } = "";
	    public string LastName { get; set; } = "";
        public string DisplayName {
            get { return this.FirstName + " "+this.LastName; }
        }
        

    }
}
