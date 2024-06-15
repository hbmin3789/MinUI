using MinUI.UpdateTest.ViewModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.UpdateTest.Util
{
    public class ViewSelector : BindableBase
    {
        #region Variables
        private ObservableCollection<BindableBase> _viewModels;
        public ObservableCollection<BindableBase> ViewModels
        {
            get => _viewModels;
            set => SetProperty(ref _viewModels, value);
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set=> SetProperty(ref _currentViewModel, value);
        }

        private int _viewIndex;
        public int ViewIndex
        {
            get => _viewIndex;
            set {
                if (value < 0 || value >= ViewModels.Count) return;
                SetProperty(ref _viewIndex, value);
                CurrentViewModel = ViewModels[value];
            }
        }
        #endregion

        #region Commands
        
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand PrevCommand { get; set; }

        #endregion

        public ViewSelector()
        {
            InitVariables();
            InitCommands();
        }

        private void InitVariables()
        {
            ViewModels = [new MainViewModel() { NextCommand = new DelegateCommand(OnClickNext)}, new DownloadViewModel(), new CompleteViewModel()];
            ViewIndex = 0;
            CurrentViewModel = ViewModels[ViewIndex];
        }

        private void InitCommands()
        {
            NextCommand = new DelegateCommand(OnClickNext);
            PrevCommand = new DelegateCommand(OnClickPrev);
        }

        public void OnClickNext()
        {
            ViewIndex++;
        }

        public void OnClickPrev()
        {
            ViewIndex--;
        }
    }
}
