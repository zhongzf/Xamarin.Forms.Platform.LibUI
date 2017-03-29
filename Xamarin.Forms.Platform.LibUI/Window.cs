using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class Window : UI.Window
    {
        public const string DefaultTitle = "Main";

        public Platform Platform { get; set; }
        public Forms.Application Application { get; set; }

        public Window()
            : this(DefaultTitle)
        {
        }
        public Window(string title, int width = 500, int height = 200)
            : base(title, width, height)
        {
            Platform = new Platform(this);
        }

        public void LoadApplication(Forms.Application application)
        {
            if (application == null)
                throw new ArgumentNullException("application");

            Application = application;
            Forms.Application.Current = application;
            Platform.SetPage(application.MainPage);
        }
    }
}
