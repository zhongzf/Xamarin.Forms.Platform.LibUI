using System;
using Xamarin.Forms.Platform.LibUI;
using Xamarin.Forms.Platform.LibUI.Controls;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Sample
{
    class Program
    {
        public static Window Window;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            uiInitOptions o = new uiInitOptions();
            uiInit(ref o);

            Window = new MainWindow("libui Control Gallery", 640, 480, true);
            Window.Show();

            uiMain();
            uiUninit();
        }
    }
}