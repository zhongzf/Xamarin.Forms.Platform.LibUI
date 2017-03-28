using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Grid : Control
    {
        public void Append(Control child, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign) 
            => uiGridAppend(Handle, child.Handle, left, top, xspan, yspan, hexpand, halign, vexpand, valign);
        public void InsertAt(Control child, Control cexisting, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign) 
            => uiGridInsertAt(Handle, child.Handle, cexisting.Handle, at, xspan, yspan, hexpand, halign, vexpand, valign);

        public bool Padded
        {
            get
            {
                return uiGridPadded(Handle);
            }
            set
            {
                uiGridSetPadded(Handle, value);
            }
        }

        public Grid()
        {
            Handle = uiNewGrid();
        }
    }
}
