using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class HorizontalBox : Box
    {
        public HorizontalBox()
        {
            Handle = uiNewHorizontalBox();
        }
    }
}
