using MinUI.Core.Models.Chart;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MinUI.Core.Charts;

public class BarChartForeground : NeumorphBase
{
    private string GuideLineBackgroundPartName = "PART_ContentGrid";
    private string XAxisGridPartName = "PART_XAxisGrid";
    private FrameworkElement _contentGrid;
    private Grid _xAxisGrid;

    #region DependencyProperties

    public static readonly DependencyProperty GuideLineHeightProperty = DependencyProperty.Register(
    nameof(GuideLineHeight), typeof(double), typeof(BarChartForeground), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double GuideLineHeight
    {
        get => (double)GetValue(GuideLineHeightProperty);
        set => SetValue(GuideLineHeightProperty, value);
    }

    public static readonly DependencyProperty XAxisHeightProperty = DependencyProperty.Register(
    nameof(XAxisHeight), typeof(double), typeof(BarChartForeground), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double XAxisHeight
    {
        get => (double)GetValue(XAxisHeightProperty);
        set => SetValue(XAxisHeightProperty, value);
    }

    public static readonly DependencyProperty DatasSourceProperty = DependencyProperty.Register(
        nameof(DatasSource), typeof(object), typeof(BarChartForeground), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.AffectsArrange));

    public object DatasSource
    {
        get => (object)GetValue(DatasSourceProperty);
        set => SetValue(DatasSourceProperty, value);
    }

    #endregion

    public BarChartForeground()
    {
        
    }

    private List<ColumnDefinition> GetColumns(int count)
    {
        var columns = new List<ColumnDefinition>();
        for(int i = 0; i < count; i++)
        {
            columns.Add(new ColumnDefinition() { Width = new GridLength(1,GridUnitType.Star) });
        }
        return columns;
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _contentGrid = GetTemplateChild(GuideLineBackgroundPartName) as FrameworkElement;
        _xAxisGrid = GetTemplateChild(XAxisGridPartName) as Grid;
        if (_xAxisGrid != null)
        {
            var datasSource = (DatasSource as IEnumerable<object>).ToList();
            var columns = GetColumns(datasSource.Count);
            for(int i=0; i<columns.Count; i++)
            {
                _xAxisGrid.ColumnDefinitions.Add(columns[i]);
                var newItem = new XAxis();
                newItem.DataContext = datasSource[i];
                newItem.SetBinding(XAxis.ValueProperty, "XData");
                Grid.SetColumn(newItem, i);
                _xAxisGrid.Children.Add(newItem);
            }
        }
    }
}
