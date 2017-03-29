using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;
using UI = Xamarin.Forms.Platform.LibUI.Controls;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI
{
    public class Application
    {
        public static Window Window { get; set; }
        static bool s_isInitialized;

        public static void Init(Window window)
        {
            if (s_isInitialized)
                return;

            Window = window;
            Device.PlatformServices = new PlatformServices();
            Device.Info = new DeviceInfo(window);

            Registrar.RegisterAll(new[] { typeof(ExportRendererAttribute), typeof(ExportCellAttribute), typeof(ExportImageSourceHandlerAttribute) });

            s_isInitialized = true;
        }

        public void LoadApplication(Type applicationType)
        {
            uiInitOptions o = new uiInitOptions();
            uiInit(ref o);

            Window window = new Window();
            Init(window);
            var application = (Forms.Application)Activator.CreateInstance(applicationType);
            window.LoadApplication(application);
            if (Window != window)
            {
                window.Show();
            }
            else
            {
                Run(window);
            }
        }

        public static void Run(Type applicationType)
        {
            var application = new Application();
            application.LoadApplication(applicationType);
        }

        public void Run(Window window)
        {
            window.Show();

            uiMain();
            uiUninit();
        }
    }
}
