using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using NFTB.API.Models;
using NFTB.API.Security;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Exceptions;
using NFTB.Dep;
using Login = System.Web.UI.WebControls.Login;

namespace NFTB.API.Controllers
{
    public class AccountController : Basecontroller
    {
        [HttpGet]
        public LoginSummary TestLogin()
        {
            var personMgr = Dependency.Resolve<IPersonManager>();
            return personMgr.GetTestLogin();
        }

        [HttpPost]
        public Token SignIn(LoginSummary loginDetails)
        {
            var accountMgr = Dependency.Resolve<IAccountManager>();
            //var tokenRequest = new
            //{
            //    username = loginDetails.Username,
            //    password = loginDetails.Password,
            //    grant_type = "password"
            //};
            var tokenRequest = new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", "fromparam"),
                new KeyValuePair<string, string>("password", "jj"),
            };
            //var json = JsonConvert.SerializeObject(tokenRequest);
            //HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpContent httpContent = new FormUrlEncodedContent(tokenRequest);
            HttpClient client = new HttpClient();
            var test = Task.Run(async() => await client.PostAsync("http://api.nftb.local/token", httpContent));
            //var result = client.PostAsync("http://api.nftb.local/token", httpContent);
            var resultString = test.Result.Content.ReadAsStringAsync();
            // Deserialize the string into the object it's sending back
            dynamic tokenResult = JsonConvert.DeserializeObject(resultString.Result);
            int expiry = tokenResult.expires_in ?? 0;
            var result = new Token
            {
                AccessToken = tokenResult.access_token,
                TokenType = tokenResult.token_type,
            };
            result.WhenTokenExpires = DateTime.Now.AddSeconds(expiry);
            return result;
        }

        [HttpPost]
        public void Register(RegistrationSummary registration)
        {
            if (registration.Password != registration.ConfirmPassword) throw new UserException("The confirm password field does not match the password field");
            var personMgr = Dependency.Resolve<IPersonManager>();
            var accountMgr = Dependency.Resolve<IAccountManager>();
            accountMgr.SaveCredentials(registration.Username, registration.Password);

        }



    }
}