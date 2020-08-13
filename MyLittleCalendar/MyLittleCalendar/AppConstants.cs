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
                        return "ca-app-pub-5188063035353381~6401274788";
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
                        return "ca-app-pub-5188063035353381/2791414487";
                    //return "ca-app-pub-5188063035353381/2791414487";
                    default:
                        return "ca-app-pub-5188063035353381/8835866435";
                }
            }
        }

    }
}
