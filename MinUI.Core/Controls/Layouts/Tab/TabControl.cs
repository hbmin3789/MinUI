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

    #region DependencyProperties

    public static readonly DependencyProperty HeaderItemsProperty = DependencyProperty.Register(
        nameof(HeaderItems), typeof(List<TabHeaderItem>), typeof(TabControl), new FrameworkPropertyMetadata(new List<TabHeaderItem>(), FrameworkPropertyMetadataOptions.AffectsArrange));

    public List<TabHeaderItem> HeaderItems
    {
        get => (List<TabHeaderItem>)GetValue(HeaderItemsProperty);
        set => SetValue(HeaderItemsProperty, value);
    }

    public static readonly DependencyProperty HeaderWidthProperty = DependencyProperty.Register(
        nameof(HeaderWidth), typeof(GridLength), typeof(TabControl), new FrameworkPropertyMetadata(default(GridLength), FrameworkPropertyMetadataOptions.AffectsArrange));

    public GridLength HeaderWidth
    {
        get => (GridLength)GetValue(HeaderWidthProperty);
        set => SetValue(HeaderWidthProperty, value);
    }

    public static readonly DependencyProperty HeaderHeightProperty = DependencyProperty.Register(
        nameof(HeaderHeight), typeof(GridLength), typeof(TabControl), new FrameworkPropertyMetadata(default(GridLength), FrameworkPropertyMetadataOptions.AffectsArrange));

    public GridLength HeaderHeight
    {
        get => (GridLength)GetValue(HeaderHeightProperty);
        set => SetValue(HeaderHeightProperty, value);
    }

    public static readonly DependencyProperty TabContentItemsProperty = DependencyProperty.Register(
        nameof(TabContentItems), typeof(List<TabContentItem>), typeof(TabControl), new FrameworkPropertyMetadata(new List<TabContentItem>(), FrameworkPropertyMetadataOptions.AffectsArrange));

    public List<TabContentItem> TabContentItems
    {
        get => (List<TabContentItem>)GetValue(TabContentItemsProperty);
        set => SetValue(TabContentItemsProperty, value);
    }

    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
        nameof(SelectedItem), typeof(object), typeof(TabControl), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

    private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var inst = (TabControl)d;
        inst.UpdateContent();
    }

    [Bindable(true,BindingDirection.TwoWay)]
    public object SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content), typeof(object), typeof(TabControl), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

    public object Content
    {
        get => (object)GetValue(ContentProperty);
    }

    #endregion

    public TabControl()
    {
        
    }

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        UpdateContent();
    }

    private void UpdateContent()
    {
        var item = TabContentItems.Where(x => x.DataType == SelectedItem.GetType()).FirstOrDefault();
        if (item != null)
        {
            SetValue(ContentProperty, item);
        }
    }
}

