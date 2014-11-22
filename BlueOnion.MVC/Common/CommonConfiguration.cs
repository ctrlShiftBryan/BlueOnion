using System;
using System.Configuration;

namespace BlueOnion.MVC.Common
{
    public class CommonConfiguration
    {
        public static string AppSetting(string name)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[name]);
        }

        public static string ConnectionString(string name)
        {
            return Convert.ToString(ConfigurationManager.ConnectionStrings[name]);
        }
    }
}