using System;
using System.Linq;
using System.Text;
using NFTB.Common.Extensions;
using NFTB.Contracts;
using NFTB.Contracts.Cache;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;
using NFTB.Contracts.Enums;


namespace NFTB.Logic.DataManagers
{
	public partial class PersonManager : IPersonManager
	{
		/// <summary>
		/// Saves this person to the data store
		/// </summary>
		public Person SavePerson(int? personID, string email, string firstName, string lastName, string postalAddress, string phone)
		{
			// Validate
			email = email ?? "";
			Dependency.Resolve<NFTB.Contracts.Validators.IEmailFormatValidator>().Validate(email);

			// Clear cache
			if (personID.HasValue) Dependency.Resolve<ICacheManager>().ClearTag(CacheTags.Person, personID);

			// Now load new one for updates
			using (var cxt = DataStore.CreateBlackBallArchitectureContext())
			{
				var data = cxt.GetOrCreatePerson(personID);
				if (data.IsNew) //data.WhenCreated = DateTime.Now;
				data.Email = email.ToLower().Trim();
				data.FirstName = firstName;
				data.LastName = lastName;
				//data.PostalAddress = postalAddress;
				data.Phone = phone;
				cxt.SubmitChanges();

				// Log this update
				Dependency.Resolve<ILogger>().Log(firstName + " record updated");

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

			using (var cxt = DataStore.CreateBlackBallArchitectureContext())
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
				using (var cxt = DataStore.CreateBlackBallArchitectureContext())
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

	}
}
