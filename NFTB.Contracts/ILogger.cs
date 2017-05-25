using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Enums;

namespace NFTB.Contracts
{
	public interface ILogger
	{
		int Log(string message);
		int Log(Exception ex);
		int Log(Exception ex, string description);

		/// <summary>
		/// Logs the given message
		/// </summary>
		/// <param name="log"></param>
		/// <param name="type"></param>
		int Log(string message, SystemLogTypes type);

		/// <summary>
		/// Returns log messages matching the given filter
		/// </summary>
		/// <param name="type"></param>
		/// <param name="fromDate"></param>
		/// <param name="?"></param>
		/// <param name="?"></param>
		/// <param name="toDate"></param>
		/// <returns></returns>
		List<SystemLog> GetLog(SystemLogTypes type, DateTime fromDate, DateTime toDate);
	}
}
