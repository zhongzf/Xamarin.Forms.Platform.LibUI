using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class VisualElementRenderer<TElement, TNativeElement> : UI.Control, IVisualElementRenderer, IEffectControlProvider 
        where TElement : VisualElement
        where TNativeElement : UI.Control
    {
        bool _disposed;

        public TNativeElement Control { get; private set; }
        UI.Control IVisualElementRenderer.Control => this.Control;

        public TElement Element { get; set; }
        VisualElement IVisualElementRenderer.Element => Element;

        EventHandler<VisualElementChangedEventArgs> _elementChangedHandlers;
        event EventHandler<VisualElementChangedEventArgs> IVisualElementRenderer.ElementChanged
        {
            add
            {
                if (_elementChangedHandlers == null)
                    _elementChangedHandlers = value;
                else
                    _elementChangedHandlers = (EventHandler<VisualElementChangedEventArgs>)Delegate.Combine(_elementChangedHandlers, value);
            }

            remove { _elementChangedHandlers = (EventHandler<VisualElementChangedEventArgs>)Delegate.Remove(_elementChangedHandlers, value); }
        }

        public event EventHandler<ElementChangedEventArgs<TElement>> ElementChanged;

        protected virtual void OnElementChanged(ElementChangedEventArgs<TElement> e)
        {
            var args = new VisualElementChangedEventArgs(e.OldElement, e.NewElement);
            if (_elementChangedHandlers != null)
                _elementChangedHandlers(this, args);

            EventHandler<ElementChangedEventArgs<TElement>> changed = ElementChanged;
            if (changed != null)
                changed(this, e);
        }

        protected bool AutoPackage { get; set; } = true;
        VisualElementPackager Packager { get; set; }


        public SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        {
            throw new NotImplementedException();
        }

        public void RegisterEffect(Effect effect)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        public void SetElement(VisualElement element)
        {
            TElement oldElement = Element;
            Element = (TElement)element;

            if (oldElement != null)
            {
                oldElement.PropertyChanged -= OnElementPropertyChanged;
            }

            if (element != null)
            {
                Element.PropertyChanged += OnElementPropertyChanged;

                if (AutoPackage && Packager == null)
                {
                    Packager = new VisualElementPackager(this);
                }
                if (Packager != null)
                {
                    Packager.Load();
                }
            }

            OnElementChanged(new ElementChangedEventArgs<TElement>(oldElement, Element));

            // Effect
            var controller = (IElementController)oldElement;
            if (controller != null && controller.EffectControlProvider == this)
            {
                controller.EffectControlProvider = null;
            }
            controller = element;
            if (controller != null)
            {
                controller.EffectControlProvider = this;
            }
        }

        protected void SetNativeControl(TNativeElement control)
        {
            TNativeElement oldControl = Control;
            Control = control;

            // TODO: remove oldControl.
            if (control == null)
                return;
            // TODO: init newControl.
        }
    }
}
