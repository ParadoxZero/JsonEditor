using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WebInfoEditor.Model;

namespace WebInfoEditor.Pages
{
    internal class ConfigPageViewModel
    {
        private PersistantConfig config;

        public ConfigPageViewModel()
        {
            config = PersistantConfig.LoadConfig();
        }

        public SecureString Token
        {
            get => config.token;
            set => config.token = value;
        }

        public string LastOpenedFile
        {
            get => config.lastOpenedFile;
            set => config.lastOpenedFile = value;
        }

        public IEnumerable<string> OpenedFiles
        {
            get => config.openedFiles;
            set => config.openedFiles = value;
        }

        public void SaveConfig()
        {
            PersistantConfig.SetConfig(config);
        }
    }
}
