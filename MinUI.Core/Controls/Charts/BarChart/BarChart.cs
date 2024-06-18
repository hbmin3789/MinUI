using MinUI.Core.Models.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinUI.Core.Charts;

public class BarChart : NeumorphBase
{
    #region DependencyProperty

    public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
        nameof(ItemTemplate), typeof(DataTemplate), typeof(BarChart), new FrameworkPropertyMetadata(default(DataTemplate), FrameworkPropertyMetadataOptions.AffectsArrange));

    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }

    public static readonly DependencyProperty DatasSourceProperty = DependencyProperty.Register(
        nameof(DatasSource), typeof(List<BarChartData>), typeof(BarChart), new FrameworkPropertyMetadata(default(List<BarChartData>), FrameworkPropertyMetadataOptions.AffectsArrange));

    public List<BarChartData> DatasSource
    {
        get => (List<BarChartData>)GetValue(DatasSourceProperty);
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

    #endregion

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    }
}
