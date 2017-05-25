using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFTB.Contracts.DataManagers;
using NFTB.Contracts.Entities.Data;

namespace NFTB.API.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        public List<Person> Index()
        {
			return Dependency.Resolve<IPersonManager>().GetPerson(null);
        }
    }
}
