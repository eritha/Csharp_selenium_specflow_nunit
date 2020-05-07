using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ConfigKeys
{
    ENVIRONMENT,
    QC_NAME,
    ORGANIZATION_NAME,
    SELENIUM_HUB,
    SELENIUM_BASE_URL,
    BROWSER,
    REPORT_HTLM,
    API_DOMAIN,
    API_AUTHORIZATION
}

namespace Csharp_selenium_specflow_nunit.Utility
{
    public class Configs
    {
        public static string varEnvironment;
        public static string varQcName;
        public static string varOrgName;
        public static string varSeleniumHub;
        public static string varSeleniumBaseUrl;
        public static string varBrowser;
        public static string varReportHtlm;
        public static string varApiDomain;
        public static string varApiAuthorization;

        /// <summary>
        /// Get any parameter from TestContext of nunit.runsettings, if not get AppSettings key from app.config
        /// </summary>
        static string GetConfigValue(string para)
        {
            var value = "";
            try
            {
                value = TestContext.Parameters[para] != null ? TestContext.Parameters[para] : ConfigurationManager.AppSettings[para];
            }
            catch (SettingsPropertyNotFoundException ex)
            {
                Console.WriteLine("Parameter NOT found : " + para);
                Console.WriteLine("Class FileUtils | Method GetParameter | Exception desc : " + ex.Message);
            }
            return value;
        }

        /// <summary>
        /// Get a value from nunit.runsettings|app.config with Environment
        /// </summary>
        public static string GetConfigValueByEnvironment(string keyName)
        {
            var value = "";
            try
            {
                value = GetConfigValue(string.Join("_", varEnvironment, keyName));
            }
            catch (SettingsPropertyNotFoundException ex)
            {
                Console.WriteLine("Parameter NOT found : " + string.Join(varEnvironment, "_", keyName));
                Console.WriteLine("Class FileUtils | Method GetParameter | Exception desc : " + ex.Message);
            }
            return value;
        }
        /// <summary>
        /// Init all data config from nunit.runsettings|app.config
        /// </summary>
        public static void InitDataConfig()
        {
            varEnvironment = GetConfigValue(ConfigKeys.ENVIRONMENT.ToString());
            varQcName = GetConfigValueByEnvironment(ConfigKeys.QC_NAME.ToString());
            varOrgName = GetConfigValueByEnvironment(ConfigKeys.ORGANIZATION_NAME.ToString());
            varSeleniumHub = GetConfigValueByEnvironment(ConfigKeys.SELENIUM_HUB.ToString());
            varSeleniumBaseUrl = GetConfigValueByEnvironment(ConfigKeys.SELENIUM_BASE_URL.ToString());
            varBrowser = GetConfigValueByEnvironment(ConfigKeys.BROWSER.ToString());
            varReportHtlm = GetConfigValueByEnvironment(ConfigKeys.REPORT_HTLM.ToString());
            varApiDomain = GetConfigValueByEnvironment(ConfigKeys.API_DOMAIN.ToString());
            varApiAuthorization = GetConfigValueByEnvironment(ConfigKeys.API_AUTHORIZATION.ToString());
        }
    }
}