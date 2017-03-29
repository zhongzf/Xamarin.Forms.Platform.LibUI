using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class PageRenderer : VisualElementRenderer<Page, UI.Grid>
    {
        bool _disposed;
        bool _loaded;

        public PageRenderer()
        {
            var grid = new UI.Grid();
            SetNativeControl(grid);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
            }
        }
    }
}
