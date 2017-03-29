﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Platform.LibUI
{
    public class VisualElementChangedEventArgs : ElementChangedEventArgs<VisualElement>
    {
        public VisualElementChangedEventArgs(VisualElement oldElement, VisualElement newElement) : base(oldElement, newElement)
        {
        }
    }

    public class ElementChangedEventArgs<TElement> : EventArgs where TElement : Element
    {
        public ElementChangedEventArgs(TElement oldElement, TElement newElement)
        {
            OldElement = oldElement;
            NewElement = newElement;
        }

        public TElement NewElement { get; private set; }

        public TElement OldElement { get; private set; }
    }
}
