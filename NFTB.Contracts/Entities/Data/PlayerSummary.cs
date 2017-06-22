using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class PlayerSummary
	{
        public int PlayerID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlayerName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); } }
    }
}
