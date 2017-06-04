using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class CasualPlayerSummary
	{
        public int CasualPlayerID { get; set; }
        public bool HasPaid { get; set; }
        public int TermID { get; set; }
    }
}
