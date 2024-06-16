using Microsoft.Win32;
using MinUI.DownloadTest.Service;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MinUI.DownloadTest.ViewModel
{
    public class DownloadViewModel : BindableBase
    {
        private DownloadLogger _logger;
        private NetworkManager _networkManager;

        #region Variables

        private bool _isDownloading = false;
        public bool IsDownloading
        {
            get => _isDownloading;
            set=> _isDownloading = value;
        }

        private bool _installBtnVisible = true;
        public bool InstallBtnVisible
        {
            get => _installBtnVisible;
            set => SetProperty(ref _installBtnVisible, value);
        }

        private bool _nextBtnVisible = false;
        public bool NextBtnVisible
        {
            get => _nextBtnVisible;
            set => SetProperty(ref _nextBtnVisible, value);
        }

        private string _filePath = "";
        public string FilePath
        {
            get => _filePath;
            set
            {
                InstallBtnEnabled = value.Length > 0 ? true : false;
                SetProperty(ref _filePath, value);
            }
        }

        private double _downloadProgressValue = 0;
        public double DownloadProgressValue
        {
            get => _downloadProgressValue;
            set => SetProperty(ref _downloadProgressValue, value);
        }

        private bool _installBtnEnabled = false;
        public bool InstallBtnEnabled
        {
            get => _installBtnEnabled;
            set=> SetProperty(ref _installBtnEnabled, value);
        }

        public ObservableCollection<string> DownloadLogs
        {
            get => _logger.DownloadLogs;
        }

        #endregion

        #region Commands
        public DelegateCommand PrevCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand InstallCommand { get; set; }

        public DelegateCommand FileBrowseCommand { get; set; }

        #endregion

        public DownloadViewModel() 
        {
            InitVariables();
            InitCommands();
        }

        private void InitVariables()
        {
            _logger = new DownloadLogger();
            _networkManager = new NetworkManager();
        }

        private void InitCommands()
        {
            InstallCommand = new DelegateCommand(OnInstall);
            FileBrowseCommand = new DelegateCommand(OnFileBrowse);
        }

        private void OnFileBrowse()
        {
            var folderDialog = new OpenFolderDialog();

            if (folderDialog.ShowDialog() == true)
            {
                FilePath = folderDialog.FolderName;
            }

        }

        private async void OnInstall()
        {
            InstallBtnVisible = false;
            _logger.Log("Download Start At : " + FilePath);
            try
            {
                var version = await _networkManager.GetNewVersion();
                _logger.Log($"New Version : {version.Version}");
                DownloadProgressValue += 10;
                await _networkManager.DownloadNewVersion(_logger, FilePath);
                _logger.Log("download complete");
                DownloadProgressValue = 100;
                NextBtnVisible = true;
            }
            catch (Exception ex) 
            {
                _logger.Log(ex.Message);
            }
        }
    }
}
