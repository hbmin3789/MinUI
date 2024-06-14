using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MinUI.Core.Controls.Animation;

public class AnimationBase : ContentControl, IAnimatable
{
    public TimeSpan AnimationDuration { get; set; }

    public void StartAnimation()
    {
        
    }
}
