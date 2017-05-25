using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Repositories
{
	/// <summary>
	/// 
	/// </summary>
	public partial interface IRepository : IDisposable
	{
		int SaveChanges();
		void SubmitChanges();
	}
}
