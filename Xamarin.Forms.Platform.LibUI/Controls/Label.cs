using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Label : Control
    {
        public string Text
        {
            get
            {
                return uiLabelText(Handle);
            }
            set
            {
                uiLabelSetText(Handle, value);
            }
        }
        public Label(string text)
        {
            Handle = uiNewLabel(text);
        }
    }
}
