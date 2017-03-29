using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Drawing;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class ColorButton : Control
    {
        public Drawing.Color Color
        {
            get
            {
                uiColorButtonColor(Handle, out double r, out double g, out double b, out double a);
                return new Drawing.Color(r, g, b, a);
            }
            set
            {
                uiColorButtonSetColor(Handle, value.R, value.G, value.B, value.A);
            }
        }

        public event EventHandler<EventArgs> Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public ColorButton()
        {
            Handle = uiNewColorButton();
            // Events
            uiColorButtonOnChanged(Handle, (f, data) => OnChanged(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
