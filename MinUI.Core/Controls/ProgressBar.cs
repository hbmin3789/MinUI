using MinUI.Core.Enummerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MinUI.Core;

[TemplatePart(Name = ProgressBarContainerPartName, Type = typeof(UIElement))]
public class ProgressBar : NeumorphBase
{
    public const string ProgressBarContainerPartName = "PART_ProgressBarContainer";
    public const string progressBarPartName = "progressBar";
    protected FrameworkElement? _progressBarContainer;
    protected FrameworkElement? _progressBar;
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _progressBarContainer = GetTemplateChild(ProgressBarContainerPartName) as FrameworkElement;
        _progressBar = GetTemplateChild(progressBarPartName) as FrameworkElement;
        UpdateProgressBarWidth();
    }

    #region Dependency Properties
    public static readonly DependencyProperty ProgressBarContentProperty = DependencyProperty.Register(
    nameof(ProgressBarContent), typeof(object), typeof(ProgressBar), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.AffectsArrange));

    public object ProgressBarContent
    {
        get => GetValue(ProgressBarContentProperty);
        set => SetValue(ProgressBarContentProperty, value);
    }

    public static readonly DependencyProperty ProgressTypeProperty = DependencyProperty.Register(
    nameof(ProgressType), typeof(EProgressType), typeof(ProgressBar), new FrameworkPropertyMetadata(default(EProgressType), FrameworkPropertyMetadataOptions.AffectsArrange));

    public EProgressType ProgressType
    {
        get => (EProgressType)GetValue(ProgressTypeProperty);
        set => SetValue(ProgressTypeProperty, value);
    }

    public static readonly DependencyProperty ProgressBarColorProperty = DependencyProperty.Register(
    nameof(ProgressBarColor), typeof(SolidColorBrush), typeof(ProgressBar), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(0x56, 0xb2, 0xe8)), FrameworkPropertyMetadataOptions.AffectsArrange));

    public SolidColorBrush ProgressBarColor
    {
        get => (SolidColorBrush)GetValue(ProgressBarColorProperty);
        set => SetValue(ProgressBarColorProperty, value);
    }

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
    nameof(Value), typeof(double), typeof(ProgressBar), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange, OnValueChanged));

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (ProgressBar)d;
        if (instance.ProgressType == EProgressType.Horizontal)
        {
            instance.UpdateProgressBarWidth();
        }
    }

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    #endregion

    static ProgressBar()
    {
        
    }

    private void UpdateProgressBarWidth()
    {
        if (_progressBar != null)
        {
            var percent = Value / ActualWidth;
            _progressBar.Width = ActualWidth * percent;
        }
    }

}
