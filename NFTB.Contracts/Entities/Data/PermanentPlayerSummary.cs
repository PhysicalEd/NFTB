using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class PermanentPlayerSummary
	{
        public int TermPlayerID { get; set; }
        public int TermID { get; set; }
        public int BondPaid { get; set; }
        public int TermDue { get; set; }
        public int TermOwing { get; set; }
    }
}
