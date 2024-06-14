using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Input;

namespace MinUI.Core;

public class Accordion : NeumorphBase
{
    public const string HeaderContainerPartName = "PART_HeaderContainer";
    public const string ContentContainerPartName = "PART_ContentContainer";
    protected FrameworkElement? _headerContainer;
    protected FrameworkElement? _contentContainer;
    private readonly string ExpandAnimationStateName = "ExpandAccordion";
    private readonly string CollapseAnimationStateName = "CollapseAccordion";

    #region Dependency Properties
    public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
        nameof(IsExpanded), typeof(bool), typeof(Accordion), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange));

    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    public static readonly DependencyProperty IsMouseDownProperty = DependencyProperty.Register(
        nameof(IsMouseDown), typeof(bool), typeof(Accordion), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange));

    public bool IsMouseDown
    {
        get => (bool)GetValue(IsMouseDownProperty);
        set => SetValue(IsMouseDownProperty, value);
    }

    public static readonly DependencyProperty ContentRenderSizeProperty = DependencyProperty.Register(
        nameof(ContentRenderSize), typeof(Size), typeof(Accordion), new FrameworkPropertyMetadata(default(Size), FrameworkPropertyMetadataOptions.AffectsArrange));

    public Size ContentRenderSize
    {
        get => (Size)GetValue(ContentRenderSizeProperty);
        set => SetValue(ContentRenderSizeProperty, value);
    }

    #endregion

    #region Routed Events

    public static readonly RoutedEvent HeaderClickEvent = EventManager.RegisterRoutedEvent("HeaderClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Accordion));

    public event RoutedEventHandler HeaderClick
    {
        add { AddHandler(HeaderClickEvent, value); }
        remove { RemoveHandler(HeaderClickEvent, value); }
    }

    void RaiseHeaderClickEvent()
    {
        RaiseEvent(new(routedEvent: HeaderClickEvent));
    }


    #endregion

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var a = Content;
        _headerContainer = GetTemplateChild(HeaderContainerPartName) as FrameworkElement;
        _contentContainer = GetTemplateChild(ContentContainerPartName) as FrameworkElement;
        if (_contentContainer != null)
        {
            _contentContainer.Loaded += OnContentLoaded;
            MouseUp += OnHeaderMouseUp;
        }
        HeaderClick += ToggleContent;
    }

    private void ToggleContent(object sender, RoutedEventArgs e)
    {
        var animation = IsExpanded ? CollapseAnimationStateName : ExpandAnimationStateName;
        IsExpanded = !IsExpanded;
        VisualStateManager.GoToState(this, animation, true);
    }

    private void OnHeaderMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (IsMouseDown)
        {
            RaiseHeaderClickEvent();
        }
    }

    private void OnContentLoaded(object sender, RoutedEventArgs e)
    {
        ContentRenderSize = _contentContainer.RenderSize;
    }
}
