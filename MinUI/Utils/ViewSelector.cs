using MinUI.Test.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.Test.Utils;

public class ViewSelector : BindableBase
{
    #region Properties
    private ObservableCollection<BindableBase> _viewmodels;
    public ObservableCollection<BindableBase> ViewModels
    {
        get => _viewmodels;
        set => SetProperty(ref _viewmodels, value);
    }

    private BindableBase _selectedViewModel;
    public BindableBase SelectedViewModel
    {
        get => _selectedViewModel;
        set=>SetProperty(ref _selectedViewModel, value);
    }
    #endregion

    #region Commands

    public DelegateCommand<object> OnClickTabHeaderCommand { get; set; }

    #endregion

    public ViewSelector()
    {
        InitVariables();
        InitCommands();
    }

    private void InitVariables()
    {
        ViewModels = [new MainViewModel(), new ChartViewModel()];
        SelectedViewModel = ViewModels[0];
    }

    private void InitCommands()
    {
        OnClickTabHeaderCommand = new DelegateCommand<object>(OnClickTabHeader);
    }

    private void OnClickTabHeader(object param)
    {
        var value = int.Parse(param.ToString());
        var item = ViewModels.ElementAtOrDefault(value);
        if (item != null)
        {
            SelectedViewModel = item;
        }
    }
}
