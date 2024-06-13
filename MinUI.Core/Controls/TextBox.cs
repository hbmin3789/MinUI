using MinUI.Core.Enummerables;
using MinUI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinUI.Core;

public class TextBox : System.Windows.Controls.TextBox, INeumorphBase
{

    public static readonly DependencyProperty ReliefProperty = DependencyProperty.Register(
    nameof(Relief), typeof(ERelief), typeof(TextBox), new FrameworkPropertyMetadata(default(ERelief), FrameworkPropertyMetadataOptions.AffectsArrange));

    public ERelief Relief
    {
        get => (ERelief)GetValue(ReliefProperty);
        set => SetValue(ReliefProperty, value);
    }

    static TextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBox), new FrameworkPropertyMetadata(typeof(TextBox)));
    }
}
