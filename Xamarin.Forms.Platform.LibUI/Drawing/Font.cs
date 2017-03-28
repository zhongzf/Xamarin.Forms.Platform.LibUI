using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Interop;

namespace Xamarin.Forms.Platform.LibUI.Drawing
{
    public class Font : InteropObject
    {
        internal Font(IntPtr handle)
        {
            Handle = handle;
        }
    }
}
