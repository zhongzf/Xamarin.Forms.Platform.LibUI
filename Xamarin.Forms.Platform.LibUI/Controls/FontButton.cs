using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Drawing;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class FontButton : Control
    {
        public Font Font => new Font(uiFontButtonFont(Handle));

        public event EventHandler<EventArgs> Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public FontButton()
        {
            Handle = uiNewFontButton();
            // Events
            uiFontButtonOnChanged(Handle, (f, data) => OnChanged(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
