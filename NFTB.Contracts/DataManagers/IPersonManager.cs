using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;

namespace NFTB.Contracts.DataManagers
{
	public partial interface IPersonManager
	{
		/// <summary>
		/// Saves this person to the data store
		/// </summary>
		Person SavePerson(int? personID, string email, string firstName, string lastName, string postalAddress, string phone);

		PersonList GetPerson(int? personID);
	}
}
