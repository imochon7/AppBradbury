using AppBradbury.Models;
using AppBradbury.Services;
using AppBradbury.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppBradbury.ViewModels
{
    public class ProductViewModel : BindableObject
    {
        private INavigation _navigation;

        public INavigation Navigation
        {
            get { return _navigation; }
            set { _navigation = value; }
        }

        private Book _product;

        public Book Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }

        public ProductViewModel(INavigation inNavigation)
        {
            try
            {
                Navigation = inNavigation;
            }
            catch (Exception ex)
            {

                throw new Exception("[ProductViewModel] Error: " + ex.Message);
            }
        }

        public ICommand viewPDFCommand
        {
            get
            {
                return new Command(ButtonViewPDFClicked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private async void ButtonViewPDFClicked(object obj)
        {
            try
            {
                Page loadingPage = new LoadingView();
                await Navigation.PushAsync(loadingPage);
                await DependencyService.Get<IPDFHandler>().OpenPDF(Product.UrlPDF, Navigation);
                Navigation.RemovePage(loadingPage);
            }
            catch (Exception ex)
            {

                throw new Exception("[ProductViewModel::ButtonViewPDFClicked] Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sSku"></param>
        /// <returns></returns>
        public async Task GetProductBySku(string sSku)
        {
            try
            {
                ProductService azureClient = new ProductService();
                Product = await azureClient.getProduct(sSku);
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("[ProductViewModel::GetProductBySky] Request error: " + httpEx.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("[ProductViewModel::GetProductBySku] Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GenerateProduct()
        {
            try
            {
                Product = new Book("abc123",
                    "The Martian Chronicles",
                    "Ray Bradbury",
                    "Booket",
                    2007,
                    "978-84-450-7653-8",
                    272,
                    "The Martian Chronicles is a 1950 science fiction short story collection by Ray Bradbury that chronicles the colonization of Mars by humans fleeing from a troubled and eventually atomically devastated Earth, and the conflict between aboriginal Martians and the new colonists. The book lies somewhere in between a short story collection and an episodic novel, containing stories Bradbury originally published in the late 1940s in science fiction magazines. The stories were loosely woven together with a series of short, interstitial vignettes for publication.",
                    9.95,
                    "https://imagessl8.casadellibro.com/a/l/t0/38/9788445076538.jpg",
                    "http://www.planetary.org/explore/resource-library/Intro-to-Bradbury-Martian-Chronicles-on-Visions-of-Mars.pdf");
            }
            catch (Exception ex)
            {

                throw new Exception("[ProductViewModel::GenerateProduct] Error: " + ex.Message);
            }
        }
    }
}
