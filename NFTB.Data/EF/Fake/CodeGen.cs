using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using NFTB.Contracts.Entities.Data;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 20 May 2017 
namespace NFTB.Data.EF.Fake {

	/// <summary>
    /// Creates lists of the various data-bound entities, which can later be injected into test routines etc - bypassing any database dependencies
    /// </summary>
    public partial class FakeData
    {

		private void CreateIdentityvalues()
		{
			this.Person.Where(x => x.PersonID == 0).ToList().ForEach(x => x.PersonID = this.Person.Max(y => y.PersonID) + 1);
			this.SystemLog.Where(x => x.SystemLogID == 0).ToList().ForEach(x => x.SystemLogID = this.SystemLog.Max(y => y.SystemLogID) + 1);
			this.SystemLogg.Where(x => x.SystemLoggID == 0).ToList().ForEach(x => x.SystemLoggID = this.SystemLogg.Max(y => y.SystemLoggID) + 1);
			this.Term.Where(x => x.TermID == 0).ToList().ForEach(x => x.TermID = this.Term.Max(y => y.TermID) + 1);
			this.TermCasual.Where(x => x.TermCasualID == 0).ToList().ForEach(x => x.TermCasualID = this.TermCasual.Max(y => y.TermCasualID) + 1);
			this.TermPlayer.Where(x => x.TermPlayerID == 0).ToList().ForEach(x => x.TermPlayerID = this.TermPlayer.Max(y => y.TermPlayerID) + 1);
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
	
		public SystemLogg GetOrCreateSystemLogg(int? SystemLoggID) {
            SystemLogg item = this.SystemLogg.FirstOrDefault(x => x.SystemLoggID == SystemLoggID);
			if (item == null){
				item = new SystemLogg();
				this.SystemLogg.AddObject(item);
			}
			return item;
        }

		private IObjectSet<SystemLogg> _SystemLogg = null;
        public IObjectSet<SystemLogg> SystemLogg {
            get {
                if (_SystemLogg == null) {
                    var result = new List<SystemLogg>();
                    _SystemLogg = new FakeObjectSet<SystemLogg>(result);
                }
                return _SystemLogg;
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
	
		public TermCasual GetOrCreateTermCasual(int? TermCasualID) {
            TermCasual item = this.TermCasual.FirstOrDefault(x => x.TermCasualID == TermCasualID);
			if (item == null){
				item = new TermCasual();
				this.TermCasual.AddObject(item);
			}
			return item;
        }

		private IObjectSet<TermCasual> _TermCasual = null;
        public IObjectSet<TermCasual> TermCasual {
            get {
                if (_TermCasual == null) {
                    var result = new List<TermCasual>();
                    _TermCasual = new FakeObjectSet<TermCasual>(result);
                }
                return _TermCasual;
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
