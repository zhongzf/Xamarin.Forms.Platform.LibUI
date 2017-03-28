using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class HorizontalSeparator : Control
    {
        public HorizontalSeparator()
        {
            Handle = uiNewHorizontalSeparator();
        }
    }
}
