using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Exceptions
{
	public class EmailFormatException : UserException
	{
		public EmailFormatException() : base("Your email is not a valid format") { }
	}
}