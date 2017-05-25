using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackBallArchitecture.Contracts.Entities.Lists;
using Web.Models;

namespace BlackBallArchitecture.MVC.Models.Home
{
	public class WelcomeModel : BaseModel
	{
		public PersonList People = new PersonList();
	}
}