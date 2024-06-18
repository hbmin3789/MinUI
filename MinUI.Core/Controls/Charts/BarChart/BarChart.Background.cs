using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MinUI.Core.Charts;

public class BarChartBackground : NeumorphBase
{
    private string GuideLineBackgroundPartName = "PART_GuideLineBackground";
    private StackPanel _guideLineBackground;

    #region DependencyProperties

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
    nameof(Title), typeof(string), typeof(BarChartBackground), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsArrange));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty AxisVisibilityProperty = DependencyProperty.Register(
    nameof(AxisVisibility), typeof(Visibility), typeof(BarChartBackground), new FrameworkPropertyMetadata(default(Visibility), FrameworkPropertyMetadataOptions.AffectsArrange));

    public Visibility AxisVisibility
    {
        get => (Visibility)GetValue(AxisVisibilityProperty);
        set => SetValue(AxisVisibilityProperty, value);
    }

    public static readonly DependencyProperty HeaderHeightProperty = DependencyProperty.Register(
    nameof(HeaderHeight), typeof(GridLength), typeof(BarChartBackground), new FrameworkPropertyMetadata(new GridLength(50), FrameworkPropertyMetadataOptions.AffectsArrange));

    public GridLength HeaderHeight
    {
        get => (GridLength)GetValue(HeaderHeightProperty);
        set => SetValue(HeaderHeightProperty, value);
    }

    public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
    nameof(MaxValue), typeof(double), typeof(BarChartBackground), new FrameworkPropertyMetadata(100d, FrameworkPropertyMetadataOptions.AffectsArrange));

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public static readonly DependencyProperty GuidLineVisibilityProperty = DependencyProperty.Register(
    nameof(GuidLineVisibility), typeof(Visibility), typeof(BarChartBackground), new FrameworkPropertyMetadata(default(Visibility), FrameworkPropertyMetadataOptions.AffectsArrange));

    public Visibility GuidLineVisibility
    {
        get => (Visibility)GetValue(GuidLineVisibilityProperty);
        set => SetValue(GuidLineVisibilityProperty, value);
    }

    public static readonly DependencyProperty AxisFormatterProperty = DependencyProperty.Register(
    nameof(AxisFormatter), typeof(string), typeof(BarChartBackground), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsArrange));

    public string AxisFormatter
    {
        get => (string)GetValue(AxisFormatterProperty);
        set => SetValue(AxisFormatterProperty, value);
    }

    public static readonly DependencyProperty GuideLineCountProperty = DependencyProperty.Register(
    nameof(GuideLineCount), typeof(int), typeof(BarChartBackground), new FrameworkPropertyMetadata(4, FrameworkPropertyMetadataOptions.AffectsArrange));

    public int GuideLineCount
    {
        get => (int)GetValue(GuideLineCountProperty);
        set => SetValue(GuideLineCountProperty, value);
    }

    public static readonly DependencyProperty GuideLineHeightProperty = DependencyProperty.Register(
    nameof(GuideLineHeight), typeof(double), typeof(BarChartBackground), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double GuideLineHeight
    {
        get => (double)GetValue(GuideLineHeightProperty);
        set => SetValue(GuideLineHeightProperty, value);
    }
    #endregion

    public BarChartBackground()
    {
        SizeChanged += BarChartBackground_SizeChanged;
    }

    private void BarChartBackground_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        AddGuidLine();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _guideLineBackground = GetTemplateChild(GuideLineBackgroundPartName) as StackPanel;
    }

    public void AddGuidLine()
    {
        var guideLineHeight = (ActualHeight - HeaderHeight.Value) / (GuideLineCount + 1);
        GuideLineHeight = guideLineHeight;
        if (_guideLineBackground?.Children.Count == 0 && ActualHeight > 0)
        {
            double dec = 1d / GuideLineCount;
            Binding heightBinding = new Binding("GuideLineHeight")
            {
                Source = this,
                Mode = BindingMode.OneWay,
            };
            for (int i = 0; i <= GuideLineCount; i++)
            {
                var newAxis = new YAxis() { Value = $"{MaxValue * (1 - i * dec)}" };
                newAxis.SetBinding(YAxis.HeightProperty, heightBinding);
                _guideLineBackground.Children.Add(newAxis);
            }
        }
    }
}
