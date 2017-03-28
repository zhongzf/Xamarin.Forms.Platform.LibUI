using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Platform.LibUI.Drawing
{
    public struct Color
    {
        public double R;
        public double G;
        public double B;
        public double A;

        public Color(double r, double g, double b, double a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
