using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.DataManagers
{
	public partial interface ISystemLogManager
	{

		/// <summary>
		/// Logs this message to the data store
		/// </summary>
		/// <param name="log"></param>
		void SaveLog(Entities.Data.SystemLog log);
	}
}
