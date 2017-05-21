using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using BlackBallArchitecture.Common;
using BlackBallArchitecture.Common.Navigation;
using BlackBallArchitecture.Contracts;
using BlackBallArchitecture.Contracts.Exceptions;
using BlackBallArchitecture.Web.AppCode.Base;

namespace BlackBallArchitecture.Web.Controls
{
	public partial class ModalDialog : BaseControl, AppCode.Contracts.IDialog
	{

		[PersistenceMode(PersistenceMode.InnerProperty),
		 TemplateContainer(typeof(ModalDialog)),
		 TemplateInstance(TemplateInstance.Single)]
		public ITemplate BodyTemplate { get; set; }

		[PersistenceMode(PersistenceMode.InnerProperty),
		 TemplateContainer(typeof(ModalDialog)),
		 TemplateInstance(TemplateInstance.Single)]
		public ITemplate ButtonTemplate { get; set; }

		[PersistenceMode(PersistenceMode.InnerProperty),
		 TemplateContainer(typeof(ModalDialog)),
		 TemplateInstance(TemplateInstance.Single)]
		public ITemplate HeaderTemplate { get; set; }

		private System.Text.StringBuilder Msg = new System.Text.StringBuilder(200);

		private bool _ShowAsBulletPoints = true;
		public bool ShowAsBulletPoints
		{
			get { return _ShowAsBulletPoints; }
			set { _ShowAsBulletPoints = value; }
		}
		public bool AllowAutoHide = false;

		private bool _ShowCloseButton = true;
		public bool ShowCloseButton
		{
			get { return _ShowCloseButton; }
			set { _ShowCloseButton = value; }
		}

		public void Clear()
		{
			this.PHCustom.Controls.Clear();
		}

		private bool IsShowing
		{
			set
			{
				if (value) { this.ModalExtender.Show(); } else { this.ModalExtender.Hide(); }
			}
		}

		public int ForceHeightAtXPixels { get; set; }

		public int ForceWidthAtXPixels = 0;
		public string CloseButtonText
		{
			get
			{
				return this.BtnCloseModal.Text;
			}
			set
			{
				this.BtnCloseModal.Text = value;
			}
		}

		[Bindable(true)]
		[Category("Client")]
		[DefaultValue("")]
		public string OnCloseScript
		{
			get
			{
				return (string)(ViewState["closescript"] ?? "");
			}
			set
			{
				ViewState["closescript"] = value;
			}
		}


		protected string BehaviourName
		{
			get
			{
				return this.UniqueID + "_Behavior";
			}
		}

		protected string JS_NAMESPACE
		{
			get
			{
				return this.UniqueID + "JS";
			}
		}

		public string HideJavascript
		{
			get
			{
				return this.JS_NAMESPACE + ".Hide();";
			}
		}

		public string ShowJavascript
		{
			get
			{
				return this.JS_NAMESPACE + ".Show();";
			}
		}

		#region Page Events

		/// <summary>
		/// Initialize
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			this.ModalExtender.BehaviorID = this.BehaviourName;

			//Populate the body
			if (BodyTemplate != null)
				BodyTemplate.InstantiateIn(PHBody);

			if (ButtonTemplate != null)
				ButtonTemplate.InstantiateIn(PHButtons);

			//Populate the header
			if (HeaderTemplate != null)
			{
				HeaderTemplate.InstantiateIn(PHHeaderContent);
			}
		}

		/// <summary>
		/// Render - last minute binding
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			// Setup client script
			this.ModalExtender.OnCancelScript = this.HideJavascript;
			this.BtnCloseModal2.NavigateUrl = "javascript:" + this.HideJavascript;
			this.BtnCloseModal.NavigateUrl = "javascript:" + this.HideJavascript;
		}

		#endregion

		/// <summary>
		/// Appends each of these messages
		/// </summary>
		/// <param name="messages"></param>
		public void Append(List<string> messages)
		{
			messages.ForEach(x => Append(x));
		}

		/// <summary>
		/// Appends this string to the message
		/// </summary>
		/// <param name="s"></param>
		public void Append(string s)
		{
			if (s == "") { return; }
			s = s.Replace(Environment.NewLine, "<br/>");
			if (ShowAsBulletPoints)
			{
				this.Msg.Append("<li>" + s + "</li>");
			}
			else
			{
				this.Msg.Append(s);
			}
		}

		/// <summary>
		/// Shows the modal
		/// </summary>
		public void Show()
		{
			if (!this.ShowCloseButton)
			{
				BtnCloseModal2.Style["display"] = "none";
				BtnCloseModal.Style["display"] = "none";
			} else
			{
				BtnCloseModal2.Style.Remove("display");
				BtnCloseModal.Style.Remove("display");
			}

			// Create control to show error
			LiteralControl Ctl = null;
			if (this.ShowAsBulletPoints)
			{
				Ctl = new LiteralControl("<ul>" + Msg.ToString() + "</ul>");
			}
			else
			{
				Ctl = new LiteralControl(Msg.ToString());
			}
			AppendControl(Ctl);

			// Clear message for next time
			Msg = new System.Text.StringBuilder(200);

			// Set the height/width. For now we can only add scrollbars or not
			if (this.ForceHeightAtXPixels > 0 && this.ForceWidthAtXPixels > 0)
			{
				this.PHCustom.Width = new System.Web.UI.WebControls.Unit(this.ForceWidthAtXPixels, UnitType.Pixel);
				this.PHCustom.Height = new System.Web.UI.WebControls.Unit(this.ForceHeightAtXPixels, UnitType.Pixel);
				this.PHCustom.ScrollBars = ScrollBars.Both;
			}
			else if (this.ForceWidthAtXPixels > 0)
			{
				this.PHCustom.Width = new System.Web.UI.WebControls.Unit(this.ForceWidthAtXPixels, UnitType.Pixel);
				this.PHCustom.ScrollBars = ScrollBars.Horizontal;
			}
			else if (this.ForceHeightAtXPixels > 0)
			{
				this.PHCustom.Height = new System.Web.UI.WebControls.Unit(this.ForceHeightAtXPixels, UnitType.Pixel);
				this.PHCustom.ScrollBars = ScrollBars.Vertical;
			}

			// Finally, force the popup
			this.IsShowing = true;
			this.UPPopup.Update();
		}

		/// <summary>
		/// Hides the dialog
		/// </summary>
		public void Hide()
		{
			this.PHCustom.Controls.Clear();
			this.PHButtons.Controls.Clear();
			this.IsShowing = false;
		}

		/// <summary>
		/// Appends a title to this form
		/// </summary>
		/// <param name="s"></param>
		public void AppendTitle(string s)
		{
			this.LblTitle.Text = s;
		}

		/// <summary>
		/// Shows the message and sets the flag to show as bullet points or not
		/// </summary>
		/// <param name="message"></param>
		/// <param name="appendAsBulletPoints"></param>
		public void Show(string message, bool appendAsBulletPoints)
		{
			this.ShowAsBulletPoints = appendAsBulletPoints;
			this.Show(message);
		}

		/// <summary>
		/// Shows the exception
		/// </summary>
		/// <param name="ex"></param>
		public void Show(Exception ex)
		{

			if (ex is UserException)
			{
				this.Show(ex.Message, false);
				return;
			}

			// Log and tell user about it - this isn't the best place for error logging but its damned convenient when catching UI errors
			int errorID = Dependency.Resolve<ILogger>().Log(ex);
			var contactUrl =
				new LinkManager().Contact("More information about error " + errorID.ToString());
			this.Show(
				"Sorry, something went wrong when we tried to do that, so you may have to try it again.<br/><br/><h3>Is this a recurring problem?</h3>Our developers have already been notified of this and are probably scurring around frantically as we speak, but if you think you can help by telling us what you were doing when the problem happened, please <a href=\""
					+ contactUrl + "\">let us know</a>.", false);
		}


		/// <summary>
		/// Show
		/// </summary>
		public void Show(string Message, string Title)
		{
			if (Message != "")
			{
				this.Append(Message);
			}
			this.AppendTitle(Title);
			Show();
		}
		public void Show(string Message, string Title, bool showAsBulletPoints)
		{
			this.ShowAsBulletPoints = showAsBulletPoints;
			Show(Message, Title);
		}
		public void Show(string msg)
		{
			if (msg != "")
			{
				this.Append(msg);
			}
			Show();
		}

		/// <summary>
		/// Adds a confirmation button to the 
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="PostbackEventTarget"></param>
		public void AppendSingleConfirmationButton(string Text, string PostbackEventTarget)
		{
			string s = "<input class=\"button\" type=\"button\" onclick=\"javascript:__doPostBack('" + PostbackEventTarget + "','')\" value=\"" + Text + "\"/>";
			this.PHButtons.Controls.Add(new LiteralControl(s));
		}

		/// <summary>
		/// Append a button which does a client-side redirect
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="RedirectToURL"></param>
		public void AppendSingleRedirectionButton(string Text, string RedirectToURL)
		{
			if (RedirectToURL.StartsWith("~/"))
			{
				RedirectToURL = Library.GetFullUrl(RedirectToURL);
			}
			string s = "<input class=\"button\" type=button onclick=\"document.location='" + RedirectToURL +
						   "'\" value=\"" + Text + "\"/>";
			this.PHButtons.Controls.Add(new LiteralControl(s));
		}

		/// <summary>
		/// Appends a button which, on click, runs the specified javascript function
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="JavascriptFunction"></param>
		public void AppendSingleJavascriptButton(string Text, string JavascriptFunction)
		{
			string s = "<input class=\"button\" type=\"button\" onclick=\"javascript:" + JavascriptFunction +
					   "\" value=\"" + Text + "\"/>";
			this.PHButtons.Controls.Add(new LiteralControl(s));
		}

		/// <summary>
		/// Appends the web control to the modal dialog
		/// </summary>
		/// <param name="ctrl"></param>
		public void AppendControl(Control ctrl)
		{
			this.PHCustom.Controls.Add(ctrl);
		}


		public bool HasMessage
		{
			get { return (Msg.Length > 0); }
		}
	}
}