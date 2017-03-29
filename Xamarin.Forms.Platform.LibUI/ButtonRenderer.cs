using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class ButtonRenderer : ViewRenderer<Button, UI.Button>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var button = new UI.Button(e.NewElement.Text);
                    button.Clicked += OnButtonClick;
                    SetNativeControl(button);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            (Element as IButtonController)?.SendClicked();
        }
    }
}
