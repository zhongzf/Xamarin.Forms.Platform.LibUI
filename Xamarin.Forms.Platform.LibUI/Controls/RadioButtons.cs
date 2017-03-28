using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class RadioButtons : Control
    {
        public void Append(string text) => uiRadioButtonsAppend(Handle, text);

        public int SelectedItem
        {
            get
            {
                return uiRadioButtonsSelected(Handle);
            }
            set
            {
                uiRadioButtonsSetSelected(Handle, value);
            }
        }

        public event EventHandler<EventArgs> Selected;
        protected virtual void OnSelected(EventArgs e)
        {
            Selected?.Invoke(this, e);
        }

        public RadioButtons()
        {
            Handle = uiNewRadioButtons();
            // Events
            uiRadioButtonsOnSelected(Handle, (f, data) => OnSelected(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
