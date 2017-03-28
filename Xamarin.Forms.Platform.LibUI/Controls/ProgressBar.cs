using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class ProgressBar : Control
    {
        public int Value
        {
            get
            {
                return uiProgressBarValue(Handle);
            }
            set
            {
                uiProgressBarSetValue(Handle, value);
            }
        }

        public ProgressBar()
        {
            Handle = uiNewProgressBar();
        }
    }
}
