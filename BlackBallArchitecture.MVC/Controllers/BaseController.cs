using System;
using System.Text;
using BlackBallArchitecture.Common.Extensions;
using System.Web;
using System.Web.Mvc;
using BlackBallArchitecture.Contracts;
using Web.Models;

namespace BlackBallArchitecture.MVC.Controllers
{
	public class BaseController : System.Web.Mvc.Controller
	{
		/// <summary>
		/// Pre-processing just before we generate our HTML
		/// </summary>
		/// <param name="filterContext"></param>
		protected override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			if (filterContext.Result is ViewResult || filterContext.Result is PartialViewResult)
			{
				// Render a reference to our CSS file
				var viewPath = this.GetViewFolderName(filterContext.Result);
				if (!string.IsNullOrWhiteSpace(viewPath)) this.RenderPartialCssClass(viewPath);
			}

			base.OnResultExecuting(filterContext);
		}

		/// <summary>
		/// Post-processing just after we've generated our HTML
		/// </summary>
		/// <param name="filterContext"></param>
		protected override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			var viewFolder = this.GetViewFolderName(filterContext.Result);
			var viewFile = this.GetViewFileName(filterContext.Result);
			var modelJSON = "";

			// Cast depending on result type
			if (filterContext.Result is ViewResult)
			{
				var view = ((ViewResult)filterContext.Result);
				if (view != null && view.Model is BaseModel) modelJSON = view.Model.ToJSON();
			}
			else if (filterContext.Result is PartialViewResult)
			{
				var view = ((PartialViewResult)filterContext.Result);
				if (view != null && view.Model is BaseModel) modelJSON = view.Model.ToJSON();
			}

			// Render our javascript tag which automatically brings in the file based on the view name
			if (!string.IsNullOrWhiteSpace(viewFolder) && !string.IsNullOrWhiteSpace(modelJSON))
			{

				var js = @"
					<script>
						require(['lib', 'controllers/" + viewFolder + @"/" + viewFile + @"'], function(lib, ctrl) {
							lib.BindView(" + modelJSON + @", ctrl);
						});
					</script>";

				// Write script
				filterContext.HttpContext.Response.Write(js);
			}

			base.OnResultExecuted(filterContext);
		}

		/// <summary>
		/// Parses our view to find the folder path - used to dynamically reference associated CSS and script files
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		private string GetViewFolderName(ActionResult result)
		{
			var viewName = "";
			if (result is ViewResult) viewName = ((ViewResult)result).ViewName;
			else if (result is PartialViewResult) viewName = ((PartialViewResult)result).ViewName;
			if (string.IsNullOrWhiteSpace(viewName)) return null;

			// Load our result
			var viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, "");
			if (viewResult == null || viewResult.View == null) return null;

			// Parse the path
			var viewPath = ((RazorView)viewResult.View).ViewPath;
			var fileParts = viewPath.Split('/');

			// Remove the first folder, which is 'views'
			if (fileParts.Length <= 1) return null;

			// Remove the 'shared' folder, so we can rationalize our views under a common folder structure, without having to duplicate under 'shared' as well
			var folder = fileParts[fileParts.Length - 2].ToLower();
			if (folder == "shared") folder = fileParts[fileParts.Length - 3].ToLower();
			return folder;
		}

		/// <summary>
		/// Gets the name of this view file. Used to dynamically inject CSS/JS references
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		private string GetViewFileName(ActionResult result)
		{
			var viewName = "";
			if (result is ViewResult) { viewName = ((ViewResult)result).ViewName; }
			else if (result is PartialViewResult) viewName = ((PartialViewResult)result).ViewName;
			if (string.IsNullOrWhiteSpace(viewName)) return null;

			var fileParts = viewName.Split('/');
			return fileParts[fileParts.Length - 1];
		}

		/// <summary>
		/// Renders our partial CSS class based on the folder that this view is in
		/// </summary>
		/// <param name="viewFolderName"></param>
		private void RenderPartialCssClass(string viewFolderName)
		{
			var path = "/Content/x" + viewFolderName + ".min.css";
			this.ControllerContext.HttpContext.Response.Write("<link href=\"" + path + "\" rel=\"stylesheet\" type=\"text/css\">");
		}
	}
}