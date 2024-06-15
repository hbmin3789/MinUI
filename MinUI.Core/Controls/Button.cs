using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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
        nameof(IsMouseDown), typeof(bool), typeof(Button), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool IsMouseDown
    {
        get => (bool)GetValue(IsMouseDownProperty);
        set => SetValue(IsMouseDownProperty, value);
    }

    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
        nameof(Command), typeof(ICommand), typeof(Button), new FrameworkPropertyMetadata(default(ICommand), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
        nameof(CommandParameter), typeof(object), typeof(Button), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
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

    #region RoutedEvents

    public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Button));

    public event RoutedEventHandler Click
    {
        add { AddHandler(ClickEvent, value); }
        remove { RemoveHandler(ClickEvent, value); }
    }

    void RaiseClickEvent()
    {
        RaiseEvent(new(routedEvent: ClickEvent));
        if (Command.CanExecute(CommandParameter))
        {
            Command.Execute(CommandParameter);
        }
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
        PreviewMouseUp += Button_MouseUp;
    }
    private int _clicked = 0;
    private void Button_MouseUp(object sender, MouseButtonEventArgs e)
    {
        if (IsMouseDown && _clicked < 1)
        {
            RaiseClickEvent();
            _clicked++;
            return;
        }
        _clicked = 0;
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
