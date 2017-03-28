using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Tab : Control
    {
        public void Append(string name, TabPage tabPage)
        {
            tabPage.Tab = this;
            uiTabAppend(Handle, name, tabPage.Handle);
            tabPage.Index = NumPages - 1;
        }

        public void Append(TabPage tabPage) => Append(tabPage.Name, tabPage);

        public void InsertAt(string name, int index, TabPage tabPage)
        {
            tabPage.Tab = this;
            uiTabInsertAt(Handle, name, index, tabPage.Handle);
            tabPage.Index = index;
        }

        public void InsertAt(int index, TabPage tabPage) => InsertAt(tabPage.Name, index, tabPage);

        public void Delete(int index) => uiTabDelete(Handle, index);

        public int NumPages => uiTabNumPages(Handle);

        public Tab()
        {
            Handle = uiNewTab();
        }
    }
}
