using Microsoft.UI.Xaml;

namespace WebInfoEditor
{
    internal class AppController
    {
        private static AppController _instance;
        private MainWindow window;

        public static AppController GetInstance()
        {
            _instance ??= new AppController();
            return _instance;
        }

        private AppController() { }

        public void OnAppStart()
        {
            window = new MainWindow();
            window.Activate();
        }
    }

}
