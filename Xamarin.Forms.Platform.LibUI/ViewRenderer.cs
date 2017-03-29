using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public abstract class ViewRenderer : ViewRenderer<View, UI.Control>
    {
    }

    public abstract class ViewRenderer<TView, TNativeView> : VisualElementRenderer<TView, TNativeView> 
        where TView : View 
        where TNativeView : UI.Control
    {
    }
}