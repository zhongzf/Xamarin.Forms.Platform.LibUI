using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.LibUI
{
    public class SystemResourcesProvider : ISystemResourcesProvider
    {
        public IResourceDictionary GetSystemResources()
        {
            var resources = new ResourceDictionary();
            // TODO: Resources
            return resources;
        }
    }
}
