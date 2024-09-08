using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using WebInfoEditor.Model;
using Windows.Storage;

namespace WebInfoEditor
{
    internal class AppController
    {
        private static AppController _instance;
        private Window window;
        private Frame frame;

        public static AppController GetInstance()
        {
            _instance ??= new AppController();
            return _instance;
        }

        private AppController()
        {
            window = new Window();
            frame = new Frame();
            window.Content = frame;
            window.SystemBackdrop = new MicaBackdrop();
            window.Activate();
        }

        public void OnAppStart()
        {
            frame.Navigate(typeof(Pages.ConfigPage));
        }
    }

}
