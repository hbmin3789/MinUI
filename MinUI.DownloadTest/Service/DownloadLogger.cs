using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.DownloadTest.Service
{
    public class DownloadLogger : BindableBase
    {
        private ObservableCollection<string> _downloadLogs = new ObservableCollection<string>();
        public ObservableCollection<string> DownloadLogs
        {
            get => _downloadLogs;
            set => SetProperty(ref _downloadLogs, value);
        }

        public DownloadLogger() { }

        public void Log(string log)
        {
            DownloadLogs.Add(log);
        }
    }
}
