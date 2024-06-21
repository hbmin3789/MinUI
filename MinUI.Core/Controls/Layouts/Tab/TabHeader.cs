using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinUI.Core;

public class TabHeader : NeumorphCollectionBase
{
    public static readonly DependencyProperty HeaderItemsProperty = DependencyProperty.Register(
        nameof(HeaderItems), typeof(List<TabHeaderItem>), typeof(TabHeader), new FrameworkPropertyMetadata(default(List<TabHeaderItem>), FrameworkPropertyMetadataOptions.AffectsArrange));

    public List<TabHeaderItem> HeaderItems
    {
        get => (List<TabHeaderItem>)GetValue(HeaderItemsProperty);
        set => SetValue(HeaderItemsProperty, value);
    }
}
