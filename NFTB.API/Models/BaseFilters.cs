﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Models
{
    public class BaseFilters
    {
        public string Search { get; set; }
    }
}
