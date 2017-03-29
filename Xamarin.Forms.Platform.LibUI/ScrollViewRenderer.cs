using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class ScrollViewRenderer : ViewRenderer<ScrollView, UI.Grid>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ScrollView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var grid = new UI.Grid();
                    SetNativeControl(grid);
                }
            }
        }
    }
}
