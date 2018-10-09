﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.API.Models;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Controllers
{
    public class TermController : ApiController
    {
        [HttpGet]
        public List<TermSummary> TermList(bool? includeDeleted)
        {
            var result = Dependency.Resolve<ITermManager>().GetTerms(includeDeleted);
            return result;
        }

        [HttpGet]
        public TermSummary ActiveTerm()
        {
            return Dependency.Resolve<ITermManager>().GetTerms(false).FirstOrDefault(x => x.IsActive);
        }


        [HttpGet]
        public void DeleteTerm(int? termID)
        {
            Dependency.Resolve<ITermManager>().DeleteTerm(termID);
        }

        [HttpGet]
        public TermSummary SaveTerm(int? termID, string termName, DateTime termStart, DateTime? termEnd, int bondAmount, int casualRate, bool includeOrganizer, bool isDeleted, bool isActive, bool isInvoiced)
        {
            var termMgr = Dependency.Resolve<ITermManager>();
            // Save term
            return termMgr.SaveTerm(termID, termName, termStart, termEnd, bondAmount, casualRate, includeOrganizer, isInvoiced);
        }

        [HttpGet]
        public InvoiceSummary SaveInvoice(int? invoiceID, int termID, DateTime invoiceDate, int totalAmount, int numberOfSessions, DateTime? whenPaid)
        {
            var termMgr = Dependency.Resolve<ITermManager>();
            // Save invoice
            return termMgr.SaveInvoice(invoiceID, termID, invoiceDate, totalAmount, numberOfSessions, whenPaid);
        }

        [HttpGet]
        public TermDetailModelResult TermDetails(int termID)
        {
            var model = new TermDetailModelResult();

            var termMgr = Dependency.Resolve<ITermManager>();
            var playerMgr = Dependency.Resolve<IPlayerManager>();
            var attendanceMgr = Dependency.Resolve<IAttendanceManager>();

            model.Term = termMgr.GetTerm(termID);
            model.TermPlayers = playerMgr.GetPlayers(null, null);
            model.Invoice = termMgr.GetInvoiceByTerm(termID);
            model.Attendances = attendanceMgr.GetAttendances(null, termID);

            if (model.Attendances.Any())
            {
                foreach (var attendance in model.Attendances)
                {
                    attendance.PlayerAttendances = attendanceMgr.GetPlayerAttendances(attendance.AttendanceID);
                    attendance.CasualPlayerAttendances = attendance.PlayerAttendances.Where(x => x.IsCasual).ToList();
                    
                    //attendance.ActualAmountFromCasuals = attendance.CasualsAttended * attendance.CasualPlayerAttendances.Sum(x=>x.AmountPaid);
                    //attendance.ExpectedAmountFromCasuals = attendance.CasualsAttended * attendance.CasualsRate;
                }
            }

            model.ExpectedAmountFromCasuals = model.Attendances.Sum(x => x.ExpectedAmountFromCasuals);
            model.ActualAmountFromCasuals = model.Attendances.Sum(x => x.ActualAmountFromCasuals);
            model.NumberOfTermPlayers = model.TermPlayers.Count;
            //model.NumberOfSessions

            //model.ActualAmountFromCasuals = model.CasualPlayerAttendancesForTerm.Count * model.Term.CasualRate;
            //model.TotalAmountOwingFromTermPlayers = model.TermPlayers.Count * model.Term. 

            return model;
        }

        [HttpGet]
        public InvoiceSummary InvoiceDetails(int invoiceID)
        {
            var termMgr = Dependency.Resolve<ITermManager>();
            var invoice = termMgr.GetInvoice(invoiceID);
            return invoice;
        }

        [HttpGet]
        public InvoiceSummary InvoiceDetailByTerm(int termID)
        {
            var termMgr = Dependency.Resolve<ITermManager>();
            var invoice = termMgr.GetInvoiceByTerm(termID);
            return invoice;
        }
    }
}
