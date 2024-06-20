using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinUI.Core.Charts;

internal class YAxis : NeumorphBase
{
    #region DependencyProperties

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
    nameof(Value), typeof(string), typeof(YAxis), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsArrange));

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    #endregion
}
