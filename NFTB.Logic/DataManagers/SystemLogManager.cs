using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Repositories;


namespace NFTB.Logic.DataManagers
{
	public partial class SystemLogManager
	{

		/// <summary>
		/// Saves this item to our logging system
		/// </summary>
		/// <param name="log"></param>
		public void SaveLog(Contracts.Entities.Data.SystemLog log)
		{
			using (var cxt = DataStore.CreateBlackBallArchitectureContext())
			{
				var data = cxt.GetOrCreateSystemLog(log.SystemLogID);
				data.Details = log.Details;
				data.Message = log.Message;
				data.PersonID = log.PersonID;
				data.SystemLogTypeID = log.SystemLogTypeID;
				data.WhenOccurred = log.WhenOccurred;
				cxt.SubmitChanges();
				log.SystemLogID = data.SystemLogID;
			}
		}

	}
}
