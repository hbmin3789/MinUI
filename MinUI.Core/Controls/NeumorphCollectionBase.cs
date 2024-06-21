using MinUI.Core.Enummerables;
using MinUI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MinUI.Core;

public class NeumorphCollectionBase : ItemsControl, INeumorphBase
{
    public static readonly DependencyProperty ReliefProperty = DependencyProperty.Register(
    nameof(Relief), typeof(ERelief), typeof(NeumorphCollectionBase), new FrameworkPropertyMetadata(ERelief.Embossed, FrameworkPropertyMetadataOptions.AffectsArrange));

    public ERelief Relief
    {
        get => (ERelief)GetValue(ReliefProperty);
        set => SetValue(ReliefProperty, value);
    }
}
