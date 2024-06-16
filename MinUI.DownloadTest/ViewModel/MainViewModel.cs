using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.DownloadTest.ViewModel
{
    public class MainViewModel : BindableBase
    {
        #region Variables
        private string _version = "1.0";
        public string Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }
        #endregion

        #region DelegateCommand

        public DelegateCommand NextCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            
        }
    }
}
