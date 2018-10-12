using System;
using System.Linq;
using System.Text;
using NFTB.Common.Extensions;
using NFTB.Contracts;
using NFTB.Contracts.Cache;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;
using NFTB.Contracts.Enums;
using NFTB.Dep;


namespace NFTB.Logic.DataManagers
{
	public partial class PersonManager : IPersonManager
	{
		/// <summary>
		/// Saves this person to the data store
		/// </summary>
		public Person SavePerson(int? personID, string firstName, string lastName, string phone, string email, bool isDeleted)
		{
			// Validate
			email = email ?? "";
			Dependency.Resolve<NFTB.Contracts.Validators.IEmailFormatValidator>().Validate(email);

			// Now load new one for updates
			using (var cxt = DataStore.GetDataStore())
			{
				var data = cxt.GetOrCreatePerson(personID);
				data.FirstName = firstName;
				data.LastName = lastName;
				data.Phone = phone;
                data.Email = email.ToLower().Trim();
                cxt.SubmitChanges();

				// Log this update
				return data;
			}
		}

		/// <summary>
		/// Returns the person matching this ID
		/// </summary>
		/// <param name="personID"></param>
		/// <returns></returns>
		public PersonList GetPerson(int? personID)
		{
			personID = personID.GetValueOrDefault(0);

			using (var cxt = DataStore.GetDataStore())
			{
				var data = (
								from person in cxt.Person
								where (person.PersonID == personID || personID == 0)
								select person
							   ).ToList();

				data = data.ToList();
			}
			// Run through cache
			Func<string, PersonList> func = delegate(string cacheKey)
			{
				var result = new PersonList();
				using (var cxt = DataStore.GetDataStore())
				{
					var data = (
					           	from person in cxt.Person
					           	where (person.PersonID == personID || personID == 0)
					           	select person
					           ).ToList();
					result.AddRange(data);
				}
				result.CacheKey = cacheKey;
				if (personID > 0) result.AddTag(CacheTags.Person, personID);
				return result;
			};

			var cache = Dependency.Resolve<ICacheManager>();
			var key = new PersonList() { CacheKey = "person_" + personID.ToString() };
			var list = cache.Load(key, func);
			return list;
		}

        //public void DeletePerson(int personID)
        //{
        //       using (var cxt = DataStore.GetDataStore())
        //       {
        //           var player = (from p in cxt.Person
        //                         where p.PersonID == personID
        //                         select p
        //               ).FirstOrDefault();
        //           if (player == null) return;
        //           player.IsDeleted = true;
        //           cxt.SubmitChanges();
	    //       }
	    //   }

	    public LoginSummary GetTestLogin()
	    {
	        using (var cxt = DataStore.GetDataStore())
	        {
	            var data = (
	                from l in cxt.Login
	                join p in cxt.Person on l.LoginID equals p.LoginID
	                select new LoginSummary()
	                {
	                    FirstName = p.FirstName,
	                    LastName = p.LastName,
	                    LoginID = l.LoginID,
	                    Username = l.Username,
	                    Password = l.Password
	                }
                ).FirstOrDefault();
	            return data;
	        }
        }

	    public LoginSummary SignIn(string username, string password)
	    {
	        using (var cxt = DataStore.GetDataStore())
	        {
	            var data = (
                    from l in cxt.Login
                    join p in cxt.Person on l.LoginID equals p.LoginID
                    where l.Username == username
                    && l.Password == password
                    select new LoginSummary()
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        LoginID = l.LoginID
                    }
                ).FirstOrDefault();
	            return data;
	        }
	    }

        //private 
    }
}
