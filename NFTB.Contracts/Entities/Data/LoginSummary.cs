using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public class LoginSummary
	{
        public int LoginID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
