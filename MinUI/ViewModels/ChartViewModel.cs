using MinUI.Core.Models.Chart;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.Test.ViewModels;

public class ChartViewModel: BindableBase
{
    private ObservableCollection<BarChartData> _barChartDatas;
    public ObservableCollection<BarChartData> BarChartDatas
    {
        get => _barChartDatas;
        set => SetProperty(ref _barChartDatas, value);
    }

    public ChartViewModel()
    {
        BarChartDatas = [new BarChartData() { XData = "asd", YData = 100 }, new BarChartData() { XData = "asd1", YData = 80 }, new BarChartData() { XData = "asd1", YData = 70 }];
    }
}
