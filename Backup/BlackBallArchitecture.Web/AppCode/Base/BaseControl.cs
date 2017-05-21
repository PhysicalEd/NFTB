using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackBallArchitecture.Web.AppCode.Base
{
	public abstract class BaseControl : System.Web.UI.UserControl
	{
		#region Properties

		public event System.EventHandler Finished = null;
		protected void RaiseFinishedEvent(object obj, EventArgs args)
		{
			if (Finished != null) { Finished.Invoke(obj, args); }
		}

		public event System.EventHandler Cancelled = null;
		protected void RaiseCancelledEvent(object obj, EventArgs args)
		{
			if (Cancelled != null) { Cancelled.Invoke(obj, args); }
		}

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
	}
}
