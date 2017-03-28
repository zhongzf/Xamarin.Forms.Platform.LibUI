using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Drawing;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class ScrollingArea : Area
    {
        public ScrollingArea(AreaHandler areaHandler, int width, int height)
        {
            Handle = uiNewScrollingArea(areaHandler.Handle, width, height);
        }
    }
}
