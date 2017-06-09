using AppBradbury.Utilities;
using AppBradbury.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBradbury.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScannerView : ContentPage
    {
        Preferences AppColors = new Preferences();

        public QRScannerView()
        {
            InitializeComponent();

            this.BackgroundColor = AppColors.PrimaryColor;

            BindingContext = new QRScannerViewModel(this.Navigation);
        }
    }
}