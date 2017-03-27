﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Interop;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI
{
    public abstract class Control: IDisposable
    {
        protected internal IntPtr Handle { get; protected set; }

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                uiControlDestroy(Handle);
                Handle = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }

        private Control _parent;
        public Control Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
                uiControlSetParent(Handle, _parent.Handle);
            }
        }

        public bool TopLevel => uiControlToplevel(Handle);

        public bool Visible => uiControlVisible(Handle);
        public void Show() => uiControlShow(Handle);
        public void Hide() => uiControlHide(Handle);

        public bool Enabled => uiControlEnabled(Handle);
        public void Enable() => uiControlEnable(Handle);
        public void Disable() => uiControlDisable(Handle);
    }
}
