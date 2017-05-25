using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Enums;
using NFTB.Contracts.Security;

namespace NFTB.Logic
{
	public class NoLogger : NFTB.Contracts.ILogger
	{
		public int Log(string message)
		{
			return 0;
		}

		public int Log(Exception ex)
		{
			return 0;
		}

		public int Log(Exception ex, string description)
		{
			return 0;
		}

		public int Log(string message, SystemLogTypes type)
		{
			return 0;
		}

		public List<SystemLog> GetLog(SystemLogTypes type, DateTime fromDate, DateTime toDate)
		{
			return new List<SystemLog>();

			
		}
	}
}
