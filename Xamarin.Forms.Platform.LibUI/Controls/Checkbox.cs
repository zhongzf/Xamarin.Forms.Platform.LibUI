using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Checkbox : Control
    {
        public string Text
        {
            get
            {
                return uiCheckboxText(Handle);
            }
            set
            {
                uiCheckboxSetText(Handle, value);
            }
        }
        public bool Checked
        {
            get
            {
                return uiCheckboxChecked(Handle);
            }
            set
            {
                uiCheckboxSetChecked(Handle, value);
            }
        }

        public event EventHandler<EventArgs> Toggled;
        protected virtual void OnToggled(EventArgs e)
        {
            Toggled?.Invoke(this, e);
        }

        public Checkbox(string text)
        {
            Handle = uiNewCheckbox(text);
            // Events
            uiCheckboxOnToggled(Handle, (f, data) => OnToggled(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
