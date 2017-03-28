using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Interop;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class TabPage : InteropObject
    {
        public Tab Tab { get; internal set; }

        private Control _child;
        public Control Child
        {
            get
            {
                return _child;
            }
            set
            {
                _child = value;
                if (value != null)
                {
                    Handle = value.Handle;
                }
                else
                {
                    Handle = IntPtr.Zero;
                }
            }
        }

        public int Index { get; internal set; }

        public bool Margined
        {
            get
            {
                return uiTabMargined(Handle, Index);
            }
            set
            {
                uiTabSetMargined(Handle, Index, value);
            }
        }

        public string Name { get; set; }

        public TabPage(Control child)
        {
            Child = child;
        }

        public TabPage(string name, Control child = null) : this(child)
        {
            Name = name;
        }
    }
}
