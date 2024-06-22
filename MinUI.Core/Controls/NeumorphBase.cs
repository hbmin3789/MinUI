using MinUI.Core.Controls.Animation;
using MinUI.Core.Enummerables;
using MinUI.Core.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MinUI.Core;

public class NeumorphBase : AnimationBase, INeumorphBase, INotifyPropertyChanged
{
    public static readonly DependencyProperty ReliefProperty = DependencyProperty.Register(
    nameof(Relief), typeof(ERelief), typeof(NeumorphBase), new FrameworkPropertyMetadata(ERelief.Embossed, FrameworkPropertyMetadataOptions.AffectsArrange));

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
    #endregion
}
