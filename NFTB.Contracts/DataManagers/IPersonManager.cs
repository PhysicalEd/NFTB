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
        Person SavePerson(int? personID, string firstName, string lastName, string phone, string email, bool isDeleted);

        PersonList GetPerson(int? personID);
        LoginSummary GetTestLogin();
        LoginSummary SignIn(string username, string password);


    }
}
