using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BlackBallArchitecture.Common.Navigation;
using BlackBallArchitecture.Common.Extensions;
using BlackBallArchitecture.Contracts.Web;

namespace BlackBallArchitecture.Web.AppCode.Base
{
	public abstract class BasePage : System.Web.UI.Page
	{
		#region Properties

		/// <summary>
		/// Reference to the dialog on the master page
		/// </summary>
		protected AppCode.Contracts.IDialog Dialog
		{
			get
			{
				if (this.Page.Master != null && this.Page.Master.GetType().IsSubclassOf(typeof(AppCode.Base.BaseMaster)))
				{
					return ((AppCode.Base.BaseMaster)this.Page.Master).Dialog;
				}
				return null;
			}
		}

		#endregion

		/// <summary>
		/// Last-minute binding
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="e"></param>
		public void Page_PreRender(object obj, EventArgs e)
		{
		}

	}
}
