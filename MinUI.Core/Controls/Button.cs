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
public class Button : NeumorphButtonBase
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

    public static readonly DependencyProperty IsMouseDownProperty = DependencyProperty.Register(
        nameof(IsMouseDown), typeof(bool), typeof(Button), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
        //DefaultStyleKeyProperty.OverrideMetadata(typeof(Button), new FrameworkPropertyMetadata(typeof(Button)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _buttonContainer = GetTemplateChild(ButtonContainerPartName) as FrameworkElement;
    }
}
