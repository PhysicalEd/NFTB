using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.EntityClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NFTB.Contracts.Repositories;
using NFTB.Contracts.Entities;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Repositories;
using NFTB.Contracts.Entities.Data;

namespace NFTB.Data.EF.Database
{
	/// <summary>
	/// </summary>
	public partial class CodeFirstModel : DbContext, IRepository
	{

		private DateTime StartTime;

		public string ApplicationName = "";

		protected override void Dispose(bool disposing)
		{
			

			base.Dispose(disposing);
		}

		public CodeFirstModel(string connectionString)
			: base(connectionString)
		{
			
		}


		public int CommandTimeout
		{
			set { this.Core.CommandTimeout = value; }
		}

		private ObjectContext Core
		{
			get { return (this as IObjectContextAdapter).ObjectContext; }

		}

		public IEnumerable<RETURNTYPE> ExecuteStoreQuery<RETURNTYPE>(string commandText, object[] parameters)
		{
			return this.Core.ExecuteStoreQuery<RETURNTYPE>(commandText, parameters);
		}

		public void ExecuteStoreCommand(string commandText, object[] parameters)
		{
			this.Core.ExecuteStoreCommand(commandText, parameters);

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			LoadTables(modelBuilder);

			
		}

		/// <summary>
		/// Saves the changes back to the data store
		/// </summary>
		public void SubmitChanges()
		{
			this.SaveChanges();
		}


	}
}


