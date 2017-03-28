using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Combobox : Control
    {
        public void Append(string text) => uiComboboxAppend(Handle, text);

        public int SelectedItem
        {
            get
            {
                return uiComboboxSelected(Handle);
            }
            set
            {
                uiComboboxSetSelected(Handle, value);
            }
        }

        public event EventHandler<EventArgs> Selected;
        protected virtual void OnSelected(EventArgs e)
        {
            Selected?.Invoke(this, e);
        }

        public Combobox()
        {
            Handle = uiNewCombobox();
            // Events
            uiComboboxOnSelected(Handle, (f, data) => OnSelected(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
