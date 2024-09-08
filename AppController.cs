using System.Security;
using WebInfoEditor.Model;

namespace WebInfoEditor
{
    internal class AppController
    {
        private static AppController _instance;
        private MainWindow window;

        public static AppController Instance
        {
            get
            {
                _instance ??= new AppController();
                return _instance;
            }
        }

        private AppController()
        {
            window = new MainWindow();
            window.ExtendsContentIntoTitleBar = true;
            window.Activate();
        }

        public void OnAppStart()
        {
            window.Frame.Navigate(typeof(Pages.ConfigPage));
        }
        
        public void EditJson(string path, SecureString token)
        {
            AzureJsonFile file = new AzureJsonFile(path, token);
        }
    }

}
