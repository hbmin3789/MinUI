using MinUI.Core.Enummerables;
using MinUI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MinUI.Core.Controls
{
    public class NeumorphBase : ContentControl, INeumorphBase
    {
        public static readonly DependencyProperty ReliefProperty = DependencyProperty.Register(
        nameof(Relief), typeof(ERelief), typeof(NeumorphBase), new FrameworkPropertyMetadata(default(ERelief), FrameworkPropertyMetadataOptions.AffectsArrange));

        public ERelief Relief
        {
            get => (ERelief)GetValue(ReliefProperty);
            set => SetValue(ReliefProperty, value);
        }
    }
}
