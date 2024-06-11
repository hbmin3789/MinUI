using MinUI.Core.Utils;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MinUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemeSelector.InitTheme();            
        }
    }

}
