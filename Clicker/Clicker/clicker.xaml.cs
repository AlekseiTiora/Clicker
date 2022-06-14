using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clicker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class clicker : ContentPage
    {
        Label lb;
        BoxView box;
        Button btn,btn2,btn3;
        Image img;
        Switch sw;
        int l = 0;
        int i = 0;
        public clicker()
        {
            this.BackgroundColor = Color.White;
            box = new BoxView()
            {

                Color = Color.Yellow,
                CornerRadius = 1000,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

            };
            lb = new Label()
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start

            };

            img = new Image { };
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            
            btn = new Button()
            {
                Text = "Salvesta progress"
            };
            

            btn2 = new Button()
            {
                Text="Bonus (100)",
                IsVisible = true
            };

            btn3 = new Button()
            {
                Text="uus fon(45)"
            };



            TapGestureRecognizer tap = new TapGestureRecognizer();
            btn.Clicked += Btn_Clicked;
            sw.Toggled += Sw_Toggled;
            btn2.Clicked += Btn2_Clicked;
            tap.Tapped += Tap_Tapped;
            btn3.Clicked += Btn3_Clicked;
            box.GestureRecognizers.Add(tap);
            img.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout { Children = { box,img,sw,btn,btn2,btn3 } };
            Content = st;
            st.Children.Add(lb);
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            if (i >=35)
            {
                i = i - 35;
                i += 1;
                lb.Text = "sina vajutasid: " + i.ToString();
                img.Source = "kirka.png";
                this.BackgroundImage = "almaz.jpg";
                box.IsVisible = false;
            }
            string value = i.ToString();
            Preferences.Set("Number", value);
            lb.Text = "Salvistamine " + value + " vajutatud edukalt!";
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (sw.IsToggled)
            {
                img.Source = "foto.png";
                this.BackgroundImage = "fon.jpg";
                img.IsVisible = true;
                box.IsVisible = false;
            }
            else
            {
                img.IsVisible = false;
                box.IsVisible = true;
                this.BackgroundImage = "fon.jpg";
            }
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            if (i >= 100)
            {
                i = i - 100;
                i += 2;
                lb.Text = "sina vajutasid: " + i.ToString();
                img.Source = "foto2.jpg";
                this.BackgroundImage = "fon2.jpg";
                btn2.IsVisible = false;
                box.IsVisible = false;
            }
            else { }
            string value = i.ToString();
            Preferences.Set("Number", value);
            lb.Text = "Salvistamine " + value + " vajutatud edukalt!";
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            string value = i.ToString();
            Preferences.Set("Number", value);
            
        }

        
        private void Tap_Tapped(object sender, EventArgs e)
        {
            i++;
            l++;
            if (img.IsVisible == true && box.IsVisible == false)
            {

                i += 2;
                if (l == 5)
                {
                    img.Source = "foto2.png";
                    this.BackgroundImage = "fon2.jpg";

                }
                else if (l == 10)
                {
                    img.IsVisible = false;
                    box.IsVisible = true;

                }
            }

            lb.Text = "sina vajutasid " + i;
            if (i >= 1)
            {
                try
                {
                    Vibration.Vibrate();
                    var duration = TimeSpan.FromSeconds(0.2);
                    Vibration.Vibrate(duration);
                }
                catch (FeatureNotEnabledException ex)
                {
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}