using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Humanizer;

namespace ViewModel
{
    public static class ViewModelMeta
    {
        public static List<ColumnData> GetColumns<T>(List<T> list)
        {
            var columns = new List<ColumnData>();
            var properties = typeof(T).GetProperties();
            foreach(var pi in properties)
            {
                var data = new ColumnData();
                data.DisplayName = GetDisplayName(pi);
                data.ColumnName = pi.Name;
                data.SortColumn = GetSortColumn(pi);
                data.DisableSort = IsSortDisabled(pi);
                data.Format = GetFormat(pi);
                data.IsHidden = IsHidden(pi);

                columns.Add(data);
            }
            return columns;
        }

        public static string SplitCamelCase(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }

        public static string GetDisplayName(PropertyInfo pi)
        {
            var name = "";
            if(pi.IsDefined(typeof(DisplayAttribute), false))
            {
                name = pi.GetCustomAttributes(typeof(DisplayAttribute),false).Cast<DisplayAttribute>().Single().Name;
            }
            else
            {
                name = pi.Name.Humanize(LetterCasing.Title);
            }

            return name;
        }

        public static string GetSortColumn(PropertyInfo pi)
        {
            var sortColumn = pi.Name;

            if (pi.IsDefined(typeof(SortAttribute), false))
            {
                sortColumn = pi.GetCustomAttributes(typeof(SortAttribute), false).Cast<SortAttribute>().Single().ColumnOverride;
            }

            return sortColumn;
        }

        public static bool IsSortDisabled(PropertyInfo pi)
        {
            var sortDisabled = false;
            if (pi.IsDefined(typeof(SortAttribute), false))
            {
                sortDisabled = pi.GetCustomAttributes(typeof(SortAttribute), false).Cast<SortAttribute>().Single().DisableSort;
            }
            return sortDisabled;
        }

        public static bool IsHidden(PropertyInfo pi)
        {
            var hidden = false;
            if (pi.IsDefined(typeof(HiddenAttribute), false))
            {
                hidden = pi.GetCustomAttributes(typeof(HiddenAttribute), false).Cast<HiddenAttribute>().Single().Hidden;
            }
            return hidden;
        }

        public static Format GetFormat(PropertyInfo pi)
        {
            // by default render everything as html
            // formats are defined in /scripts/app/plugins/ko.customBinding.js
            var format = new Format();
            // if a binding is set, use that.
            if (pi.IsDefined(typeof(BindingAttribute), false))
            {
                format.Binding = pi.GetCustomAttributes(typeof(BindingAttribute), false).Cast<BindingAttribute>().Single().Binding;
            }
            // otherwise derive based on the type
            else
            {
                if (pi.PropertyType == typeof(Nullable<DateTime>) || pi.PropertyType == typeof(DateTime))
                {
                    format.Binding = "datetime";
                }
                else if (pi.PropertyType == typeof(Nullable<decimal>) || pi.PropertyType == typeof(decimal))
                {
                    format.Binding = "decimal";
                    //currency
                    if (pi.IsDefined(typeof(UIHintAttribute), false))
                    {
                        if (pi.GetCustomAttributes(typeof(UIHintAttribute), false).Cast<UIHintAttribute>().Single().UIHint == "currency")
                        {
                            format.FormatString = "$0.00";
                        }
                    }
                }
            }
            
            // get format string
            if (pi.IsDefined(typeof(DisplayFormatAttribute), false))
            {
                format.FormatString = pi.GetCustomAttributes(typeof(DisplayFormatAttribute), false).Cast<DisplayFormatAttribute>().Single().DataFormatString;
            }

            return format;
        }
    }
}
