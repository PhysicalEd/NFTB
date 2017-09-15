using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Entities.Data
{
    public class InvoiceSummary
    {
        public int InvoiceID { get; set; }
        public int TermID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int TotalAmount { get; set; }
        public int NumberOfSessions { get; set; }





    }
}
