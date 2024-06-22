using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MinUI.Core;

public class TabContentItem : NeumorphBase
{
    public static readonly DependencyProperty DataTypeProperty = DependencyProperty.Register(
        nameof(DataType), typeof(Type), typeof(TabContentItem), new FrameworkPropertyMetadata(default(Type), FrameworkPropertyMetadataOptions.AffectsArrange));

    public Type DataType
    {
        get => (Type)GetValue(DataTypeProperty);
        set => SetValue(DataTypeProperty, value);
    }
    public TabContentItem()
    {
        
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        var a = this.DataContext;
    }
}
