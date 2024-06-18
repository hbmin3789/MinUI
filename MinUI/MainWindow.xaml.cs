using MinUI.Core.Enummerables;
using MinUI.Core.Utils;
using MinUI.Test.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewmodel = new MainViewModel();
            this.DataContext = viewmodel;
            bc.DatasSource = viewmodel.BarChartDatas.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThemeSelector.ToggleTheme();
        }
    }
}