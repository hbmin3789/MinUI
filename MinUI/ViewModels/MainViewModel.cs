using MinUI.Core.Models.Chart;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.Test.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        private ObservableCollection<BarChartData<string>> _barChartDatas;
        public ObservableCollection<BarChartData<string>> BarChartDatas
        {
            get => _barChartDatas;
            set => SetProperty(ref _barChartDatas, value);
        }

        public MainViewModel()
        {
            BarChartDatas = [new BarChartData<string>() { XData="asd", YData=100 }, new BarChartData<string>() { XData="asd1", YData = 80 }, new BarChartData<string>() { XData = "asd1", YData = 70 }];
        }
    }
}
