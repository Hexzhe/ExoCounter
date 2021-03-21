using Microsoft.Win32;

namespace ExoCounter
{
    public static class RegistryHelper
    {
        public static readonly string[] Keys = { "counter1Value", "counter2Value" };
        private static readonly string _defaultValue = "0";

        private static void InitializRegistry()
        {
            RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey reg = currentUser.OpenSubKey("SOFTWARE\\Hexzhe\\ExoCounter", true);

            if (reg == null)
                reg = currentUser.CreateSubKey("Software\\Hexzhe\\ExoCounter");

            foreach (string key in Keys)
                if (reg.GetValue(key) == null)
                    reg.SetValue(key, _defaultValue);
        }

        public static (string, string) GetRegistryValues()
        {
            InitializRegistry();

            RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey reg = currentUser.OpenSubKey("SOFTWARE\\Hexzhe\\ExoCounter", true);

            return (reg.GetValue(Keys[0]).ToString(), reg.GetValue(Keys[1]).ToString());
        }

        public static void SaveRegistryValues(params string[] values)
        {
            InitializRegistry();

            RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey reg = currentUser.OpenSubKey("SOFTWARE\\Hexzhe\\ExoCounter", true);

            for (int i = 0; i < Keys.Length; i++)
                reg.SetValue(Keys[i], values[i]);
        }
    }
}
