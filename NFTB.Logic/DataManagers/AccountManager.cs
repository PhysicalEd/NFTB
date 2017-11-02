using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using DevOne.Security.Cryptography.BCrypt;
using NFTB.Common.Extensions;
using NFTB.Contracts;
using NFTB.Contracts.Cache;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;
using NFTB.Contracts.Enums;


namespace NFTB.Logic.DataManagers
{
	public partial class AccountManager : IAccountManager
	{
		/// <summary>
		/// Saves credentials of given username and password
		/// </summary>
		public void SaveCredentials(string username, string password)
		{
		    using (var cxt = DataStore.CreateBlackBallArchitectureContext())
			{
                // Load the login details if exists
			    //var login = cxt.Login.FirstOrDefault(x => x.Username.ToLower() == username);
				var login = cxt.GetOrCreateLogin(null);
			    var salt = BCryptHelper.GenerateSalt();
				login.Username = username;
			    var test = BCryptHelper.HashPassword(password, salt);
				login.Password = test;
			    // EO TODO
                login.PersonID = 1;
                cxt.SubmitChanges();
			}
		}

	    public LoginSummary SignIn(string username, string password)
	    {
	        using (var cxt = DataStore.CreateBlackBallArchitectureContext())
	        {
	            // Load the login details if exists
	            //var login = cxt.Login.FirstOrDefault(x => x.Username.ToLower() == username);
                var login = (
                    from l in cxt.Login
                    join p in cxt.Person on l.PersonID equals p.PersonID
                    where l.Username == username
                    select new LoginSummary()
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        LoginID = l.LoginID,
                        Password = l.Password,
                        Username = l.Username
                    }    
                ).FirstOrDefault();
	            var passwordVerified = BCryptHelper.CheckPassword(password, login?.Password);
                if (!passwordVerified) throw new Exception("We either could not find your username or the password you entered is incorrect.");
	            return login;
	        }
	    }

        //public LoginSummary Register(string username, string password)
        //{
        //    // Validate
        //    username = username ?? "";
        //    Dependency.Resolve<NFTB.Contracts.Validators.IEmailFormatValidator>().Validate(username);

        //    username = username.ToLower();

        //    using (var cxt = DataStore.CreateBlackBallArchitectureContext())
        //    {
        //        // Load the login details if exists
        //        var login = cxt.Login.FirstOrDefault(x => x.Username.ToLower() == username);
        //        login = cxt.GetOrCreateLogin(login?.LoginID);
        //        var salt = BCryptHelper.GenerateSalt();
        //        login.Username = username;
        //        login.Password = BCryptHelper.HashPassword(password, salt);
        //        login.PasswordSalt = salt;
        //        cxt.SubmitChanges();
        //    }
        //   }
        //private 
    }
}
