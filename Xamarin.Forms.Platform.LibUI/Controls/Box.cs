using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public abstract class Box : Control
    {
        public void Append(Control child, bool stretchy = false) => uiBoxAppend(Handle, child.Handle, stretchy);
        public void Delete(int index) => uiBoxDelete(Handle, index);

        public bool Padded
        {
            get
            {
                return uiBoxPadded(Handle);
            }
            set
            {
                uiBoxSetPadded(Handle, value);
            }
        }
    }
}
