using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using BlackBallArchitecture.Contracts.Cache;
using BlackBallArchitecture.Contracts.DataManagers;
using BlackBallArchitecture.Contracts.Entities.Data;
using BlackBallArchitecture.Contracts.Repositories;
using BlackBallArchitecture.Logic.DataManagers;
using BlackBallArchitecture.Test.Fakes;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackBallArchitecture.Test
{
	/// <summary>
	/// </summary>
	[TestClass]
	public class PersonTests
	{
		public PersonTests()
		{
			// Load stub data into the IRepository container so that we don't have database dependence for this unit test
			IUnityContainer container = new UnityContainer();
			container.RegisterType<IRepositoryInitializer, ValidStubDataInitializer>();
			container.RegisterType<IPersistentStorage, StoreDatabaseContextInMemoryForUnitTests>();
			container.RegisterType<ICacheManager, NoCache>();
			container.RegisterType<IPersonManager, PersonManager>();
			Dependency.Container = container;
			ResetData();
		}
		#region Additional test attributes

		/// <summary>
		/// Resets the data in the data store
		/// </summary>
		private void ResetData()
		{
			// Add fake data to our in-memory context, allowing us to query it later
			Dependency.Resolve<IPersistentStorage>().Clear();
			var cxt = Dependency.Resolve<IRepositoryInitializer>().Create();
			cxt.Person.AddObject(new Person { FirstName = "Larry", LastName = "Phillips", PersonID = 1 });
			cxt.Person.AddObject(new Person { FirstName = "Bob", LastName = "Dangermuffin", PersonID = 2 });
			cxt.SubmitChanges();
		}

		#endregion

		[TestMethod]
		public void GetPersonByID_Success()
		{
			var personMgr = Dependency.Resolve<IPersonManager>();
			var person = personMgr.GetPerson(1).FirstOrDefault();
			Assert.IsNotNull(person);
			Assert.AreEqual(person.FirstName, "Larry");
		}

		[TestMethod]
		public void GetAllPeople()
		{
			var personMgr = Dependency.Resolve<IPersonManager>();
			var person = personMgr.GetPerson(null);
			Assert.IsNotNull(person);
			Assert.AreEqual(2, person.Count());
		}
	}
}
