using System;
using System.Data.Entity.Core.Objects;
using NFTB.Contracts.Entities.Data;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 20 May 2017 
namespace NFTB.Contracts.Repositories {

	 /// <summary>
    /// Abstracts the data-storage mode away from the caller
    /// </summary>
    public partial interface IRepository
    {
    
		Entities.Data.Person GetOrCreatePerson(int? PersonID);
        IObjectSet<Entities.Data.Person> Person { get; }
		Entities.Data.SystemLog GetOrCreateSystemLog(int? SystemLogID);
        IObjectSet<Entities.Data.SystemLog> SystemLog { get; }
		Entities.Data.SystemLogg GetOrCreateSystemLogg(int? SystemLoggID);
        IObjectSet<Entities.Data.SystemLogg> SystemLogg { get; }
		Entities.Data.Term GetOrCreateTerm(int? TermID);
        IObjectSet<Entities.Data.Term> Term { get; }
		Entities.Data.TermCasual GetOrCreateTermCasual(int? TermCasualID);
        IObjectSet<Entities.Data.TermCasual> TermCasual { get; }
		Entities.Data.TermPlayer GetOrCreateTermPlayer(int? TermPlayerID);
        IObjectSet<Entities.Data.TermPlayer> TermPlayer { get; }
	}
}
