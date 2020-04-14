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


        Dictionary<View, (double, double)> iniPositions = new Dictionary<View, (double, double)>();
        public MainPage()
        {
            InitializeComponent();

            //initialListView = movableItems.Children.ToList<View>();
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
                    view.TranslationX = Math.Max(movableItems.X - view.X + 10, Math.Min(movableItems.X + movableItems.Width - view.X - view.Bounds.Width - 10, view.TranslationX + e.TotalX));
                    view.TranslationY = Math.Max(movableItems.Y - view.Y + 100, Math.Min(movableItems.Y + movableItems.Height - view.Y - view.Bounds.Height - 50, view.TranslationY + e.TotalY));

                    /*
                    view.TranslationX = Math.Max(parent.X - view.X + 10, Math.Min(parent.X + parent.Width - view.X - view.Bounds.Width - 10, view.TranslationX + e.TotalX));
                    view.TranslationY = Math.Max(parent.Y - view.Y + 100, Math.Min(parent.Y + parent.Height - view.Y - view.Bounds.Height - 50, view.TranslationY + e.TotalY));
                    */
                    break;
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

        private void RefreshTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            foreach(var item in movableItems.Children)
            {
                var v = (View)item;
           
                if(IsFrame(v))
                {
                    var iitem = iniPositions[v];

                    //item.TranslationX = iitem.X - item.X;
                    //item.TranslationY = iitem.Y - item.Y;

                    item.TranslateTo(iitem.Item1, iitem.Item2);
                }           
            }
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

            
            foreach(var item in movableItems.Children.ToList<View>())
            {
                if(IsFrame(item))
                {
                    iniPositions.Add(item, (item.TranslationX, item.TranslationY));
                }
            }
        }

     

        private bool IsFrame(View item)
        {
            return (item == spring || item == summer || item == fall || item == winter ||
                    item == january || item == february || item == march || item == april || item == may||item==june||item==july||item==august||item==september||item==october||item==november||item==december||
                    item==num0||item==num1a||item==num1b||item==num2a||item==num2b||item==num3||item==num4||item==num5||item==num6||item==num7||item==num8||item==num9||
                    item==sunday||item==monday||item==tuesday||item==wednesday||item==thursday||item==friday||item==saturday||
                    item==sunny||item==cloudy||item==partysunny||item==snow||item==rain
                    );
        }

    }
}
