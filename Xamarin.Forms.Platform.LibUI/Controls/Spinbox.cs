using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Spinbox : Control
    {
        public int Value
        {
            get
            {
                return uiSpinboxValue(Handle);
            }
            set
            {
                uiSpinboxSetValue(Handle, value);
            }
        }

        public event EventHandler<EventArgs> Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public Spinbox(int min, int max)
        {
            Handle = uiNewSpinbox(min, max);
            // Events
            uiSpinboxOnChanged(Handle, (f, data) => OnChanged(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
