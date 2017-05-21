using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlackBallArchitecture.Common;
using BlackBallArchitecture.Common.Navigation;
using BlackBallArchitecture.Contracts.DataManagers;
using BlackBallArchitecture.Contracts.Entities.Data;

namespace BlackBallArchitecture.Web
{
	public partial class Default : AppCode.Base.BasePage
	{
		#region Properties

		public int MaxPersonID {
			get { return (int)(ViewState["MaxPersonID"] ?? 0); }
			set { ViewState["MaxPersonID"] = value; }
		}	

		#endregion

		#region Page Events

		/// <summary>
		/// Load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(this.BtnNew);
			this.BtnNew.Click += new EventHandler(BtnNew_Click);
			if (!Page.IsPostBack)
			{
				this.BindPeople();
			}
		}

		#endregion

		#region Binding

		/// <summary>
		/// Binds the list of people from the data source
		/// </summary>
		private void BindPeople()
		{
			var people = Dependency.Resolve<IPersonManager>().GetPerson(null);

			// Bit of a hack, just for the demo. We record the max person ID so that we can increment the names below
			if (people.Any()) this.MaxPersonID = people.Max(x => x.PersonID);

			// Bind list
			this.Rpt.DataSource = people;
			this.Rpt.ItemDataBound += new RepeaterItemEventHandler(Rpt_ItemDataBound);
			this.Rpt.DataBind();
			this.Rpt.Visible = (this.Rpt.Items.Count > 0);
			this.UPPeople.Update();
		}

#endregion

		#region Control Events

		/// <summary>
		/// Manually handle binding of person information to the data list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			var person = (Person) e.Item.DataItem;
			if (person == null) return;
			var LblName = (Literal)e.Item.FindControl("LblName");
			var LblCreated = (Literal)e.Item.FindControl("LblCreated");
			LblName.Text = person.DisplayName;
			LblCreated.Text = person.WhenCreated.ToString("d MMM, h:mm:ss tt");
		}

		/// <summary>
		/// Create a new person
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnNew_Click(object sender, EventArgs e)
		{
			var personMgr = Dependency.Resolve<IPersonManager>();
			var firstName = "Person" + (this.MaxPersonID + 1).ToString();
			personMgr.SavePerson(null, firstName + "@example.com", firstName, "Jones", "", "");

			// Rebind
			this.BindPeople();
		}

		#endregion
	}
}
