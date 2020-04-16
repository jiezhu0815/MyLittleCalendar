﻿using SkiaSharp;
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


        Dictionary<View, (double, double)> iniPositions = new Dictionary<View, (double, double)>();

        //Dictionary<string, string> saveValues = new Dictionary<string, string>();

        //uint animationSpeed = 300;

        public MainPage()
        {
            InitializeComponent();

            //initialListView = movableItems.Children.ToList<View>();

        
            iniPositions.Add(spring, (-10, 126));
            iniPositions.Add(summer, (-10, 190));
            iniPositions.Add(fall, (-10, 254));
            iniPositions.Add(winter, (-10, 318));

            iniPositions.Add(january, (10, 120));
            iniPositions.Add(february, (10, 150));
            iniPositions.Add(march, (10, 180));
            iniPositions.Add(april, (10, 210));
            iniPositions.Add(may, (10, 240));
            iniPositions.Add(june, (10, 270));
            iniPositions.Add(july, (10, 300));
            iniPositions.Add(august, (10, 330));
            iniPositions.Add(september, (10, 360));
            iniPositions.Add(october, (10, 390));
            iniPositions.Add(november, (10, 420));
            iniPositions.Add(december, (10, 450));

            iniPositions.Add(num0, (10, 521));
            iniPositions.Add(num1a, (36, 521));
            iniPositions.Add(num1b, (62, 521));
            iniPositions.Add(num2a, (88, 521));
            iniPositions.Add(num2b, (10, 547));
            iniPositions.Add(num3, (36, 547));
            iniPositions.Add(num4, (62, 547));
            iniPositions.Add(num5, (88, 547));
            iniPositions.Add(num6, (10, 573));
            iniPositions.Add(num7, (36, 573));
            iniPositions.Add(num8, (62, 573));
            iniPositions.Add(num9, (88, 573));

            iniPositions.Add(sunday, (-11, 418));
            iniPositions.Add(monday, (-11, 444));
            iniPositions.Add(tuesday, (-11, 470));
            iniPositions.Add(wednesday, (-11, 496));
            iniPositions.Add(thursday, (-11, 522));
            iniPositions.Add(friday, (-11, 548));
            iniPositions.Add(saturday, (-11, 574));

            iniPositions.Add(sunny, (3, 435));
            iniPositions.Add(cloudy, (3, 468));
            iniPositions.Add(partysunny, (3, 502));
            iniPositions.Add(snow, (3, 535));
            iniPositions.Add(rain, (3, 568));


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


                    Preferences.Set(MovableItemToName(view), view.TranslationX + "," + view.TranslationY);
                    /*
                    view.TranslationX = Math.Max(parent.X - view.X + 10, Math.Min(parent.X + parent.Width - view.X - view.Bounds.Width - 10, view.TranslationX + e.TotalX));
                    view.TranslationY = Math.Max(parent.Y - view.Y + 100, Math.Min(parent.Y + parent.Height - view.Y - view.Bounds.Height - 50, view.TranslationY + e.TotalY));
                    */
                    break;


            }
        }

        private async void RefreshTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           /* await MoreSection.TranslateTo(0, 540, animationSpeed, Easing.SinInOut);
            MoreSection.Opacity = 0;
            MoreSection.IsVisible = false;
            await FadeBackground.FadeTo(0, animationSpeed);
            FadeBackground.IsVisible = false;
 
            */
            foreach (var item in movableItems.Children)
            {
                var v = item;
           
                if(IsMovableItem(v))
                {

                    if(iniPositions.ContainsKey(v))
                    {
                        var iitem = iniPositions[v];

                        //item.TranslationX = iitem.X - item.X;
                        //item.TranslationY = iitem.Y - item.Y;

                        item.TranslateTo(iitem.Item1, iitem.Item2);

                        Preferences.Set(MovableItemToName(item), iitem.Item1 + "," + iitem.Item2);

                    }

                }           
            }
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

          
            foreach (var item in iniPositions.Keys)
            {
                var itemName = MovableItemToName(item);

                if (IsMovableItem(item) && Preferences.ContainsKey(itemName))
                {
                    var itemValue = Preferences.Get(itemName,"novalue");

                    if(itemValue!="novalue")
                    {
                        var itemValueArr = itemValue.Split(',');
                        if (itemValueArr.Length > 1)
                        {
                            var tx =double.Parse(itemValueArr[0]);
                            var ty = double.Parse(itemValueArr[1]);
                            item.TranslateTo(tx, ty);
                        }
                        
                    }

                }
            }
        }


        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //}

        private bool IsMovableItem(View item)
        {
            return (item == spring || item == summer || item == fall || item == winter ||
                    item == january || item == february || item == march || item == april || item == may||item==june||item==july||item==august||item==september||item==october||item==november||item==december||
                    item==num0||item==num1a||item==num1b||item==num2a||item==num2b||item==num3||item==num4||item==num5||item==num6||item==num7||item==num8||item==num9||
                    item==sunday||item==monday||item==tuesday||item==wednesday||item==thursday||item==friday||item==saturday||
                    item==sunny||item==cloudy||item==partysunny||item==snow||item==rain
                    );
        }
/*
        private void MoreTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            FadeBackground.Opacity = 0;
            FadeBackground.IsVisible = true;
            _ = FadeBackground.FadeTo(1, animationSpeed);

            MoreSection.Opacity = 1;
            MoreSection.IsVisible = true;
            MoreSection.TranslateTo(0, 0, animationSpeed, Easing.SinInOut);

        }
    */
        private string MovableItemToName(View item)
        {
            if(item==spring)
            {
                return "spring";
            }
            if (item == summer)
            {
                return "summer";
            }
            if(item==fall)
            {
                return "fall";
            }
            if(item==winter)
            {
                return "winter";
            }

            if(item == january)
            {
                return "january";
            }
            if (item == february)
            {
                return "february";
            }
            if (item == march)
            {
                return "march";
            }
            if (item == april)
            {
                return "april";
            }
            if (item == may)
            {
                return "may";
            }
            if (item == june)
            {
                return "june";
            }
            if (item == july)
            {
                return "july";
            }
            if (item == august)
            {
                return "august";
            }
            if (item == september)
            {
                return "september";
            }
            if (item == october)
            {
                return "october";
            }
            if (item == november)
            {
                return "november";
            }
            if (item == december)
            {
                return "december";
            }


            if (item == num0)
            {
                return "num0";
            }
            if (item == num1a)
            {
                return "num1a";
            }
            if (item == num1b)
            {
                return "num1b";
            }
            if (item == num2a)
            {
                return "num2a";
            }
            if (item == num2b)
            {
                return "num2b";
            }
            if (item == num3)
            {
                return "num3";
            }
            if (item == num4)
            {
                return "num4";
            }
            if (item == num5)
            {
                return "num5";
            }
            if (item == num6)
            {
                return "num6";
            }
            if (item == num7)
            {
                return "num7";
            }
            if (item == num8)
            {
                return "num8";
            }
            if (item == num9)
            {
                return "num9";
            }


            if (item == sunday)
            {
                return "sunday";
            }
            if (item == monday)
            {
                return "monday";
            }
            if (item == tuesday)
            {
                return "tuesday";
            }
            if (item == wednesday)
            {
                return "wednesday";
            }
            if (item == thursday)
            {
                return "thursday";
            }
            if (item == friday)
            {
                return "friday";
            }
            if (item == saturday)
            {
                return "saturday";
            }


            if (item == sunny)
            {
                return "sunny";
            }
            if (item == cloudy)
            {
                return "cloudy";
            }
            if ( item == partysunny)
            {
                return "partysunny";
            }
            if ( item == snow)
            {
                return "snow";
            }
            if (item == rain)
            {
                return "rain";
            }
           
            return string.Empty;
        }

        private View NameToMovableItem(string item)
        {
            if (item == "spring")
            {
                return spring;
            }
            if (item == "summer")
            {
                return summer;
            }
            if (item == "fall")
            {
                return fall;
            }
            if (item == "winter")
            {
                return winter;
            }

            if (item == "january")
            {
                return january;
            }
            if (item == "february")
            {
                return february;
            }
            if (item == "march")
            {
                return march;
            }
            if (item == "april")
            {
                return april;
            }
            if (item == "may")
            {
                return may;
            }
            if (item == "june")
            {
                return june;
            }
            if (item == "july")
            {
                return july;
            }
            if (item == "august")
            {
                return august;
            }
            if (item == "september")
            {
                return september;
            }
            if (item == "october")
            {
                return october;
            }
            if (item == "november")
            {
                return november;
            }
            if (item == "december")
            {
                return december;
            }


            if (item == "num0")
            {
                return num0;
            }
            if (item == "num1a")
            {
                return num1a;
            }
            if (item == "num1b")
            {
                return num1b;
            }
            if (item == "num2a")
            {
                return num2a;
            }
            if (item == "num2b")
            {
                return num2b;
            }
            if (item == "num3")
            {
                return num3;
            }
            if (item == "num4")
            {
                return num4;
            }
            if (item == "num5")
            {
                return num5;
            }
            if (item == "num6")
            {
                return num6;
            }
            if (item == "num7")
            {
                return num7;
            }
            if (item == "num8")
            {
                return num8;
            }
            if (item == "num9")
            {
                return num9;
            }


            if (item == "sunday")
            {
                return sunday;
            }
            if (item == "monday")
            {
                return monday;
            }
            if (item == "tuesday")
            {
                return tuesday;
            }
            if (item == "wednesday")
            {
                return wednesday;
            }
            if (item == "thursday")
            {
                return thursday;
            }
            if (item == "friday")
            {
                return friday;
            }
            if (item == "saturday")
            {
                return saturday;
            }


            if (item == "sunny")
            {
                return sunny;
            }
            if (item == "cloudy")
            {
                return cloudy;
            }
            if (item == "partysunny")
            {
                return partysunny;
            }
            if (item == "snow")
            {
                return snow;
            }
            if (item == "rain")
            {
                return rain;
            }
            return null;
        }
    
    }
}
