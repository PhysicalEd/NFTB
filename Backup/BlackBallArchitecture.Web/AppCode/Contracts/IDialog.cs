using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Text;

namespace BlackBallArchitecture.Web.AppCode.Contracts
{
	public interface IDialog
	{
		void Append(string s);
		void AppendSingleConfirmationButton(string text,string postbackEventTarget);
		void AppendTitle(string s);
		void Show();
		void Show(string message, string title);
		void Show(string message, bool appendAsBulletPoints);
		string CloseButtonText { set; }
		void Show(Exception ex);
		void Show(string message);
		void AppendSingleRedirectionButton(string text, string redirectToURL);
		void AppendSingleJavascriptButton(string text, string JavascriptFunction);
		void AppendControl(Control ctl);
		int ForceHeightAtXPixels { set; }
		void Hide();
		bool HasMessage{get;}
		bool ShowAsBulletPoints{get;set;}
		bool ShowCloseButton { set; }
		string HideJavascript { get; }
		void Clear();
	}
}
