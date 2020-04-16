using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyLittleCalendar
{
    public class AppConstants
    {
        public static string AppId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-5188063035353381~5334457979";
                    default:
                        return "ca-app-pub-5188063035353381~5334457979";
                }
            }
        }


        public static string BannerId
        {

            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-3940256099942544/6300978111";
                    //return "ca-app-pub-5188063035353381/2791414487";
                    default:
                        return "ca-app-pub-5188063035353381/2791414487";
                }
            }
        }

    }
}
