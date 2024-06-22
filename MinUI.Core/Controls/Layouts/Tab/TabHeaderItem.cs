using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MinUI.Core;

public class TabHeaderItem : NeumorphButtonBase
{

    #region DependencyProperties

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(object), typeof(TabHeaderItem), new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.AffectsArrange));

    public object Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }



    #endregion


    public TabHeaderItem()
    {
    }


    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    }
}
