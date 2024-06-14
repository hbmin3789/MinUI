using MinUI.Core.Controls.Animation;
using MinUI.Core.Enummerables;
using MinUI.Core.Interfaces;
using System.Windows;

namespace MinUI.Core;

public class NeumorphBase : AnimationBase, INeumorphBase
{
    public static readonly DependencyProperty ReliefProperty = DependencyProperty.Register(
    nameof(Relief), typeof(ERelief), typeof(NeumorphBase), new FrameworkPropertyMetadata(ERelief.Embossed, FrameworkPropertyMetadataOptions.AffectsArrange));

    public ERelief Relief
    {
        get => (ERelief)GetValue(ReliefProperty);
        set => SetValue(ReliefProperty, value);
    }
}
