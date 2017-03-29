using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class VisualElementTracker<TElement, TNativeElement> : IDisposable
        where TElement : VisualElement
        where TNativeElement : UI.Control
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
