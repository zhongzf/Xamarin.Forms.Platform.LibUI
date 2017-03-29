using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public interface IVisualElementRenderer : IRegisterable, IDisposable
    {
        UI.Control Control { get; }

        VisualElement Element { get; }

        event EventHandler<VisualElementChangedEventArgs> ElementChanged;

        SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint);
        void SetElement(VisualElement element);
    }
}
