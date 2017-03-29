using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.LibUI
{
    internal class DeviceInfo : Forms.Internals.DeviceInfo
    {
        Window Window;

        public DeviceInfo(Window window)
        {
            Window = window;
        }

        public override Size PixelScreenSize => throw new NotImplementedException();

        public override Size ScaledScreenSize => throw new NotImplementedException();

        public override double ScalingFactor => throw new NotImplementedException();
    }
}
