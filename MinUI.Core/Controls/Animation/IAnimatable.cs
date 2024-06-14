using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinUI.Core.Controls.Animation;

interface IAnimatable
{
    void StartAnimation();
    TimeSpan AnimationDuration { get; set; }
}
