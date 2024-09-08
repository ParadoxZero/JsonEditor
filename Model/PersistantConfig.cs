using System;
using System.Collections.Generic;
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
            ProtectedData.Protect(dataBytes, null, DataProtectionScope.CurrentUser);
            ApplicationData.Current.LocalSettings.Values["token"] = dataBytes;
        }

        private static SecureString LoadToken()
        {
            SecureString secureString = new SecureString();
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("EncryptedData", out object encryptedData))
            {
                var decryptedData = ProtectedData.Unprotect((byte[])encryptedData, null, DataProtectionScope.CurrentUser);
                foreach (char c in Encoding.UTF8.GetString(decryptedData))
                {
                    secureString.AppendChar(c);
                }
            }
            return secureString;
        }
    }
}
