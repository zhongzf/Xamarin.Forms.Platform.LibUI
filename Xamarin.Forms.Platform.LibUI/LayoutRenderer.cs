using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class LayoutRenderer : ViewRenderer<Layout, UI.Grid>
    {
        public LayoutRenderer()
        {
            var grid = new UI.Grid();
            SetNativeControl(grid);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Layout> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
            }
        }
    }
}
