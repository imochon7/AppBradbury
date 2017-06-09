using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBradbury.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppBradbury.ViewModels
{
    public class QRScannerViewModel : BindableObject
    {
        private INavigation _navigation;

        public INavigation Navigation
        {
            get { return _navigation; }
            set { _navigation = value; }
        }

        public QRScannerViewModel(INavigation inNavigation)
        {
            Navigation = inNavigation;
        }

        public ICommand scanCommand
        {
            get
            {
                return new Command(ButtonClickedScan);
            }
        }

        private async void ButtonClickedScan(object obj)
        {
            try
            {
                await Navigation.PushAsync(new CustomScanPage());
            }
            catch (Exception ex)
            {

                throw new Exception("[QRScannerViewModel::ButtonClickedScan] Error: " + ex.Message);
            }
        }
    }
}
