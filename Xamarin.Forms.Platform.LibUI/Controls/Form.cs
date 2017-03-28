using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Form : Control
    {
        public void Append(string label, Control child, bool stretchy = false) => uiFormAppend(Handle, label, child.Handle, stretchy);
        public void Delete(int index) => uiFormDelete(Handle, index);

        public bool Padded
        {
            get
            {
                return uiFormPadded(Handle);
            }
            set
            {
                uiFormSetPadded(Handle, value);
            }
        }

        public Form()
        {
            Handle = uiNewForm();
        }
    }
}
