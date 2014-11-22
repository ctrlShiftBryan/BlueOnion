using System;
using System.Globalization;
using System.Web.UI;

namespace BlueOnion.MVC.Common
{
    public static class EtUtilHelper
    {
        public static string Eval(object container, string expression)
        {
            object value = container;
            if (!String.IsNullOrEmpty(expression))
            {
                value = DataBinder.Eval(container, expression);
            }
            return Convert.ToString(value, CultureInfo.CurrentCulture);
        }
    }
}

