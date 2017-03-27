using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Platform.LibUI.Drawing;
using Xamarin.Forms.Platform.LibUI.Interop;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI
{
    public class Window : Control
    {
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

        public Control Child
        {
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

        public Window(string title, int width, int height, bool hasMenubar)
        {
            Handle = uiNewWindow(title, width, height, hasMenubar);
            // Events
            uiWindowOnContentSizeChanged(Handle, (f, data) => OnContentSizeChanged(EventArgs.Empty), IntPtr.Zero);
            uiWindowOnClosing(Handle, (f, data) =>
            {
                var e = new CancelEventArgs();
                OnClosing(e);
                return e.Cancel;
            }, IntPtr.Zero);
        }
    }
}
