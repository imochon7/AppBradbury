using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBradbury.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBradbury.Utilities;
using System.Net.Http;

namespace AppBradbury.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductView : ContentPage
    {
        ProductViewModel objVM;
        Preferences AppColors = new Preferences();
        public string ProductSku { get; set; }

        public ProductView(string sSku)
        {
            try
            {
                InitializeComponent();

                this.BackgroundColor = Color.Azure;

                ProductSku = sSku;

                objVM = new ProductViewModel(this.Navigation);
            }
            catch (Exception ex)
            {

                throw new Exception("[ProductView] Error: " + ex.Message);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                if(objVM.Product == null)
                {                    
                    if(ProductSku != "abc123")
                    {
                        await Navigation.PushAsync(new LoadingView());
                        await objVM.GetProductBySku(ProductSku);
                        Navigation.PopAsync();

                        if (objVM.Product.Sku != null)
                        {
                            BindingContext = objVM;
                        }
                        else
                        {
                            DisplayErrorMessage("Product not found.");
                            await Navigation.PopAsync();
                        }
                    }
                    else
                    {
                        objVM.GenerateProduct();
                        BindingContext = objVM;
                    }
                }
                //mainScrollView.IsVisible = true;
            }
            catch (HttpRequestException httpEx)
            {
                DisplayAlert("Oops...", httpEx.Message, "Ok");
                Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {

                DisplayErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sMessage"></param>
        private void DisplayErrorMessage(string sMessage)
        {
            DisplayAlert("Oops...", "Error: " + sMessage, "Ok");
        }
    }
}