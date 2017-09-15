using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public LoginSummary TestLogin()
        {
            var personMgr = Dependency.Resolve<IPersonManager>();
            return personMgr.GetTestLogin();
        }

        [HttpPost]
        public LoginSummary SignIn([FromBody] string username, string password)
        {
            var personMgr = Dependency.Resolve<IPersonManager>();
            return personMgr.SignIn(username, password);
        }


    }
}