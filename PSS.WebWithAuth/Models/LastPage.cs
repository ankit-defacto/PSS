using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS.WebWithAuth.ViewModels
{
	public class LastPageViewModel
	{
		public LastPageViewModel(string viewName, string controllerName)
		{
			this.ViewName = viewName;
			this.ControllerName = controllerName;
		}

		public string ViewName
		{
			get;
			set;
		}

		public string ControllerName
		{
			get;
			set;
		}
	}
}