using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class Platform : BindableObject, IPlatform, INavigation, IDisposable
    {
        public Window Window { get; set; }

        public Platform(Window window)
        {
            Window = window;
        }

        public IReadOnlyList<Page> ModalStack => throw new NotImplementedException();

        public IReadOnlyList<Page> NavigationStack => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public SizeRequest GetNativeSize(VisualElement view, double widthConstraint, double heightConstraint)
        {
            throw new NotImplementedException();
        }

        public void InsertPageBefore(Page page, Page before)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public void RemovePage(Page page)
        {
            throw new NotImplementedException();
        }

        #region Renderer
        internal static readonly BindableProperty RendererProperty = BindableProperty.CreateAttached("Renderer", typeof(IVisualElementRenderer), typeof(Platform), default(IVisualElementRenderer));

        public static IVisualElementRenderer GetRenderer(VisualElement element)
        {
            return (IVisualElementRenderer)element.GetValue(RendererProperty);
        }

        public static void SetRenderer(VisualElement element, IVisualElementRenderer value)
        {
            element.SetValue(RendererProperty, value);
            element.IsPlatformEnabled = value != null;
        }

        public static IVisualElementRenderer CreateRenderer(VisualElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            IVisualElementRenderer renderer = Registrar.Registered.GetHandler<IVisualElementRenderer>(element.GetType()) ?? new DefaultRenderer();
            renderer.SetElement(element);
            return renderer;
        }
        #endregion

        internal void SetPage(Page newRoot)
        {
            if (newRoot == null)
                throw new ArgumentNullException("newRoot");

            SetCurrent(newRoot, false, true);
        }

        private void SetCurrent(Page newPage, bool animated, bool popping = false, Action completedCallback = null)
        {
            IVisualElementRenderer pageRenderer = newPage.GetOrCreateRenderer();
            //Window.Form.Children.Add(pageRenderer.ContainerElement);
            Window.Child = pageRenderer.Control;
        }
    }
}
