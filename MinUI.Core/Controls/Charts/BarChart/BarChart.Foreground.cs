using MinUI.Core.Models.Chart;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MinUI.Core.Charts;

public class BarChartForeground : NeumorphBase
{
    private string XAxisGridPartName = "PART_XAxisGrid";
    private Grid _xAxisGrid;

    #region DependencyProperties

    public static readonly DependencyProperty GuideLineHeightProperty = DependencyProperty.Register(
    nameof(GuideLineHeight), typeof(double), typeof(BarChartForeground), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double GuideLineHeight
    {
        get => (double)GetValue(GuideLineHeightProperty);
        set => SetValue(GuideLineHeightProperty, value);
    }

    public static readonly DependencyProperty DatasSourceProperty = DependencyProperty.Register(
        nameof(DatasSource), typeof(object), typeof(BarChartForeground), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.AffectsArrange, OnDatasSourceChanged));

    private static void OnDatasSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (BarChartForeground)d;
        instance.UpdateMaxValue();
    }

    public static readonly DependencyProperty HeaderHeightProperty = DependencyProperty.Register(
    nameof(HeaderHeight), typeof(GridLength), typeof(BarChartForeground), new FrameworkPropertyMetadata(new GridLength(50), FrameworkPropertyMetadataOptions.AffectsArrange));

    public GridLength HeaderHeight
    {
        get => (GridLength)GetValue(HeaderHeightProperty);
        set => SetValue(HeaderHeightProperty, value);
    }

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

    private XAxis GetNewXAxis(object dataSource)
    {
        var retval = new XAxis();
        var yBinding = new Binding("YData");
        yBinding.Source = dataSource;
        var xBinding = new Binding("XData");
        xBinding.Source = dataSource;
        retval.SetBinding(XAxis.YDataProperty, yBinding);
        retval.SetBinding(XAxis.XDataProperty, xBinding);
        retval.DataContext = dataSource;
        return retval;
    }

    private void UpdateMaxValue()
    {
        UpdateXAxis();
    }

    public void OnGuideLineHeightChanged(double guideLineHeight)
    {
        GuideLineHeight = guideLineHeight;
        foreach (XAxis item in _xAxisGrid.Children)
        {
            item.GuideLineHeight = GuideLineHeight;
        }
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        UpdateXAxis();
    }

    private void UpdateXAxis()
    {
        _xAxisGrid = GetTemplateChild(XAxisGridPartName) as Grid;
        if (_xAxisGrid != null)
        {
            _xAxisGrid.ColumnDefinitions.Clear();
            _xAxisGrid.Children.Clear();
            var datasSource = (DatasSource as IEnumerable<BarChartData>).ToList();
            var max = datasSource.Max(data => data.YData);
            var columns = GetColumns(datasSource.Count);
            for (int i = 0; i < columns.Count; i++)
            {
                _xAxisGrid.ColumnDefinitions.Add(columns[i]);
                var newItem = GetNewXAxis(datasSource[i]);
                newItem.MaxYData = max;
                Grid.SetColumn(newItem, i);
                _xAxisGrid.Children.Add(newItem);
            }
        }
    }
}
