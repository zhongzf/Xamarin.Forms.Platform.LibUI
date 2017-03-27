using System;
using Xamarin.Forms.Platform.LibUI;
using Xamarin.Forms.Platform.LibUI.Interop;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            uiInitOptions o = new uiInitOptions();
            uiInit(ref o);

            Window window = new Window("Test Window", 640, 480, false);
            window.Show();

            uiMain();
            uiUninit();
        }
    }
}