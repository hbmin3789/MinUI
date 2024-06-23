using MinUI.Demo.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.Demo.Utils;

public class ViewSelector : BindableBase
{
    #region Properties

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

    #endregion

    public ViewSelector()
    {
        InitVariables();
    }

    private void InitVariables()
    {
        ViewModels = [new MainViewModel(), new ButtonsViewModel()];
        CurrentViewModel = ViewModels[1];
    }
}
