using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using NFTB.Contracts.Entities.Data;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 2 Jul 2017 
namespace NFTB.Data.EF.Fake {

	/// <summary>
    /// Creates lists of the various data-bound entities, which can later be injected into test routines etc - bypassing any database dependencies
    /// </summary>
    public partial class FakeData
    {

		private void CreateIdentityvalues()
		{
			this.Attendance.Where(x => x.AttendanceID == 0).ToList().ForEach(x => x.AttendanceID = this.Attendance.Max(y => y.AttendanceID) + 1);
			this.Person.Where(x => x.PersonID == 0).ToList().ForEach(x => x.PersonID = this.Person.Max(y => y.PersonID) + 1);
			this.Player.Where(x => x.PlayerID == 0).ToList().ForEach(x => x.PlayerID = this.Player.Max(y => y.PlayerID) + 1);
			this.PlayerAttendance.Where(x => x.PlayerAttendanceID == 0).ToList().ForEach(x => x.PlayerAttendanceID = this.PlayerAttendance.Max(y => y.PlayerAttendanceID) + 1);
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
	
		public PlayerAttendance GetOrCreatePlayerAttendance(int? PlayerAttendanceID) {
            PlayerAttendance item = this.PlayerAttendance.FirstOrDefault(x => x.PlayerAttendanceID == PlayerAttendanceID);
			if (item == null){
				item = new PlayerAttendance();
				this.PlayerAttendance.AddObject(item);
			}
			return item;
        }

		private IObjectSet<PlayerAttendance> _PlayerAttendance = null;
        public IObjectSet<PlayerAttendance> PlayerAttendance {
            get {
                if (_PlayerAttendance == null) {
                    var result = new List<PlayerAttendance>();
                    _PlayerAttendance = new FakeObjectSet<PlayerAttendance>(result);
                }
                return _PlayerAttendance;
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
