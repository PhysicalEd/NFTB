using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;

namespace NFTB.Contracts.Security
{
	public interface ICurrentUser
	{
		int? PersonID { get; }
		bool IsAuthenticated { get; }

		string UserSessionIdentifier { get; }
		string DisplayName { get; }
	}
}
