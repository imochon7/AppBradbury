using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBradbury.ViewModels
{
    public class WebViewPageViewModel : BindableObject
    {
        private INavigation _navigation;
        private string _pdfSource;

        public INavigation Navigation
        {
            get { return _navigation; }
            set { _navigation = value; }
        }

        public string PDFSource
        {
            get { return _pdfSource; }
            set
            {
                _pdfSource = value;
                OnPropertyChanged("PDFSource");
            }
        }

        public WebViewPageViewModel(string sFilePath, INavigation inNavigation)
        {
            PDFSource = sFilePath;
            Navigation = inNavigation;
        }
    }
}
