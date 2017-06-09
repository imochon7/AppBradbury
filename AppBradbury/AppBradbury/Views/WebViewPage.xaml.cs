using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBradbury.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBradbury.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        WebViewPageViewModel objVM;

        public WebViewPage(string sFilePath, INavigation inNavigation)
        {
            try
            {
                InitializeComponent();

                objVM = new WebViewPageViewModel(sFilePath, inNavigation);

                BindingContext = objVM;
            }
            catch (Exception ex)
            {

                throw new Exception("[WebViewPage] Error: " + ex.Message);
            }
        }

        protected override void OnDisappearing()
        {
            try
            {
                base.OnDisappearing();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}