using MinUI.Core.Controls.Animation;
using MinUI.Core.Enummerables;
using MinUI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinUI.Core;

public class NeumorphButtonBase : System.Windows.Controls.Button, IAnimatable, INeumorphBase, INotifyPropertyChanged
{
    public TimeSpan AnimationDuration { get; set; }

    public static readonly DependencyProperty ReliefProperty = DependencyProperty.Register(
    nameof(Relief), typeof(ERelief), typeof(NeumorphButtonBase), new FrameworkPropertyMetadata(ERelief.Embossed, FrameworkPropertyMetadataOptions.AffectsArrange));

    public ERelief Relief
    {
        get => (ERelief)GetValue(ReliefProperty);
        set => SetValue(ReliefProperty, value);
    }

    #region BindableBase
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

        storage = value;
        RaisePropertyChanged(propertyName);

        return true;
    }

    protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        PropertyChanged?.Invoke(this, args);
    }

    public void StartAnimation()
    {
        throw new NotImplementedException();
    }
    #endregion
}
