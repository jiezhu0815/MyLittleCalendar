using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.MobileAds;
using Lottie.Forms.iOS.Renderers;
using UIKit;

namespace MyLittleCalendar.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            foreach (var family in UIFont.FamilyNames)
            {
                System.Diagnostics.Debug.WriteLine($"{family}");

                foreach (var names in UIFont.FontNamesForFamilyName(family))
                {
                    System.Diagnostics.Debug.WriteLine($"{names}");
                }
            }

            global::Xamarin.Forms.Forms.Init();
            Google.MobileAds.MobileAds.Configure(AppConstants.AppId);
            //MobileAds.SharedInstance.Start(CompletionHandler);
            AnimationViewRenderer.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        //private void CompletionHandler(InitializationStatus status) { }
    }
}
