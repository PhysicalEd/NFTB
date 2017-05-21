using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlackBallArchitecture.Common.Extensions;
using BlackBallArchitecture.Common.Navigation;
using BlackBallArchitecture.Contracts.Enums;
using BlackBallArchitecture.Contracts.Security;
using BlackBallArchitecture.Web.AppCode;
using BlackBallArchitecture.Web.AppCode.Base;
using BlackBallArchitecture.Web.AppCode.Contracts;

namespace BlackBallArchitecture.Web.Include.Master
{
	public partial class SiteContainer : BaseMaster
	{
		#region Properties

		public override IDialog Dialog { get { return null; } }

		#endregion

		#region Page Events

		/// <summary>
		/// Load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		/// <summary>
		/// Last minute binding
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var linkMgr = new Common.Navigation.LinkManager();
				this.BtnHome.NavigateUrl = linkMgr.Home();
			}
		}

		#endregion
	}
}
