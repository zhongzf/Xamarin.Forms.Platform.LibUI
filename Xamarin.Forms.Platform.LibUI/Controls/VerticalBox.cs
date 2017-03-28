using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class VerticalBox : Box
    {
        public VerticalBox()
        {
            Handle = uiNewVerticalBox();
        }
    }
}
