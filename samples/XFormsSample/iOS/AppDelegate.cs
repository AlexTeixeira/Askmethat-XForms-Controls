using System;
using System.Collections.Generic;
using System.Linq;
using Askmethat.XForms.Controls.EntryRenderers;
using Foundation;
using UIKit;

namespace XFormsSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            AmcBottomBorderEntryRenderer.Init();


            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
