using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MinUI.Core.Models.Chart
{
    public class ChartData<X,Y> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties

        private X _xData;
        public X XData
        {
            get => _xData;
            set => SetProperty(ref _xData, value);
        }

        private Y _yData;
        public Y YData
        {
            get => _yData;
            set => SetProperty(ref _yData, value);
        }

        #endregion

        public ChartData() { }

        public void SetProperty<T>(ref T property, T value)
        {
            property = value;
            OnPropertyChanged(nameof(property));
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
