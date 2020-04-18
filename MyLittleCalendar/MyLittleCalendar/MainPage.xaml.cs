using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MyLittleCalendar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        Dictionary<string, (double, double)> iniPositions = new Dictionary<string, (double, double)>();

        //Dictionary<string, string> saveValues = new Dictionary<string, string>();

        //uint animationSpeed = 300;

        public MainPage()
        {
            InitializeComponent();

            //initialListView = movableItems.Children.ToList<View>();

        /*
            iniPositions.Add("spring", (-10, 136));
            iniPositions.Add("summer", (-10, 200));
            iniPositions.Add("fall", (-10, 264));
            iniPositions.Add("winter", (-10, 328));

            iniPositions.Add("january", (10, 130));
            iniPositions.Add("february", (10, 160));
            iniPositions.Add("march", (10, 190));
            iniPositions.Add("april", (10, 220));
            iniPositions.Add("may", (10, 250));
            iniPositions.Add("june", (10, 280));
            iniPositions.Add("july", (10, 310));
            iniPositions.Add("august", (10, 340));
            iniPositions.Add("september", (10, 370));
            iniPositions.Add("october", (10, 400));
            iniPositions.Add("november", (10, 430));
            iniPositions.Add("december", (10, 460));

            iniPositions.Add("num0", (10, 531));
            iniPositions.Add("num1a", (36, 531));
            iniPositions.Add("num1b", (62, 531));
            iniPositions.Add("num2a", (88, 531));
            iniPositions.Add("num2b", (10, 557));
            iniPositions.Add("num3", (36, 557));
            iniPositions.Add("num4", (62, 557));
            iniPositions.Add("num5", (88, 557));
            iniPositions.Add("num6", (10, 583));
            iniPositions.Add("num7", (36, 583));
            iniPositions.Add("num8", (62, 583));
            iniPositions.Add("num9", (88, 583));

            iniPositions.Add("sunday", (-11, 428));
            iniPositions.Add("monday", (-11, 454));
            iniPositions.Add("tuesday", (-11, 480));
            iniPositions.Add("wednesday", (-11, 506));
            iniPositions.Add("thursday", (-11, 532));
            iniPositions.Add("friday",(-11, 558));
            iniPositions.Add("saturday", (-11, 584));

            iniPositions.Add("sunny", (3, 445));
            iniPositions.Add("cloudy", (3, 478));
            iniPositions.Add("partysunny", (3, 512));
            iniPositions.Add("snow", (3, 545));
            iniPositions.Add("rain", (3, 578));

            */
        }






       SKPaint backgroundBrush = new SKPaint()

        {

            Style = SKPaintStyle.Fill,

            Color = Color.Red.ToSKColor()

        };

        private void BackgroundGradient_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;

            SKSurface surface = e.Surface;

            SKCanvas canvas = surface.Canvas;



            canvas.Clear();



            // get the brush based on the theme

            SKColor gradientStart = ((Color)Application.Current.Resources["BackgroundGradientStartColor"]).ToSKColor();

            SKColor gradientMid = ((Color)Application.Current.Resources["BackgroundGradientMidColor"]).ToSKColor();

            SKColor gradientEnd = ((Color)Application.Current.Resources["BackgroundGradientEndColor"]).ToSKColor();



            // gradient backround

            backgroundBrush.Shader = SKShader.CreateRadialGradient

                (new SKPoint(0, info.Height * .8f),

                info.Height * .8f,

                new SKColor[] { gradientStart, gradientMid, gradientEnd },

                new float[] { 0, .5f, 1 },

                SKShaderTileMode.Clamp);



            //backgroundBrush.Shader = SKShader.CreateLinearGradient(

            //                              new SKPoint(0, 0),

            //                              new SKPoint(info.Width, info.Height),

            //                              new SKColor[] {

            //                                  gradientStart, gradientEnd },

            //                              new float[] { 0, 1 },

            //                              SKShaderTileMode.Clamp);

            SKRect backgroundBounds = new SKRect(0, 0, info.Width, info.Height);

            canvas.DrawRect(backgroundBounds, backgroundBrush);
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {

        }
    }
}
