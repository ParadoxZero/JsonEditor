using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using WebInfoEditor.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebInfoEditor.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfigPage : Page
    {
        public ConfigPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.DataContext == null)
            {
                this.DataContext = new Pages.ConfigPageViewModel();
                SecureString token = ((ConfigPageViewModel)this.DataContext).Token;
                if (token.Length > 0) {
                    this.tokenPasswordBox.Password = token.ToString();
                }
            }
        }

        private void onEditJsonButtonClicked(object sender, RoutedEventArgs e)
        { 
            ((ConfigPageViewModel)this.DataContext)?.SaveConfig();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                SecureString token = new SecureString();
                foreach (char c in ((PasswordBox)sender).Password)
                {
                    token.AppendChar(c);
                }
                ((ConfigPageViewModel)this.DataContext).Token = token;
            }
        }
    }
}
