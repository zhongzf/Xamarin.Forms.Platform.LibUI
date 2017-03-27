using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Interop;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI
{
    public class Button : Control
    {
        public string Text
        {
            get
            {
                return uiButtonText(Handle);
            }
            set
            {
                uiButtonSetText(Handle, value);
            }
        }
        
        public event EventHandler<EventArgs> Clicked;
        protected virtual void OnClicked(EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }
        
        public Button(string text)
        {
            Handle = uiNewButton(text);
            // Events
            uiButtonOnClicked(Handle, (f, data) => OnClicked(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
