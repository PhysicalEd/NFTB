using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using NFTB.Common.Extensions;
using NFTB.Contracts;
using NFTB.Contracts.Cache;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Contracts.Entities.Lists;
using NFTB.Contracts.Enums;


namespace NFTB.Logic.DataManagers
{
	public partial class TermManager : ITermManager
	{
        /// <summary>
        /// Gets the current term
        /// </summary>
        /// <returns></returns>
	    public TermSummary GetCurrentTerm()
	    {
	        var terms = this.GetTerms();
	        var now = DateTime.Now;
	        var currentTerm = terms.FirstOrDefault(x => x.TermStart >= now && x.TermEnd <= now);
	        return currentTerm;
	    }
	    public List<TermSummary> GetTerms()
	    {
	        using (var cxt = DataStore.GetDataStore())
	        {
	            var data = (
                        from term in cxt.Term
                        select new TermSummary()
                        {
                            TermID = term.TermID,
                            TermName = term.TermName,
                            BondAmount = term.BondAmount,
                            CasualRate = term.CasualRate,
                            IncludeOrganizer = term.IncludeOrganizer,
                            TermStart = term.TermStart,
                            TermEnd = term.TermEnd,
                            IsDeleted = term.IsDeleted,
                            IsActive = term.IsActive,
                        }
                    );

                // Filters
                //if (includeDeleted.HasValue && includeDeleted == false) data = data.Where(x => x.IsDeleted == false);

	            return data.ToList();
	        }
	    }

	    public TermSummary GetTerm(int termID)
	    {
	        return this.GetTerms().FirstOrDefault(x=>x.TermID == termID);
	    }

        public TermSummary SaveTerm(int? termID, string termName, DateTime termStart, DateTime? termEnd, int bondAmount, int casualRate, bool includeOrganizer, bool? isInvoiced)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var term = cxt.GetOrCreateTerm(termID);
                if (term.IsNew)
                {
                    
                }
                term.TermName = termName;
                term.TermStart = termStart;
                term.TermEnd = termEnd;
                term.BondAmount = bondAmount;
                term.CasualRate = casualRate;
                term.IncludeOrganizer = includeOrganizer;
                cxt.SubmitChanges();
                return this.GetTerm(term.TermID);
            }
        }

	    public TermSummary GetLatestActiveTerm()
	    {
	        return this.GetTerms().FirstOrDefault(x => x.IsActive);
	    }

        public InvoiceSummary SaveInvoice(int? invoiceID, int termID, DateTime invoiceDate, int totalAmount, int numberOfSessions, DateTime? whenPaid)
	    {
	        using (var cxt = DataStore.GetDataStore())
	        {
	            var invoice = cxt.GetOrCreateInvoice(invoiceID);
	            invoice.TermID = termID;
	            invoice.InvoiceDate = invoiceDate;
	            invoice.TotalAmount = totalAmount;
	            invoice.NumberOfSessions = numberOfSessions;
	            invoice.WhenPaid = whenPaid;
                cxt.SubmitChanges();
	            return this.GetInvoice(invoice.InvoiceID);
	        }

	    }

        public void DeleteTerm(int? termID)
        {
            using (var cxt = DataStore.GetDataStore())
            {
                var term = (from t in cxt.Term
                            where t.TermID == termID
                            select t
                    ).FirstOrDefault();
                if (term == null) return;
                term.IsDeleted = true;
                cxt.SubmitChanges();
            }

        }

	    public InvoiceSummary GetInvoice(int invoiceID)
	    {
	        return this.GetInvoices(null).FirstOrDefault(x => x.InvoiceID == invoiceID);
	    }

        public InvoiceSummary GetInvoiceByTerm(int termID)
	    {
	        return this.GetInvoices(termID).FirstOrDefault();
	    }


        public List<InvoiceSummary> GetInvoices(int? termID)
	    {
	        using (var cxt = DataStore.GetDataStore())
	        {
	            var data = (
                    from i in cxt.Invoice
                    join t in cxt.Term on i.TermID equals t.TermID
                    select new InvoiceSummary()
                    {
                        InvoiceID = i.InvoiceID,
                        TermID = t.TermID,
                        TermName = t.TermName,
                        TermStart = t.TermStart,
                        TermEnd = t.TermEnd,
                        OrganizerIncluded = t.IncludeOrganizer,
                        WhenPaid = i.WhenPaid,
                        InvoiceDate = i.InvoiceDate,
                        TotalAmount = i.TotalAmount,
                        NumberOfSessions = i.NumberOfSessions

                    }
                    
                ).ToList();

	            if (termID.HasValue) data = data.Where(x => x.TermID == termID).ToList();

	            return data;
	        }
	    }
    }
}
