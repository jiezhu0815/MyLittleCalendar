using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyLittleCalendar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
            View view = sender as View;
            //var parent = (VisualElement)view.Parent;

            movableItems.RaiseChild(view);

            switch (e.StatusType)
            {
                // Move view
                case GestureStatus.Running:
                case GestureStatus.Completed:


                    view.TranslationX = Math.Max(movableItems.X - view.X + 10, Math.Min(movableItems.X + movableItems.Width - view.X - view.Bounds.Width - 10, view.TranslationX + e.TotalX));
                    view.TranslationY = Math.Max(movableItems.Y - view.Y + 100, Math.Min(movableItems.Y + movableItems.Height - view.Y - view.Bounds.Height - 50, view.TranslationY + e.TotalY));

                    /*
                    view.TranslationX = Math.Max(parent.X - view.X + 10, Math.Min(parent.X + parent.Width - view.X - view.Bounds.Width - 10, view.TranslationX + e.TotalX));
                    view.TranslationY = Math.Max(parent.Y - view.Y + 100, Math.Min(parent.Y + parent.Height - view.Y - view.Bounds.Height - 50, view.TranslationY + e.TotalY));
                    */
                    break;

            }
        }

    }
}
