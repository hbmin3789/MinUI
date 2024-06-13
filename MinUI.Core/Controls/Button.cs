using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace MinUI.Core;


[TemplatePart(Name = ButtonContainerPartName, Type = typeof(UIElement))]
public class Button : NeumorphBase
{
    public const string ButtonContainerPartName = "PART_ButtonContainer";
    protected FrameworkElement? _buttonContainer;

    #region DependencyProperties
    public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register(
        nameof(ButtonContent), typeof(object), typeof(Button), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.AffectsArrange));

    public object ButtonContent
    {
        get => GetValue(ButtonContentProperty);
        set => SetValue(ButtonContentProperty, value);
    }

    public static readonly DependencyProperty HorizontalContentAlignmentProperty = DependencyProperty.Register(
        nameof(HorizontalContentAlignment), typeof(HorizontalAlignment), typeof(Button), new FrameworkPropertyMetadata(HorizontalAlignment.Center, FrameworkPropertyMetadataOptions.AffectsArrange));

    public HorizontalAlignment HorizontalContentAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty);
        set => SetValue(HorizontalContentAlignmentProperty, value);
    }

    public static readonly DependencyProperty VerticalContentAlignmentProperty = DependencyProperty.Register(
        nameof(VerticalContentAlignment), typeof(VerticalAlignment), typeof(Button), new FrameworkPropertyMetadata(VerticalAlignment.Center, FrameworkPropertyMetadataOptions.AffectsArrange));

    public VerticalAlignment VerticalContentAlignment
    {
        get => (VerticalAlignment)GetValue(VerticalContentAlignmentProperty);
        set => SetValue(VerticalContentAlignmentProperty, value);
    }

    public static readonly DependencyProperty IsMouseDownProperty = DependencyProperty.Register(
        nameof(IsMouseDown), typeof(bool), typeof(Button), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange,OnIsMouseDownChanged));

    private static void OnIsMouseDownChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (Button)d;
    }

    public bool IsMouseDown
    {
        get => (bool)GetValue(IsMouseDownProperty);
        set => SetValue(IsMouseDownProperty, value);
    }

    public static readonly RoutedEvent ButtonChangedEvent =
    EventManager.RegisterRoutedEvent(
        nameof(ButtonChanged),
        RoutingStrategy.Bubble,
        typeof(RoutedPropertyChangedEventHandler<object>),
        typeof(Button));

    public event RoutedPropertyChangedEventHandler<object> ButtonChanged
    {
        add => AddHandler(ButtonChangedEvent, value);
        remove => RemoveHandler(ButtonChangedEvent, value);
    }
    #endregion

    static Button()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Button), new FrameworkPropertyMetadata(typeof(Button)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _buttonContainer = GetTemplateChild(ButtonContainerPartName) as FrameworkElement;
    }

    private static void OnButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (Button)d;
        var args = new RoutedPropertyChangedEventArgs<object?>(
            e.OldValue,
            e.NewValue)
        {
            RoutedEvent = ButtonChangedEvent
        };
        instance.RaiseEvent(args);
    }

}
