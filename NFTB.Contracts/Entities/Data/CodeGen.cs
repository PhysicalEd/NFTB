


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 23 May 2017 
namespace NFTB.Contracts.Entities.Data {

	/// <summary>
	/// Interface of our generic Person object
	/// </summary>
	public partial class Person
	{
		public int PersonID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool IsNew { get { return (this.PersonID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic SystemLog object
	/// </summary>
	public partial class SystemLog
	{
		public int SystemLogID { get; set; }
		public int? PersonID { get; set; }
		public DateTime WhenOccurred { get; set; }
		public string Message { get; set; }
		public string Details { get; set; }
		public int SystemLogTypeID { get; set; }
		public bool IsNew { get { return (this.SystemLogID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic SystemLogg object
	/// </summary>
	public partial class SystemLogg
	{
		public int SystemLoggID { get; set; }
		public int? PersonID { get; set; }
		public DateTime WhenOccurred { get; set; }
		public string Message { get; set; }
		public string Details { get; set; }
		public int SystemLoggTypeID { get; set; }
		public bool IsNew { get { return (this.SystemLoggID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic Term object
	/// </summary>
	public partial class Term
	{
		public int TermID { get; set; }
		public DateTime TermStart { get; set; }
		public DateTime? TermEnd { get; set; }
		public int BondAmount { get; set; }
		public int CasualRate { get; set; }
		public bool IncludeOrganizer { get; set; }
		public bool IsNew { get { return (this.TermID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic TermCasual object
	/// </summary>
	public partial class TermCasual
	{
		public int TermCasualID { get; set; }
		public int TermID { get; set; }
		public int PersonID { get; set; }
		public bool Paid { get; set; }
		public bool IsNew { get { return (this.TermCasualID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic TermPermanent object
	/// </summary>
	public partial class TermPermanent
	{
		public int TermPermanentID { get; set; }
		public int TermID { get; set; }
		public int PersonID { get; set; }
		public bool BondPaid { get; set; }
		public int? TermDue { get; set; }
		public int? TermOwing { get; set; }
		public bool Casual { get; set; }
		public bool IsNew { get { return (this.TermPermanentID == 0); } }
	}
		

}




