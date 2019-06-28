using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.API.Models;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;
using NFTB.Logic.DataManagers;

namespace NFTB.API.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            return "OK";
        }
    }


}
