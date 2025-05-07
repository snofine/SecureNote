using System.Windows;

namespace SecureNote
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var authWindow = new AuthWindow();
            authWindow.Show();
        }
    }
} 