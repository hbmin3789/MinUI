using MinUI.Test.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.Test.Utils;

public class ViewSelector : BindableBase
{
    private ObservableCollection<BindableBase> _viewmodels;
    public ObservableCollection<BindableBase> Viewmodels
    {
        get => _viewmodels;
        set => SetProperty(ref _viewmodels, value);
    }

    public ViewSelector()
    {

    }

    private void InitVariables()
    {
        Viewmodels = [new MainViewModel(), new ChartViewModel()];
    }
}
