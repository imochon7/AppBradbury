using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppBradbury.Views;
using Xamarin.Forms;
using AppBradbury.Utilities;

namespace AppBradbury
{
    public partial class App : Application
    {
        public App()
        {
            Preferences AppColors = new Preferences();

            #region STYLES

            // buttons
            var styleButton = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter { Property = Button.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Medium, typeof(Button)) },
                    new Setter { Property = Button.TextColorProperty, Value = Color.White },
                    new Setter { Property = Button.BackgroundColorProperty, Value = AppColors.SecondaryColor },
                }
            };

            // layout

            var styleLayout = new Style(typeof(StackLayout))
            {
                Setters =
                {
                    new Setter { Property = StackLayout.BackgroundColorProperty, Value = AppColors.PrimaryColor },
                }
            };

            // labels
            var styleLabelWhite = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.White },
                }
            };

            var styleLabelWhiteDefault = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Default, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.White },
                }
            };

            var styleLabelWhiteLarge = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.White },
                }
            };

            var styleLabelTitle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                }
            };

            var styleLabelAuthor = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.Default },
                }
            };

            var styleLabelRegular = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Default, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.Default },
                }
            };

            var styleLabelBlack = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Default, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                }
            };

            // static resource
            Resources = new ResourceDictionary();
            Resources.Add("styleButton", styleButton);
            Resources.Add("styleLayout", styleLayout);
            Resources.Add("styleLabelWhite", styleLabelWhite);
            Resources.Add("styleLabelWhiteDefault", styleLabelWhiteDefault);
            Resources.Add("styleLabelWhiteLarge", styleLabelWhiteLarge);
            Resources.Add("styleLabelTitle", styleLabelTitle);
            Resources.Add("styleLabelAuthor", styleLabelAuthor);
            Resources.Add("styleLabelRegular", styleLabelRegular);
            Resources.Add("styleLabelBlack", styleLabelBlack);

            #endregion

            InitializeComponent();

            MainPage = new NavigationPage(new QRScannerView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
