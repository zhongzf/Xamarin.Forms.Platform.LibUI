using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.LibUI
{
    public class PlatformServices : IPlatformServices
    {
        public bool IsInvokeRequired => throw new NotImplementedException();

        public string RuntimePlatform => throw new NotImplementedException();

        public void BeginInvokeOnMainThread(Action action)
        {
            action();
        }

        public Ticker CreateTicker()
        {
            throw new NotImplementedException();
        }


        public Assembly[] GetAssemblies()
        {
            // TODO: Use DI.
            var assemblies = new List<Assembly>();
            foreach (var assemblyName in DependencyContext.Default.GetRuntimeAssemblyNames(RuntimeEnvironment.GetRuntimeIdentifier()))
            {
                try
                {
                    var assembly = Assembly.Load(assemblyName);
                    if (assembly != null)
                    {
                        assemblies.Add(assembly);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }
            }
            return assemblies.ToArray();
        }

        public string GetMD5Hash(string input)
        {
            throw new NotImplementedException();
        }

        public double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IIsolatedStorageFile GetUserStoreForApplication()
        {
            throw new NotImplementedException();
        }

        public void OpenUriAction(Uri uri)
        {
            throw new NotImplementedException();
        }

        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            throw new NotImplementedException();
        }
    }
}
