using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
	public partial class Person
	{
		public string DisplayName
		{
			get { return (this.FirstName + " " + this.LastName).Trim(); }
		}
	}
}
