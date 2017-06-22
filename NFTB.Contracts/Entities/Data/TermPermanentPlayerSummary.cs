using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class TermPermanentPlayerSummary
	{
        public int TermPermanentPlayerID { get; set; }
        public int TermID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlayerName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); } }
        public int BondPaid { get; set; }
        public int TermDue { get; set; }
        public int TermOwing { get; set; }
    }
}
