using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class EditableCombobox : Control
    {
        public void Append(string text) => uiEditableComboboxAppend(Handle, text);

        public string Text
        {
            get
            {
                return uiEditableComboboxText(Handle);
            }
            set
            {
                uiEditableComboboxSetText(Handle, value);
            }
        }

        public event EventHandler<EventArgs> Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public EditableCombobox()
        {
            Handle = uiNewEditableCombobox();
            // Events
            uiEditableComboboxOnChanged(Handle, (f, data) => OnChanged(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
