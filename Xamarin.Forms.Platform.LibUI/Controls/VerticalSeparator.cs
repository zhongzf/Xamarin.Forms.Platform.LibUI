﻿using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Xamarin.Forms.Platform.LibUI.Controls
{
    public class VerticalSeparator : Control
    {
        public VerticalSeparator()
        {
            Handle = uiNewVerticalSeparator();
        }
    }
}
