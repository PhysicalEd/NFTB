using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using NFTB.Contracts.Entities.Data;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 28 Jun 2019 
namespace NFTB.Data.EF.Fake {

	/// <summary>
    /// Creates lists of the various data-bound entities, which can later be injected into test routines etc - bypassing any database dependencies
    /// </summary>
    public partial class FakeData
    {

		private void CreateIdentityvalues()
		{
			this.Attendance.Where(x => x.AttendanceID == 0).ToList().ForEach(x => x.AttendanceID = this.Attendance.Max(y => y.AttendanceID) + 1);
			this.Invoice.Where(x => x.InvoiceID == 0).ToList().ForEach(x => x.InvoiceID = this.Invoice.Max(y => y.InvoiceID) + 1);
			this.Login.Where(x => x.LoginID == 0).ToList().ForEach(x => x.LoginID = this.Login.Max(y => y.LoginID) + 1);
			this.Person.Where(x => x.PersonID == 0).ToList().ForEach(x => x.PersonID = this.Person.Max(y => y.PersonID) + 1);
			this.Player.Where(x => x.PlayerID == 0).ToList().ForEach(x => x.PlayerID = this.Player.Max(y => y.PlayerID) + 1);
			this.Session.Where(x => x.SessionID == 0).ToList().ForEach(x => x.SessionID = this.Session.Max(y => y.SessionID) + 1);
			this.SystemLog.Where(x => x.SystemLogID == 0).ToList().ForEach(x => x.SystemLogID = this.SystemLog.Max(y => y.SystemLogID) + 1);
			this.Term.Where(x => x.TermID == 0).ToList().ForEach(x => x.TermID = this.Term.Max(y => y.TermID) + 1);
			this.TermPlayer.Where(x => x.TermPlayerID == 0).ToList().ForEach(x => x.TermPlayerID = this.TermPlayer.Max(y => y.TermPlayerID) + 1);
		}
    
		public Attendance GetOrCreateAttendance(int? AttendanceID) {
            Attendance item = this.Attendance.FirstOrDefault(x => x.AttendanceID == AttendanceID);
			if (item == null){
				item = new Attendance();
				this.Attendance.AddObject(item);
			}
			return item;
        }

		private IObjectSet<Attendance> _Attendance = null;
        public IObjectSet<Attendance> Attendance {
            get {
                if (_Attendance == null) {
                    var result = new List<Attendance>();
                    _Attendance = new FakeObjectSet<Attendance>(result);
                }
                return _Attendance;
            }
        }
	
		public Invoice GetOrCreateInvoice(int? InvoiceID) {
            Invoice item = this.Invoice.FirstOrDefault(x => x.InvoiceID == InvoiceID);
			if (item == null){
				item = new Invoice();
				this.Invoice.AddObject(item);
			}
			return item;
        }

		private IObjectSet<Invoice> _Invoice = null;
        public IObjectSet<Invoice> Invoice {
            get {
                if (_Invoice == null) {
                    var result = new List<Invoice>();
                    _Invoice = new FakeObjectSet<Invoice>(result);
                }
                return _Invoice;
            }
        }
	
		public Login GetOrCreateLogin(int? LoginID) {
            Login item = this.Login.FirstOrDefault(x => x.LoginID == LoginID);
			if (item == null){
				item = new Login();
				this.Login.AddObject(item);
			}
			return item;
        }

		private IObjectSet<Login> _Login = null;
        public IObjectSet<Login> Login {
            get {
                if (_Login == null) {
                    var result = new List<Login>();
                    _Login = new FakeObjectSet<Login>(result);
                }
                return _Login;
            }
        }
	
		public Person GetOrCreatePerson(int? PersonID) {
            Person item = this.Person.FirstOrDefault(x => x.PersonID == PersonID);
			if (item == null){
				item = new Person();
				this.Person.AddObject(item);
			}
			return item;
        }

		private IObjectSet<Person> _Person = null;
        public IObjectSet<Person> Person {
            get {
                if (_Person == null) {
                    var result = new List<Person>();
                    _Person = new FakeObjectSet<Person>(result);
                }
                return _Person;
            }
        }
	
		public Player GetOrCreatePlayer(int? PlayerID) {
            Player item = this.Player.FirstOrDefault(x => x.PlayerID == PlayerID);
			if (item == null){
				item = new Player();
				this.Player.AddObject(item);
			}
			return item;
        }

		private IObjectSet<Player> _Player = null;
        public IObjectSet<Player> Player {
            get {
                if (_Player == null) {
                    var result = new List<Player>();
                    _Player = new FakeObjectSet<Player>(result);
                }
                return _Player;
            }
        }
	
		public Session GetOrCreateSession(int? SessionID) {
            Session item = this.Session.FirstOrDefault(x => x.SessionID == SessionID);
			if (item == null){
				item = new Session();
				this.Session.AddObject(item);
			}
			return item;
        }

		private IObjectSet<Session> _Session = null;
        public IObjectSet<Session> Session {
            get {
                if (_Session == null) {
                    var result = new List<Session>();
                    _Session = new FakeObjectSet<Session>(result);
                }
                return _Session;
            }
        }
	
		public SystemLog GetOrCreateSystemLog(int? SystemLogID) {
            SystemLog item = this.SystemLog.FirstOrDefault(x => x.SystemLogID == SystemLogID);
			if (item == null){
				item = new SystemLog();
				this.SystemLog.AddObject(item);
			}
			return item;
        }

		private IObjectSet<SystemLog> _SystemLog = null;
        public IObjectSet<SystemLog> SystemLog {
            get {
                if (_SystemLog == null) {
                    var result = new List<SystemLog>();
                    _SystemLog = new FakeObjectSet<SystemLog>(result);
                }
                return _SystemLog;
            }
        }
	
		public Term GetOrCreateTerm(int? TermID) {
            Term item = this.Term.FirstOrDefault(x => x.TermID == TermID);
			if (item == null){
				item = new Term();
				this.Term.AddObject(item);
			}
			return item;
        }

		private IObjectSet<Term> _Term = null;
        public IObjectSet<Term> Term {
            get {
                if (_Term == null) {
                    var result = new List<Term>();
                    _Term = new FakeObjectSet<Term>(result);
                }
                return _Term;
            }
        }
	
		public TermPlayer GetOrCreateTermPlayer(int? TermPlayerID) {
            TermPlayer item = this.TermPlayer.FirstOrDefault(x => x.TermPlayerID == TermPlayerID);
			if (item == null){
				item = new TermPlayer();
				this.TermPlayer.AddObject(item);
			}
			return item;
        }

		private IObjectSet<TermPlayer> _TermPlayer = null;
        public IObjectSet<TermPlayer> TermPlayer {
            get {
                if (_TermPlayer == null) {
                    var result = new List<TermPlayer>();
                    _TermPlayer = new FakeObjectSet<TermPlayer>(result);
                }
                return _TermPlayer;
            }
        }
	
	}
}
