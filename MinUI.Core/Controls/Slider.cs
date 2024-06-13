using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MinUI.Core;

public class Slider : ContentControl
{
    #region Dependency Properties
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
    nameof(Value), typeof(double), typeof(Slider), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));
    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ProgressBarColorProperty = DependencyProperty.Register(
    nameof(ProgressBarColor), typeof(SolidColorBrush), typeof(Slider), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(0x56, 0xb2, 0xe8)), FrameworkPropertyMetadataOptions.AffectsArrange));

    public SolidColorBrush ProgressBarColor
    {
        get => (SolidColorBrush)GetValue(ProgressBarColorProperty);
        set => SetValue(ProgressBarColorProperty, value);
    }
    #endregion
}
