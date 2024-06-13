using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MinUI.Core;

public class Slider : ContentControl
{
    private readonly string _sliderButtonName = "SliderButton";
    private readonly string _sliderBarName = "SliderBar";
    private readonly string _sliderBackgroundName = "SliderBackground";
    private System.Windows.Controls.Button _sliderButton;
    private Border _sliderBar;
    private Border _sliderBackground;
    private Point _previousPosition;

    #region Dependency Properties
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
    nameof(Value), typeof(double), typeof(Slider), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsArrange));

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
    nameof(MaxValue), typeof(double), typeof(Slider), new FrameworkPropertyMetadata(100.0d, FrameworkPropertyMetadataOptions.AffectsArrange));

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
    nameof(MinValue), typeof(double), typeof(Slider), new FrameworkPropertyMetadata(0.0d, FrameworkPropertyMetadataOptions.AffectsArrange));

    public double MinValue
    {
        get => (double)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public static readonly DependencyProperty ProgressBarColorProperty = DependencyProperty.Register(
    nameof(ProgressBarColor), typeof(SolidColorBrush), typeof(Slider), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(0x56, 0xb2, 0xe8)), FrameworkPropertyMetadataOptions.AffectsArrange));

    public SolidColorBrush ProgressBarColor
    {
        get => (SolidColorBrush)GetValue(ProgressBarColorProperty);
        set => SetValue(ProgressBarColorProperty, value);
    }

    public static readonly DependencyProperty ToolTipVisibilityProperty = DependencyProperty.Register(
    nameof(ToolTipVisibility), typeof(Visibility), typeof(Slider), new FrameworkPropertyMetadata(Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsArrange));

    public Visibility ToolTipVisibility
    {
        get => (Visibility)GetValue(ToolTipVisibilityProperty);
        set => SetValue(ToolTipVisibilityProperty, value);
    }

    public static readonly DependencyProperty IsMouseDownProperty = DependencyProperty.Register(
    nameof(IsMouseDown), typeof(bool), typeof(Slider), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange));

    public bool IsMouseDown
    {
        get => (bool)GetValue(IsMouseDownProperty);
        set => SetValue(IsMouseDownProperty, value);
    }
    #endregion

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _sliderButton = GetTemplateChild(_sliderButtonName) as System.Windows.Controls.Button;
        _sliderBar = GetTemplateChild(_sliderBarName) as Border;
        _sliderBackground = GetTemplateChild(_sliderBackgroundName) as Border;
        if (_sliderBackground != null && _sliderButton != null)
        {
            SetMouseUpTemplate();
            _sliderButton.PreviewMouseDown += (object sender, MouseButtonEventArgs e) => SetMouseDownTemplate();
            _sliderButton.PreviewMouseUp += (object sender, MouseButtonEventArgs e) => SetMouseUpTemplate();
            _sliderBackground.MouseLeave += (object sender, MouseEventArgs e) => SetMouseUpTemplate();
            _sliderBackground.PreviewMouseDown += OnMouseDown;
            _sliderBackground.PreviewMouseUp += (object sender, MouseButtonEventArgs e) => SetMouseUpTemplate();
        }
        this.MouseMove += Slider_MouseMove;
    }

    private void Slider_MouseMove(object sender, MouseEventArgs e)
    {
        Point currentPosition = e.GetPosition(this);
        if (IsMouseOver && IsMouseDown)
        {
            double prevX = (Width * Value) / (MaxValue - MinValue);
            double deltaX = currentPosition.X - _previousPosition.X;
            Value += (deltaX / Width) * (MaxValue - MinValue);
        }
        _previousPosition = currentPosition;
    }

    private void SetMouseDownTemplate()
    {
        IsMouseDown = true;
        _sliderButton.Template = Application.Current.Resources["MouseDownSliderButtonTemplate"] as ControlTemplate;
    }

    private void SetMouseUpTemplate()
    {
        IsMouseDown = false;
        _sliderButton.Template = Application.Current.Resources["DefaultSliderButtonTemplate"] as ControlTemplate;
    }
    private void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        SetMouseDownTemplate();
        var position = e.GetPosition(this);
        Value = ((MaxValue - MinValue) / 100) * (position.X / (Width / 100));
    }
}
