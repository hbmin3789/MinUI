using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MinUI.Core.Models.Chart
{
    public class ChartData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties

        private int _x;
        public int X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }

        private int _y;
        public int Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
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
