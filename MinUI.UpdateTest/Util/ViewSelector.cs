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
        private ObservableCollection<BindableBase> _viewModels;
        public ObservableCollection<BindableBase> ViewModels
        {
            get => _viewModels;
            set => SetProperty(ref _viewModels, value);
        }

        public ViewSelector()
        {
            _viewModels = new ObservableCollection<BindableBase>();
        }
    }
}
