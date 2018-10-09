﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class TermDetailModelResult
    {
        public TermSummary Term { get; set; } = new TermSummary();
        public List<PlayerSummary> TermPlayers { get; set; }
        public int NumberOfTermPlayers { get; set; }

        public List<AttendanceSummary> Attendances { get; set; }
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        public List<PlayerAttendanceSummary> CasualPlayerAttendancesForTerm { get; set; } = new List<PlayerAttendanceSummary>();
        public int ExpectedAmountFromCasuals { get; set; }
        public decimal ActualAmountFromCasuals { get; set; }
        public int TotalAmountOwingFromTermPlayers { get; set; }

        public InvoiceSummary Invoice { get; set; }

    }
}
