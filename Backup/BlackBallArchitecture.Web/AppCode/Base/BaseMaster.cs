using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackBallArchitecture.Web.AppCode.Base
{
	public abstract class BaseMaster : System.Web.UI.MasterPage
	{
		public abstract AppCode.Contracts.IDialog Dialog { get; }
	}
}