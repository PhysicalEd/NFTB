using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackBallArchitecture.Contracts.DataManagers;
using BlackBallArchitecture.MVC.Models.Home;

namespace BlackBallArchitecture.MVC.Controllers
{
    public class HomeController : BaseController
    {
        
		/// <summary>
		/// Starting point
		/// </summary>
		/// <returns></returns>
        public ActionResult Index()
		{
		    return Content("Index");
		}

		/// <summary>
		/// Creates a new person in our data store
		/// </summary>
		/// <returns></returns>
		public ActionResult CreatePerson()
		{
			// creates a new person and adds to our data store
			//var person = Dependency.Resolve<IPersonManager>().SavePerson(null, "", firstName, "", "", "");
			//return Json(person, JsonRequestBehavior.AllowGet);
            return Content("Create person");
        }

		/// <summary>
		/// Shows our list of people
		/// </summary>
		/// <returns></returns>
		public ActionResult Welcome()
		{
			//var model = new WelcomeModel();

			//// Ensure at least one person - just for this demo
			//model.People = Dependency.Resolve<IPersonManager>().GetPerson(null);

            return Content("Welcome");
        }

    }
}
