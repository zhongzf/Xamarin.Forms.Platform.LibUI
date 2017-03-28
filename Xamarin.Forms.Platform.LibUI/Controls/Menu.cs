using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Menu : Control
    {
        public MenuItem AppendItem(string name)
        {
            var handle = uiMenuAppendItem(Handle, name);
            return new MenuItem(handle, this);
        }
        public MenuItem AppendCheckItem(string name)
        {
            var handle = uiMenuAppendCheckItem(Handle, name);
            return new MenuItem(handle, this);
        }
        public MenuItem AppendQuitItem()
        {
            var handle = uiMenuAppendQuitItem(Handle);
            return new MenuItem(handle, this);
        }
        public MenuItem AppendPreferencesItem()
        {
            var handle = uiMenuAppendPreferencesItem(Handle);
            return new MenuItem(handle, this);
        }
        public MenuItem AppendAboutItem()
        {
            var handle = uiMenuAppendAboutItem(Handle);
            return new MenuItem(handle, this);
        }
        public void AppendSeparator()
        {
            uiMenuAppendSeparator(Handle);
        }

        public Menu(string name)
        {
            Handle = uiNewMenu(name);
        }
    }
}
