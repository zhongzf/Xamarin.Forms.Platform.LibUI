using System;
using Xamarin.Forms;

namespace Sample
{
    public class DemoApp : Application
    {
        Button button = null;
        public DemoApp()
        {
            button = new Button
            {
                Text = "test2"
            };
            button.Clicked += Button_Clicked;
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = button
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button_Clicked");
        }
    }
}
