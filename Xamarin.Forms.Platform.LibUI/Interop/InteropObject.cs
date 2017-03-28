using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Platform.LibUI.Interop
{
    public abstract class InteropObject
    {
        protected internal IntPtr Handle { get; protected set; }
    }
}
