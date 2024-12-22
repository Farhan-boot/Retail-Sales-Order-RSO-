using System;
using System.Data;
using System.Configuration;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

namespace APL.BL.SFTS.ShelterZone
{
    public class ConfigFileManager : ConfigurationSection
    {
        static AppSettingsReader _config = new AppSettingsReader();

        private static ConfigFileManager INSTANCE;

        /// <summary>
        /// This static method will return the instance of ConfigFileManager class it will create new instance 
        /// of ConfigFileManager class if not already available.
        /// </summary>
        /// <returns>ConfigFileManager</returns>
        public static ConfigFileManager GetInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ConfigFileManager();
            return INSTANCE;
        }

        /// <summary>
        /// Private constructor so instance can be made only from GetInstance method 
        /// </summary>
        private ConfigFileManager()
        { }

        /// <summary>
        /// Return object of AppSettingsReader
        /// </summary>
        /// <returns>AppSettingsReader</returns>
        public AppSettingsReader GetConfig()
        {
            return _config;
        }

        /// <summary>
        /// This method returns the value of the key provicded in specific section of configuration file
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>string</returns>
        public string GetValue(string key)
        {
            string value = null;
            try
            {
                value = this.GetConfig().GetValue(key, Type.GetType("System.String")).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return value;
        }
    }
}
