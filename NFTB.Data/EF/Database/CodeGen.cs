using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using NFTB.Contracts.Entities.Data;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 23 May 2017 
namespace NFTB.Data.EF.Database {

	/// <summary>
    /// Creates lists of the various data-bound entities, which can later be injected into test routines etc - bypassing any database dependencies
    /// </summary>
    public partial class CodeFirstModel
    {

		private void LoadTables(DbModelBuilder modelBuilder)
		{

			// Person
			modelBuilder.Entity<Person>().HasKey(x => x.PersonID);
			modelBuilder.Entity<Person>().ToTable("Person");
			modelBuilder.Entity<Person>().Property(x => x.PersonID);
			modelBuilder.Entity<Person>().Property(x => x.FirstName);
			modelBuilder.Entity<Person>().Property(x => x.LastName);
			modelBuilder.Entity<Person>().Property(x => x.Phone);
			modelBuilder.Entity<Person>().Property(x => x.Email);
		
			// SystemLog
			modelBuilder.Entity<SystemLog>().HasKey(x => x.SystemLogID);
			modelBuilder.Entity<SystemLog>().ToTable("SystemLog");
			modelBuilder.Entity<SystemLog>().Property(x => x.SystemLogID);
			modelBuilder.Entity<SystemLog>().Property(x => x.PersonID);
			modelBuilder.Entity<SystemLog>().Property(x => x.WhenOccurred);
			modelBuilder.Entity<SystemLog>().Property(x => x.Message);
			modelBuilder.Entity<SystemLog>().Property(x => x.Details);
			modelBuilder.Entity<SystemLog>().Property(x => x.SystemLogTypeID);
		
			// SystemLogg
			modelBuilder.Entity<SystemLogg>().HasKey(x => x.SystemLoggID);
			modelBuilder.Entity<SystemLogg>().ToTable("SystemLogg");
			modelBuilder.Entity<SystemLogg>().Property(x => x.SystemLoggID);
			modelBuilder.Entity<SystemLogg>().Property(x => x.PersonID);
			modelBuilder.Entity<SystemLogg>().Property(x => x.WhenOccurred);
			modelBuilder.Entity<SystemLogg>().Property(x => x.Message);
			modelBuilder.Entity<SystemLogg>().Property(x => x.Details);
			modelBuilder.Entity<SystemLogg>().Property(x => x.SystemLoggTypeID);
		
			// Term
			modelBuilder.Entity<Term>().HasKey(x => x.TermID);
			modelBuilder.Entity<Term>().ToTable("Term");
			modelBuilder.Entity<Term>().Property(x => x.TermID);
			modelBuilder.Entity<Term>().Property(x => x.TermStart);
			modelBuilder.Entity<Term>().Property(x => x.TermEnd);
			modelBuilder.Entity<Term>().Property(x => x.BondAmount);
			modelBuilder.Entity<Term>().Property(x => x.CasualRate);
			modelBuilder.Entity<Term>().Property(x => x.IncludeOrganizer);
		
			// TermCasual
			modelBuilder.Entity<TermCasual>().HasKey(x => x.TermCasualID);
			modelBuilder.Entity<TermCasual>().ToTable("TermCasual");
			modelBuilder.Entity<TermCasual>().Property(x => x.TermCasualID);
			modelBuilder.Entity<TermCasual>().Property(x => x.TermID);
			modelBuilder.Entity<TermCasual>().Property(x => x.PersonID);
			modelBuilder.Entity<TermCasual>().Property(x => x.Paid);
		
			// TermPermanent
			modelBuilder.Entity<TermPermanent>().HasKey(x => x.TermPermanentID);
			modelBuilder.Entity<TermPermanent>().ToTable("TermPermanent");
			modelBuilder.Entity<TermPermanent>().Property(x => x.TermPermanentID);
			modelBuilder.Entity<TermPermanent>().Property(x => x.TermID);
			modelBuilder.Entity<TermPermanent>().Property(x => x.PersonID);
			modelBuilder.Entity<TermPermanent>().Property(x => x.BondPaid);
			modelBuilder.Entity<TermPermanent>().Property(x => x.TermDue);
			modelBuilder.Entity<TermPermanent>().Property(x => x.TermOwing);
			modelBuilder.Entity<TermPermanent>().Property(x => x.Casual);
		
		}

        public Person GetOrCreatePerson(int? PersonID) {
            if (PersonID.GetValueOrDefault(0) > 0) return this.Person.FirstOrDefault(x => x.PersonID == PersonID);
            var newItem = new Person();
			this.Person.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.Person> Person        {
            get { 
				return Core.CreateObjectSet<Person>();
				// var set = Core.CreateObjectSet<Person>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	

        public SystemLog GetOrCreateSystemLog(int? SystemLogID) {
            if (SystemLogID.GetValueOrDefault(0) > 0) return this.SystemLog.FirstOrDefault(x => x.SystemLogID == SystemLogID);
            var newItem = new SystemLog();
			this.SystemLog.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.SystemLog> SystemLog        {
            get { 
				return Core.CreateObjectSet<SystemLog>();
				// var set = Core.CreateObjectSet<SystemLog>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	

        public SystemLogg GetOrCreateSystemLogg(int? SystemLoggID) {
            if (SystemLoggID.GetValueOrDefault(0) > 0) return this.SystemLogg.FirstOrDefault(x => x.SystemLoggID == SystemLoggID);
            var newItem = new SystemLogg();
			this.SystemLogg.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.SystemLogg> SystemLogg        {
            get { 
				return Core.CreateObjectSet<SystemLogg>();
				// var set = Core.CreateObjectSet<SystemLogg>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	

        public Term GetOrCreateTerm(int? TermID) {
            if (TermID.GetValueOrDefault(0) > 0) return this.Term.FirstOrDefault(x => x.TermID == TermID);
            var newItem = new Term();
			this.Term.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.Term> Term        {
            get { 
				return Core.CreateObjectSet<Term>();
				// var set = Core.CreateObjectSet<Term>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	

        public TermCasual GetOrCreateTermCasual(int? TermCasualID) {
            if (TermCasualID.GetValueOrDefault(0) > 0) return this.TermCasual.FirstOrDefault(x => x.TermCasualID == TermCasualID);
            var newItem = new TermCasual();
			this.TermCasual.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.TermCasual> TermCasual        {
            get { 
				return Core.CreateObjectSet<TermCasual>();
				// var set = Core.CreateObjectSet<TermCasual>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	

        public TermPermanent GetOrCreateTermPermanent(int? TermPermanentID) {
            if (TermPermanentID.GetValueOrDefault(0) > 0) return this.TermPermanent.FirstOrDefault(x => x.TermPermanentID == TermPermanentID);
            var newItem = new TermPermanent();
			this.TermPermanent.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.TermPermanent> TermPermanent        {
            get { 
				return Core.CreateObjectSet<TermPermanent>();
				// var set = Core.CreateObjectSet<TermPermanent>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	
	}
}
