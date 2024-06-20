using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace MinUI.Core.Charts;

internal class XAxis : NeumorphBase
{
    private string BarPartName = "PART_Bar";
    private string ContainerPartName = "PART_Container";
    private Border _bar;
    private Grid _container;

    #region DependencyProperties

    public static readonly DependencyProperty XDataProperty = DependencyProperty.Register(
    nameof(XData), typeof(string), typeof(XAxis), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsArrange));

    public string XData
    {
        get => (string)GetValue(XDataProperty);
        set => SetValue(XDataProperty, value);
    }

    public static readonly DependencyProperty YDataProperty = DependencyProperty.Register(
    nameof(YData), typeof(double), typeof(XAxis), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double YData
    {
        get => (double)GetValue(YDataProperty);
        set => SetValue(YDataProperty, value);
    }

    public static readonly DependencyProperty MaxYDataProperty = DependencyProperty.Register(
    nameof(MaxYData), typeof(double), typeof(XAxis), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double MaxYData
    {
        get => (double)GetValue(MaxYDataProperty);
        set => SetValue(MaxYDataProperty, value);
    }

    public static readonly DependencyProperty GuideLineHeightProperty = DependencyProperty.Register(
    nameof(GuideLineHeight), typeof(double), typeof(XAxis), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double GuideLineHeight
    {
        get => (double)GetValue(GuideLineHeightProperty);
        set => SetValue(GuideLineHeightProperty, value);
    }

    #endregion

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _bar = GetTemplateChild(BarPartName) as Border;
        _container = GetTemplateChild(ContainerPartName) as Grid;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        UpdateHeight();
    }

    public void UpdateHeight()
    {
        if (_bar != null && _container != null)
        {
            var newHeight = (((_container.ActualHeight / MaxYData) * YData) - (GuideLineHeight / 2));
            if(newHeight > 0)
            {
                _bar.Height = newHeight;
            }
        }
    }
}
