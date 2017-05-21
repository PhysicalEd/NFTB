using BlackBallArchitecture.Contracts.Repositories;
using BlackBallArchitecture.Data.EF.Fake;

namespace BlackBallArchitecture.Test.Fakes
{
	/// <summary>
	/// Stub data with valid entity details in it, designed for use in test classes
	/// </summary>
	public class ValidStubDataInitializer : IRepositoryInitializer
	{
		/// <summary>
		/// Opens a new fake data repository
		/// </summary>
		/// <returns></returns>
		public IRepository Create()
		{
			var fake = FakeData.FromCache();
			if (fake == null) fake = new FakeData();
			return fake;
		}

		/// <summary>
		/// Opens a new fake data repository
		/// </summary>
		/// <param name="callerDescription"></param>
		/// <returns></returns>
		public IRepository Create(string callerDescription)
		{
			return this.Create();
		}
	}
}
