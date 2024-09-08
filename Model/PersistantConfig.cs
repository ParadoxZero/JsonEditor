using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WebInfoEditor.Model
{
    internal class PersistantConfig
    {
        public string lastOpenedFile;
        public IEnumerable<string> openedFiles;
        public SecureString token;

        public static PersistantConfig LoadConfig()
        {
            PersistantConfig config = new();

            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("lastOpenedFile", out object lastOpenedFile))
            {
                config.lastOpenedFile = (string)lastOpenedFile;
            }

            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("openedFiles", out object openedFiles))
            {
                config.openedFiles = (List<string>)openedFiles;
            }

            config.token = LoadToken();

            return config;
        }

        public static void SetConfig(PersistantConfig config)
        {
            ApplicationData.Current.LocalSettings.Values["lastOpenedFile"] = config.lastOpenedFile;
            ApplicationData.Current.LocalSettings.Values["openedFiles"] = config.openedFiles;
            SaveToken(config.token);
        }

        private static void SaveToken(SecureString token)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(token.ToString());
            byte[] encryptedBytes = ProtectedData.Protect(dataBytes, null, DataProtectionScope.CurrentUser); ;
            string encryptedData = Convert.ToBase64String(encryptedBytes);
            ApplicationData.Current.LocalSettings.Values["token"] = encryptedData;
        }

        private static SecureString LoadToken()
        {
            SecureString secureString = new SecureString();
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("token", out object encryptedData))
            {
                try
                {
                    string dataString = (string)encryptedData;
                    var decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(dataString), null, DataProtectionScope.CurrentUser);
                    foreach (char c in Encoding.UTF8.GetString(decryptedData))
                    {
                        secureString.AppendChar(c);
                    }
                } catch (CryptographicException)
                {
                    // Invalid data, ignore
                }
            }
            return secureString;
        }
    }
}
