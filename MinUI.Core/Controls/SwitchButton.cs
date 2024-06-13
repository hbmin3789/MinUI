using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MinUI.Core;

[TemplatePart(Name = ButtonContainerPartName, Type = typeof(UIElement))]
public class SwitchButton : NeumorphBase
{
    public const string ButtonContainerPartName = "PART_ButtonContainer";
    public const string SwitchButtonPartName = "PART_SwitchButton";
    protected FrameworkElement? _buttonContainer;
    protected FrameworkElement? _switchButton;

    private bool isMouseDown = false;



    #region Dependency Properties
    public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register(
    nameof(ButtonContent), typeof(object), typeof(SwitchButton), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.AffectsArrange));

    public object ButtonContent
    {
        get => GetValue(ButtonContentProperty);
        set => SetValue(ButtonContentProperty, value);
    }

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
    nameof(Value), typeof(bool), typeof(SwitchButton), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.AffectsArrange, OnValueChanged));

    public bool Value
    {
        get => (bool)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly RoutedEvent SwitchButtonChangedEvent =
    EventManager.RegisterRoutedEvent(
        nameof(SwitchButtonChanged),
        RoutingStrategy.Bubble,
        typeof(RoutedPropertyChangedEventHandler<object>),
        typeof(Button));

    public event RoutedPropertyChangedEventHandler<object> SwitchButtonChanged
    {
        add => AddHandler(SwitchButtonChangedEvent, value);
        remove => RemoveHandler(SwitchButtonChangedEvent, value);
    }

    #endregion

    #region Events

    public static readonly RoutedEvent OnMouseClickEvent = EventManager.RegisterRoutedEvent(nameof(OnMouseClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SwitchButton));
    public event RoutedEventHandler OnMouseClick
    {
        add { AddHandler(OnMouseClickEvent, value); }
        remove { RemoveHandler(OnMouseClickEvent, value); }
    }
    protected void RaiseOnClickEvent()
    {
        RoutedEventArgs newEventArgs = new RoutedEventArgs(OnMouseClickEvent);
        RaiseEvent(newEventArgs);
        Value = !Value;
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        isMouseDown = true;
    }

    protected override void OnMouseLeave(MouseEventArgs e)
    {
        base.OnMouseEnter(e);
        isMouseDown = false;
    }

    // MouseLeftButtonUp 이벤트를 사용하여 Click 이벤트 발생 조건 확인
    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonUp(e);
        if (isMouseDown)
        {
            isMouseDown = false;
            if (IsMouseOver)
            {
                RaiseOnClickEvent();
            }
        }
    }



    #endregion

    static SwitchButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchButton), new FrameworkPropertyMetadata(typeof(SwitchButton)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _buttonContainer = GetTemplateChild(ButtonContainerPartName) as FrameworkElement;
        _switchButton = GetTemplateChild(SwitchButtonPartName) as FrameworkElement;
        
    }

    private static void OnButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (SwitchButton)d;

        var args = new RoutedPropertyChangedEventArgs<object?>(
            e.OldValue,
            e.NewValue)
        {
            RoutedEvent = SwitchButtonChangedEvent
        };
        instance.RaiseEvent(args);
    }

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (SwitchButton)d;
        instance.OnValueChanged();
    }

    public void OnValueChanged()
    {
        if (Value)
        {
            _switchButton.HorizontalAlignment = HorizontalAlignment.Right;
        }
        else
        {
            _switchButton.HorizontalAlignment = HorizontalAlignment.Left;
        }
    }

}
