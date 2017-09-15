


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// CAUTION - AUTOMATICALLY GENERATED
// These classes have been automatically generated from the core database. Use partial classes to create custom properties
// Code Generation Template developed by Ben Liebert, 14 Sep 2017 
namespace NFTB.Contracts.Entities.Data {

	/// <summary>
	/// Interface of our generic Attendance object
	/// </summary>
	public partial class Attendance
	{
		public int AttendanceID { get; set; }
		public int TermID { get; set; }
		public DateTime AttendanceDate { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsNew { get { return (this.AttendanceID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic Invoice object
	/// </summary>
	public partial class Invoice
	{
		public int InvoiceID { get; set; }
		public int TermID { get; set; }
		public int Status { get; set; }
		public DateTime InvoiceDate { get; set; }
		public int TotalAmount { get; set; }
		public DateTime? WhenPaid { get; set; }
		public bool IsNew { get { return (this.InvoiceID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic Login object
	/// </summary>
	public partial class Login
	{
		public int LoginID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public bool IsNew { get { return (this.LoginID == 0); } }
	}
		
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
		public int? LoginID { get; set; }
		public bool IsNew { get { return (this.PersonID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic Player object
	/// </summary>
	public partial class Player
	{
		public int PlayerID { get; set; }
		public int PersonID { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsNew { get { return (this.PlayerID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic PlayerAttendance object
	/// </summary>
	public partial class PlayerAttendance
	{
		public int PlayerAttendanceID { get; set; }
		public int AttendanceID { get; set; }
		public int PlayerID { get; set; }
		public bool IsCasual { get; set; }
		public int AmountPaid { get; set; }
		public bool IsNew { get { return (this.PlayerAttendanceID == 0); } }
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
	/// Interface of our generic Term object
	/// </summary>
	public partial class Term
	{
		public int TermID { get; set; }
		public string TermName { get; set; }
		public DateTime TermStart { get; set; }
		public DateTime? TermEnd { get; set; }
		public int BondAmount { get; set; }
		public int CasualRate { get; set; }
		public bool IncludeOrganizer { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsActive { get; set; }
		public bool IsNew { get { return (this.TermID == 0); } }
	}
		
	/// <summary>
	/// Interface of our generic TermPlayer object
	/// </summary>
	public partial class TermPlayer
	{
		public int TermPlayerID { get; set; }
		public int TermID { get; set; }
		public int PlayerID { get; set; }
		public bool BondPaid { get; set; }
		public int? TermDue { get; set; }
		public int? TermOwing { get; set; }
		public bool IsNew { get { return (this.TermPlayerID == 0); } }
	}
		

}




