using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class TermSummary
	{
        public int TermID { get; set; }
        public string TermName { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime? TermEnd { get; set; }
        public int BondAmount { get; set; }
        public int CasualRate { get; set; }
        public bool IncludeOrganizer { get; set; }
	    public int NumberOfPlayers { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsInvoiced { get; set; }
	    public string TermStartDescription => this.TermStart.ToString("MMMM d yyyy");
	    public string TermEndDescription => TermEnd?.ToString("MMMM d yyyy") ?? "";
	    public string TermRangeDescription => string.Format("{0} - {1}", this.TermStartDescription, this.TermEndDescription);





    }
}
