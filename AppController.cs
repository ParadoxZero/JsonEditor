using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WebInfoEditor
{
    internal class AppController
    {
        private static AppController _instance;
        private Window window;

        public static AppController GetInstance()
        {
            _instance ??= new AppController();
            return _instance;
        }

        private AppController() { }

        public void OnAppStart()
        {
            window = new Window();
            Frame frame = new Frame();
            window.Content = frame;

            frame.Navigate(typeof(Pages.SettingsPage));
            window.Activate();
        }
    }

}
