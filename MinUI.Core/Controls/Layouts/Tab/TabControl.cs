using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MinUI.Core;

public class TabControl : NeumorphCollectionBase
{
    static TabControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TabControl), new FrameworkPropertyMetadata(typeof(TabControl)));
    }

    public static readonly DependencyProperty TabHeaderProperty = DependencyProperty.Register(
        nameof(TabHeader), typeof(List<TabHeaderItem>), typeof(TabControl), new FrameworkPropertyMetadata(new List<TabHeaderItem>(), FrameworkPropertyMetadataOptions.AffectsArrange));

    public List<TabHeaderItem> TabHeader
    {
        get => (List<TabHeaderItem>)GetValue(TabHeaderProperty);
        set => SetValue(TabHeaderProperty, value);
    }

    public static readonly DependencyProperty TabContentItemsProperty = DependencyProperty.Register(
        nameof(TabContentItems), typeof(List<TabContentItem>), typeof(TabControl), new FrameworkPropertyMetadata(new List<TabContentItem>(), FrameworkPropertyMetadataOptions.AffectsArrange));

    public List<TabContentItem> TabContentItems
    {
        get => (List<TabContentItem>)GetValue(TabContentItemsProperty);
        set => SetValue(TabContentItemsProperty, value);
    }

    public static readonly DependencyProperty DefaultTypeProperty = DependencyProperty.Register(
        nameof(DefaultType), typeof(Type), typeof(TabControl), new FrameworkPropertyMetadata(default(Type), FrameworkPropertyMetadataOptions.AffectsArrange));

    public Type DefaultType
    {
        get => (Type)GetValue(DefaultTypeProperty);
        set => SetValue(DefaultTypeProperty, value);
    }

    public TabControl()
    {
        
    }
}

