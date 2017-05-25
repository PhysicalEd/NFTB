using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class TermSummary
	{
        public int TermID { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime? TermEnd { get; set; }
        public int BondAmount { get; set; }
        public int CasualRate { get; set; }
        public bool IncludeOrganizer { get; set; }
	    public int NumberOfPlayers { get; set; }
	}
}
