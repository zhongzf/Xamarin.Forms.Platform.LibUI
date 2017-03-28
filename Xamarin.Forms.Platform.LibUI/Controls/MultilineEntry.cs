using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class MultilineEntry : Control
    {
        public string Text
        {
            get
            {
                return uiMultilineEntryText(Handle);
            }
            set
            {
                uiMultilineEntrySetText(Handle, value);
            }
        }

        public void Append(string text) => uiMultilineEntryAppend(Handle, text);

        public bool ReadOnly
        {
            get
            {
                return uiMultilineEntryReadOnly(Handle);
            }
            set
            {
                uiMultilineEntrySetReadOnly(Handle, value);
            }
        }

        public event EventHandler<EventArgs> Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public MultilineEntry()
        {
            Handle = uiNewMultilineEntry();
            // Events
            uiMultilineEntryOnChanged(Handle, (f, data) => OnChanged(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
