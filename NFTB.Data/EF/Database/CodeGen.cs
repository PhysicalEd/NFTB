using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using NFTB.Contracts.Entities.Data;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 8 Oct 2018 
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
			modelBuilder.Entity<Attendance>().Property(x => x.AttendanceDate);
			modelBuilder.Entity<Attendance>().Property(x => x.IsDisabled);
		
			// Invoice
			modelBuilder.Entity<Invoice>().HasKey(x => x.InvoiceID);
			modelBuilder.Entity<Invoice>().ToTable("Invoice");
			modelBuilder.Entity<Invoice>().Property(x => x.InvoiceID);
			modelBuilder.Entity<Invoice>().Property(x => x.TermID);
			modelBuilder.Entity<Invoice>().Property(x => x.InvoiceDate);
			modelBuilder.Entity<Invoice>().Property(x => x.TotalAmount);
			modelBuilder.Entity<Invoice>().Property(x => x.WhenPaid);
			modelBuilder.Entity<Invoice>().Property(x => x.NumberOfSessions);
		
			// Login
			modelBuilder.Entity<Login>().HasKey(x => x.LoginID);
			modelBuilder.Entity<Login>().ToTable("Login");
			modelBuilder.Entity<Login>().Property(x => x.LoginID);
			modelBuilder.Entity<Login>().Property(x => x.Username);
			modelBuilder.Entity<Login>().Property(x => x.Password);
			modelBuilder.Entity<Login>().Property(x => x.PersonID);
			modelBuilder.Entity<Login>().Property(x => x.IsVerified);
		
			// Person
			modelBuilder.Entity<Person>().HasKey(x => x.PersonID);
			modelBuilder.Entity<Person>().ToTable("Person");
			modelBuilder.Entity<Person>().Property(x => x.PersonID);
			modelBuilder.Entity<Person>().Property(x => x.FirstName);
			modelBuilder.Entity<Person>().Property(x => x.LastName);
			modelBuilder.Entity<Person>().Property(x => x.Phone);
			modelBuilder.Entity<Person>().Property(x => x.Email);
			modelBuilder.Entity<Person>().Property(x => x.LoginID);
		
			// Player
			modelBuilder.Entity<Player>().HasKey(x => x.PlayerID);
			modelBuilder.Entity<Player>().ToTable("Player");
			modelBuilder.Entity<Player>().Property(x => x.PlayerID);
			modelBuilder.Entity<Player>().Property(x => x.PersonID);
			modelBuilder.Entity<Player>().Property(x => x.IsDeleted);
		
			// PlayerAttendance
			modelBuilder.Entity<PlayerAttendance>().HasKey(x => x.PlayerAttendanceID);
			modelBuilder.Entity<PlayerAttendance>().ToTable("PlayerAttendance");
			modelBuilder.Entity<PlayerAttendance>().Property(x => x.PlayerAttendanceID);
			modelBuilder.Entity<PlayerAttendance>().Property(x => x.AttendanceID);
			modelBuilder.Entity<PlayerAttendance>().Property(x => x.PlayerID);
			modelBuilder.Entity<PlayerAttendance>().Property(x => x.AmountPaid);
		
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
			modelBuilder.Entity<Term>().Property(x => x.IsActive);
		
			// TermPlayer
			modelBuilder.Entity<TermPlayer>().HasKey(x => x.TermPlayerID);
			modelBuilder.Entity<TermPlayer>().ToTable("TermPlayer");
			modelBuilder.Entity<TermPlayer>().Property(x => x.TermPlayerID);
			modelBuilder.Entity<TermPlayer>().Property(x => x.TermID);
			modelBuilder.Entity<TermPlayer>().Property(x => x.PlayerID);
			modelBuilder.Entity<TermPlayer>().Property(x => x.BondPaid);
			modelBuilder.Entity<TermPlayer>().Property(x => x.TermDue);
			modelBuilder.Entity<TermPlayer>().Property(x => x.TermOwing);
		
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
	

        public Invoice GetOrCreateInvoice(int? InvoiceID) {
            if (InvoiceID.GetValueOrDefault(0) > 0) return this.Invoice.FirstOrDefault(x => x.InvoiceID == InvoiceID);
            var newItem = new Invoice();
			this.Invoice.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.Invoice> Invoice        {
            get { 
				return Core.CreateObjectSet<Invoice>();
				// var set = Core.CreateObjectSet<Invoice>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	

        public Login GetOrCreateLogin(int? LoginID) {
            if (LoginID.GetValueOrDefault(0) > 0) return this.Login.FirstOrDefault(x => x.LoginID == LoginID);
            var newItem = new Login();
			this.Login.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.Login> Login        {
            get { 
				return Core.CreateObjectSet<Login>();
				// var set = Core.CreateObjectSet<Login>();
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
	

        public PlayerAttendance GetOrCreatePlayerAttendance(int? PlayerAttendanceID) {
            if (PlayerAttendanceID.GetValueOrDefault(0) > 0) return this.PlayerAttendance.FirstOrDefault(x => x.PlayerAttendanceID == PlayerAttendanceID);
            var newItem = new PlayerAttendance();
			this.PlayerAttendance.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.PlayerAttendance> PlayerAttendance        {
            get { 
				return Core.CreateObjectSet<PlayerAttendance>();
				// var set = Core.CreateObjectSet<PlayerAttendance>();
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
	

        public TermPlayer GetOrCreateTermPlayer(int? TermPlayerID) {
            if (TermPlayerID.GetValueOrDefault(0) > 0) return this.TermPlayer.FirstOrDefault(x => x.TermPlayerID == TermPlayerID);
            var newItem = new TermPlayer();
			this.TermPlayer.AddObject(newItem);
            return newItem;
        }

		public IObjectSet<NFTB.Contracts.Entities.Data.TermPlayer> TermPlayer        {
            get { 
				return Core.CreateObjectSet<TermPlayer>();
				// var set = Core.CreateObjectSet<TermPlayer>();
	            // set.MergeOption = MergeOption.NoTracking;
	            // return set;
			}
        }
	
	}
}
