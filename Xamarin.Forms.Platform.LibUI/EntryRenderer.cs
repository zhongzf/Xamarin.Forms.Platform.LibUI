using System;
using System.Collections.Generic;
using System.Text;
using UI = Xamarin.Forms.Platform.LibUI.Controls;

namespace Xamarin.Forms.Platform.LibUI
{
    public class EntryRenderer : ViewRenderer<Entry, UI.Entry>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var entry = new UI.Entry();
                    entry.Changed += Entry_Changed; ;                    
                    SetNativeControl(entry);
                }
            }
        }

        private void Entry_Changed(object sender, EventArgs e)
        {
            Element.SetValueCore(Entry.TextProperty, Control.Text);
        }
    }
}
