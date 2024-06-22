using MinUI.Core.Models.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MinUI.Core.Charts;

public class BarChart : NeumorphBase
{
    private string BackgroundPartName = "PART_Background";
    private string ForegroundPartName = "PART_Foreground";
    private BarChartBackground _background;
    private BarChartForeground _foreground;


    #region DependencyProperty

    public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
        nameof(ItemTemplate), typeof(DataTemplate), typeof(BarChart), new FrameworkPropertyMetadata(default(DataTemplate), FrameworkPropertyMetadataOptions.AffectsArrange));

    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }

    public static readonly DependencyProperty DatasSourceProperty = DependencyProperty.Register(
        nameof(DatasSource), typeof(object), typeof(BarChart), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.AffectsArrange));

    public object DatasSource
    {
        get => GetValue(DatasSourceProperty);
        set => SetValue(DatasSourceProperty, value);
    }

    public static readonly DependencyProperty ToolTipStyleProperty = DependencyProperty.Register(
        nameof(ToolTipStyle), typeof(Style), typeof(BarChart), new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.AffectsArrange));

    public Style ToolTipStyle
    {
        get => (Style)GetValue(ToolTipStyleProperty);
        set => SetValue(ToolTipStyleProperty, value);
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(BarChart), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsArrange));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty GuideLineCountProperty = DependencyProperty.Register(
    nameof(GuideLineCount), typeof(int), typeof(BarChart), new FrameworkPropertyMetadata(4, FrameworkPropertyMetadataOptions.AffectsArrange));

    public int GuideLineCount
    {
        get => (int)GetValue(GuideLineCountProperty);
        set => SetValue(GuideLineCountProperty, value);
    }

    public static readonly DependencyProperty GuideLineHeightProperty = DependencyProperty.Register(
    nameof(GuideLineHeight), typeof(double), typeof(BarChart), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double GuideLineHeight
    {
        get => (double)GetValue(GuideLineHeightProperty);
        set => SetValue(GuideLineHeightProperty, value);
    }

    public static readonly DependencyProperty HeaderHeightProperty = DependencyProperty.Register(
    nameof(HeaderHeight), typeof(GridLength), typeof(BarChart), new FrameworkPropertyMetadata(new GridLength(50), FrameworkPropertyMetadataOptions.AffectsArrange));

    public GridLength HeaderHeight
    {
        get => (GridLength)GetValue(HeaderHeightProperty);
        set => SetValue(HeaderHeightProperty, value);
    }

    #endregion

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _background = GetTemplateChild(BackgroundPartName) as BarChartBackground;
        _foreground = GetTemplateChild(ForegroundPartName) as BarChartForeground;
        
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        GuideLineHeight = _background.GetGuideLineHeight();
        _foreground.OnGuideLineHeightChanged(GuideLineHeight);
    }

    private void BarChart_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        
    }

    public BarChart()
    {

    }

}
