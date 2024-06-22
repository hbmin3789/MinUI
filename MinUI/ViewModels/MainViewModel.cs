using MinUI.Core.Models.Chart;
using MinUI.Core.Utils;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.Test.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        public DelegateCommand OnClickSwitchThemeCommand { get; set; }
        public MainViewModel()
        {
            InitCommands();
        }
        public void InitCommands()
        {
            OnClickSwitchThemeCommand = new DelegateCommand(OnClickSwitchTheme);
        }

        private void OnClickSwitchTheme()
        {
            ThemeSelector.ToggleTheme();
        }
    }
}
