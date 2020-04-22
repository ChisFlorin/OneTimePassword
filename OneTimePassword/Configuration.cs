using System.Configuration;

namespace OneTimePassword
{
    public static class Configuration
    {
        public static string Key => ConfigurationManager.AppSettings.Get("Key");

        public static string IV => ConfigurationManager.AppSettings.Get("IV");

        public static int PasswordDuration => int.Parse(ConfigurationManager.AppSettings.Get("OneTimePasswordDuration"));
    }
}
