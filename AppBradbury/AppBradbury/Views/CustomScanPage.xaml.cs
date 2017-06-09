using AppBradbury.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace AppBradbury.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomScanPage : ContentPage
    {
        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
        Preferences AppColors = new Preferences();

        public bool flag = true;

        // ...
        public CustomScanPage() : base()
        {
            this.Title = "Scanning";
            this.BackgroundColor = AppColors.PrimaryColor;

            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            zxing.OnScanResult += Zxing_OnScanResult;

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the QR code",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = zxing.HasTorch,
            };

            overlay.FlashButtonClicked += (sender, e) =>
            {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            grid.Children.Add(zxing);
            grid.Children.Add(overlay);

            Content = grid;
        }

        // ...
        private void Zxing_OnScanResult(ZXing.Result result)
        {
            try
            {
                if (flag)
                {
                    flag = false;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        zxing.IsAnalyzing = false;

                        Navigation.InsertPageBefore(new ProductView(result.Text), this);
                        await Navigation.PopAsync();
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[CustomScanPage::Zxing_OnScanResult] Error: " + ex.Message);
            }
        }

        // ...
        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}