using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.DownloadTest.ViewModel
{
    public class CompleteViewModel : BindableBase
    {

        public DelegateCommand CloseCommand { get; set; }

        public CompleteViewModel() 
        {
            InitCommands();
        }

        private void InitCommands()
        {
            CloseCommand = new DelegateCommand(OnClose);
        }

        private void OnClose()
        {
            App.Current.Shutdown();
        }
    }
}
