using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Drawing;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class Window : Control
    {
        public static string OpenFile(Window parent) => uiOpenFile(parent.Handle);
        public string OpenFile() => OpenFile(this);

        public static string SaveFile(Window parent) => uiSaveFile(parent.Handle);
        public string SaveFile() => SaveFile(this);

        public static void MsgBox(Window parent, string title, string description)
            => uiMsgBox(parent.Handle, title, description);
        public void MsgBox(string title, string description) => MsgBox(this, title, description);

        public static void MsgBoxError(Window parent, string title, string description)
            => uiMsgBoxError(parent.Handle, title, description);
        public void MsgBoxError(string title, string description) => MsgBoxError(this, title, description);


        public string Title
        {
            get
            {
                return uiWindowTitle(Handle);
            }
            set
            {
                uiWindowSetTitle(Handle, value);
            }
        }

        public Size ContentSize
        {
            get
            {
                uiWindowContentSize(Handle, out int width, out int height);
                return new Size(width, height);
            }
            set
            {
                uiWindowSetContentSize(Handle, value.Width, value.Height);
            }
        }

        public bool Fullscreen
        {
            get
            {
                return uiWindowFullscreen(Handle);
            }
            set
            {
                uiWindowSetFullscreen(Handle, value);
            }
        }
        
        public bool Borderless
        {
            get
            {
                return uiWindowBorderless(Handle);
            }
            set
            {
                uiWindowSetBorderless(Handle, value);
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
                uiWindowSetChild(Handle, value.Handle);
            }
        }

        public bool Margined
        {
            get
            {
                return uiWindowMargined(Handle);
            }
            set
            {
                uiWindowSetMargined(Handle, value);
            }
        }

        public event EventHandler<EventArgs> ContentSizeChanged;
        protected virtual void OnContentSizeChanged(EventArgs e)
        {
            ContentSizeChanged?.Invoke(this, e);
        }


        public event EventHandler<CancelEventArgs> Closing;
        protected virtual void OnClosing(CancelEventArgs e)
        {
            Closing?.Invoke(this, e);
        }

        protected virtual void Init()
        {
            // Events
            uiWindowOnContentSizeChanged(Handle, (f, data) => OnContentSizeChanged(EventArgs.Empty), IntPtr.Zero);
            uiWindowOnClosing(Handle, (f, data) =>
            {
                var e = new CancelEventArgs();
                OnClosing(e);
                return e.Cancel;
            }, IntPtr.Zero);
        }

        public Window(string title, int width, int height, bool hasMenubar = false)
        {
            Handle = uiNewWindow(title, width, height, hasMenubar);
            Init();
        }
        protected Window(IntPtr handle)
        {
            Handle = handle;
            Init();
        }
    }
}
