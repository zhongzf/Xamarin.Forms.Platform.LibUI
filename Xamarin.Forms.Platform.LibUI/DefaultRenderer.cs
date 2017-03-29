using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    internal sealed class DefaultRenderer : ViewRenderer<View, UI.Grid>
	{
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
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