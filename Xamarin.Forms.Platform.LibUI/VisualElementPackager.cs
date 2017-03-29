using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class VisualElementPackager : IDisposable
    {
        readonly int _column;
        readonly int _columnSpan;
        readonly int _row;
        readonly int _rowSpan;

        readonly IVisualElementRenderer _renderer;
        bool _disposed;
        bool _isLoaded;

        public VisualElementPackager(IVisualElementRenderer renderer)
        {
            if (renderer == null)
                throw new ArgumentNullException("renderer");

            _renderer = renderer;
        }

        public VisualElementPackager(IVisualElementRenderer renderer, int row = 0, int rowSpan = 0, int column = 0, int columnSpan = 0) : this(renderer)
        {
            _row = row;
            _rowSpan = rowSpan;
            _column = column;
            _columnSpan = columnSpan;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;

            VisualElement element = _renderer.Element;
            if (element != null)
            {
                element.ChildAdded -= OnChildAdded;
                element.ChildRemoved -= OnChildRemoved;
            }
        }
        
        public void Load()
        {
            if (_isLoaded)
                return;

            _isLoaded = true;
            _renderer.Element.ChildAdded += OnChildAdded;
            _renderer.Element.ChildRemoved += OnChildRemoved;

            ReadOnlyCollection<Element> children = (_renderer.Element as IElementController).LogicalChildren;
            for (var i = 0; i < children.Count; i++)
            {
                OnChildAdded(_renderer.Element, new ElementEventArgs(children[i]));
            }
        }

        void OnChildAdded(object sender, ElementEventArgs e)
        {
            var view = e.Element as VisualElement;

            if (view == null)
                return;

            IVisualElementRenderer childRenderer = Platform.CreateRenderer(view);
            Platform.SetRenderer(view, childRenderer);

            AddChild(childRenderer);
        }

        private void AddChild(IVisualElementRenderer childRenderer)
        {
            var container = _renderer.Control;
            switch(container)
            {
                case UI.Box box:
                    {
                        box.Append(childRenderer.Control);
                        break;
                    }
                case UI.Grid grid :
                    {
                        grid.Append(childRenderer.Control);
                        break;
                    }
            }
        }

        private void RemoveChild(IVisualElementRenderer childRenderer)
        {
            // TODO:
        }

        void OnChildRemoved(object sender, ElementEventArgs e)
        {
            var view = e.Element as VisualElement;

            if (view == null)
                return;

            IVisualElementRenderer childRenderer = Platform.GetRenderer(view);
            if (childRenderer != null)
            {
                RemoveChild(childRenderer);

                view.Cleanup();
            }
        }
    }
}
