using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Grid : Control
    {
        public void Append(Control child, int left = 0, int top = 0, int xspan= 0, int yspan = 0, int hexpand = 0, uiAlign halign = uiAlign.Center, int vexpand = 0, uiAlign valign = uiAlign.Center) 
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
