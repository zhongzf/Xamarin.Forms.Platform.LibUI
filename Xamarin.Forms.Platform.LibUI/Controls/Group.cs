using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Group : Control
    {
        public string Title
        {
            get
            {
                return uiGroupTitle(Handle);
            }
            set
            {
                uiGroupSetTitle(Handle, value);
            }
        }
        public bool Margined
        {
            get
            {
                return uiGroupMargined(Handle);
            }
            set
            {
                uiGroupSetMargined(Handle, value);
            }
        }

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
                uiGroupSetChild(Handle, value.Handle);
            }
        }

        public Group(string title)
        {
            Handle = uiNewGroup(title);
        }
    }
}
