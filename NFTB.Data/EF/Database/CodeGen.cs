using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using NFTB.Contracts.Entities.Data;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 10 Jun 2017 
namespace NFTB.Data.EF.Database {

	/// <summary>
    /// Creates lists of the various data-bound entities, which can later be injected into test routines etc - bypassing any database dependencies
    /// </summary>
    public partial class CodeFirstModel
    {

		private void LoadTables(DbModelBuilder modelBuilder)
		{

			// Attendance
			modelBuilder.Entity<Attendance>().HasKey(x => x.AttendanceID);
			modelBuilder.Entity<Attendance>().ToTable("Attendance");
			modelBuilder.Entity<Attendance>().Property(x => x.AttendanceID);
			modelBuilder.Entity<Attendance>().Property(x => x.TermID);
			modelBuilder.Entity<Attendance>().Property(x => x.PlayerID);
			modelBuilder.Entity<Attendance>().Property(x => x.DateAttended);
		
			// Person
			modelBuilder.Entity<Person>().HasKey(x => x.PersonID);
			modelBuilder.Entity<Person>().ToTable("Person");
			modelBuilder.Entity<Person>().Property(x => x.PersonID);
			modelBuilder.Entity<Person>().Property(x => x.FirstName);
			modelBuilder.Entity<Person>().Property(x => x.LastName);
			modelBuilder.Entity<Person>().Property(x => x.Phone);
			modelBuilder.Entity<Person>().Property(x => x.Email);
		
			// Player
			modelBuilder.Entity<Player>().HasKey(x => x.PlayerID);
			modelBuilder.Entity<Player>().ToTable("Player");
			modelBuilder.Entity<Player>().Property(x => x.PlayerID);
			modelBuilder.Entity<Player>().Property(x => x.PersonID);
		
			// SystemLog
			modelBuilder.Entity<SystemLog>().HasKey(x => x.SystemLogID);
			modelBuilder.Entity<SystemLog>().ToTable("SystemLog");
			modelBuilder.Entity<SystemLog>().Property(x => x.SystemLogID);
			modelBuilder.Entity<SystemLog>().Property(x => x.PersonID);
			modelBuilder.Entity<SystemLog>().Property(x => x.WhenOccurred);
			modelBuilder.Entity<SystemLog>().Property(x => x.Message);
			modelBuilder.Entity<SystemLog>().Property(x => x.Details);
			modelBuilder.Entity<SystemLog>().Property(x => x.SystemLogTypeID);
		
			// Term
			modelBuilder.Entity<Term>().HasKey(x => x.TermID);
			modelBuilder.Entity<Term>().ToTable("Term");
			modelBuilder.Entity<Term>().Property(x => x.TermID);
			modelBuilder.Entity<Term>().Property(x => x.TermName);
			modelBuilder.Entity<Term>().Property(x => x.TermStart);
			modelBuilder.Entity<Term>().Property(x => x.TermEnd);
			modelBuilder.Entity<Term>().Property(x => x.BondAmount);
			modelBuilder.Entity<Term>().Property(x => x.CasualRate);
			modelBuilder.Entity<Term>().Property(x => x.IncludeOrganizer);
			modelBuilder.Entity<Term>().Property(x => x.IsDeleted);
		
			// TermCasualPlayer
			modelBuilder.Entity<TermCasualPlayer>().HasKey(x => x.TermCasualPlayerID);
			modelBuilder.Entity<TermCasualPlayer>().ToTable("TermCasualPlayer");
			modelBuilder.Entity<TermCasualPlayer>().Property(x => x.TermCasualPlayerID);
			modelBuilder.Entity<TermCasualPlayer>().Property(x => x.TermID);
			modelBuilder.Entity<TermCasualPlayer>().Property(x => x.PlayerID);
			modelBuilder.Entity<TermCasualPlayer>().Property(x => x.Paid);
		
			// TermPermanentPlayer
			modelBuilder.Entity<TermPermanentPlayer>().HasKey(x => x.TermPermanentPlayerID);
			modelBuilder.Entity<TermPermanentPlayer>().ToTable("TermPermanentPlayer");
			modelBuilder.Entity<TermPermanentPlayer>().Property(x => x.TermPermanentPlayerID);
			modelBuilder.Entity<TermPermanentPlayer>().Property(x => x.TermID);
			modelBuilder.Entity<TermPermanentPlayer>().Property(x => x.PlayerID);
			modelBuilder.Entity<TermPermanentPlayer>().Property(x => x.BondPaid);
			modelBuilder.Entity<TermPermanentPlayer>().Property(x => x.TermDue);
			modelBuilder.Entity<TermPermanentPlayer>().Property(x => x.TermOwing);
		
		}

        public Attendance GetOrCreateAttendance(int? AttendanceID) {
            if (AttendanceID.GetValueOrDefault(0) > 0) return this.Attendance.FirstOrDefault(x => x.AttendanceID == AttendanceID);
            var newItem = new Attendance();
			this.Attendance.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.Attendance> Attendance        {
            get { 
				return Core.CreateObjectSet<Attendance>();
				// var set = Core.CreateObjectSet<Attendance>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
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
	

        public Player GetOrCreatePlayer(int? PlayerID) {
            if (PlayerID.GetValueOrDefault(0) > 0) return this.Player.FirstOrDefault(x => x.PlayerID == PlayerID);
            var newItem = new Player();
			this.Player.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.Player> Player        {
            get { 
				return Core.CreateObjectSet<Player>();
				// var set = Core.CreateObjectSet<Player>();
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
	

        public TermCasualPlayer GetOrCreateTermCasualPlayer(int? TermCasualPlayerID) {
            if (TermCasualPlayerID.GetValueOrDefault(0) > 0) return this.TermCasualPlayer.FirstOrDefault(x => x.TermCasualPlayerID == TermCasualPlayerID);
            var newItem = new TermCasualPlayer();
			this.TermCasualPlayer.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.TermCasualPlayer> TermCasualPlayer        {
            get { 
				return Core.CreateObjectSet<TermCasualPlayer>();
				// var set = Core.CreateObjectSet<TermCasualPlayer>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	

        public TermPermanentPlayer GetOrCreateTermPermanentPlayer(int? TermPermanentPlayerID) {
            if (TermPermanentPlayerID.GetValueOrDefault(0) > 0) return this.TermPermanentPlayer.FirstOrDefault(x => x.TermPermanentPlayerID == TermPermanentPlayerID);
            var newItem = new TermPermanentPlayer();
			this.TermPermanentPlayer.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.TermPermanentPlayer> TermPermanentPlayer        {
            get { 
				return Core.CreateObjectSet<TermPermanentPlayer>();
				// var set = Core.CreateObjectSet<TermPermanentPlayer>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	
	}
}
