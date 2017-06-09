using System;
using System.Threading.Tasks;
using AppBradbury.Services;
using Xamarin.Forms;
using AppBradbury.Models;
using AppBradbury.Views;
using AppBradbury.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(PDFHandler))]
namespace AppBradbury.Droid.Services
{
    public class PDFHandler : IPDFHandler
    {
        public async Task OpenPDF(string sUrl, INavigation inNavigation)
        {
            try
            {
                string filePath = await FileCache.saveFileMemory(sUrl);
                await inNavigation.PushAsync(new WebViewPage(filePath, inNavigation));
            }
            catch (Exception ex)
            {
                throw new Exception("[PDFHandler::OpenPDF] Error: " + ex.Message);
            }
        }
    }
}