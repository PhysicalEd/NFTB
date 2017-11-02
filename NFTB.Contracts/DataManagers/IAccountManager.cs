using System.Linq;
using System.Text;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;

namespace NFTB.Contracts.DataManagers
{
    public partial interface IAccountManager
    {
        void SaveCredentials(string username, string password);
        LoginSummary SignIn(string username, string password);


    }
}
