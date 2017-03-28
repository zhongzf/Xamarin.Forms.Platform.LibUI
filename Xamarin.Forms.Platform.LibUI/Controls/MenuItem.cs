using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Interop;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class MenuItem : InteropObject
    {
        public void Enable() => uiMenuItemEnable(Handle);
        public void Disable() => uiMenuItemDisable(Handle);

        public bool Checked
        {
            get
            {
                return uiMenuItemChecked(Handle);
            }
            set
            {
                uiMenuItemSetChecked(Handle, value);
            }
        }

        public event EventHandler<EventArgs> Clicked;
        protected virtual void OnClicked(EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        private Menu _menu;
        public Menu Menu => _menu;


        internal MenuItem(IntPtr handle, Menu menu)
        {
            Handle = handle;
            _menu = menu;
            // Events
            uiMenuItemOnClicked(Handle, (f, window, data) => OnClicked(EventArgs.Empty), IntPtr.Zero);
        }
    }
}
