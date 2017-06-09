using AppBradbury.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppBradbury.Services
{
    class ProductService
    {
        HttpClient client;

        public ProductService()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<Book> requestAPIProducts(Uri uri)
        {
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Book>(content);
                }
                else
                {
                    throw new HttpRequestException("Error: Unnable to connect with server.");
                }
            }
            catch (HttpRequestException httpEx)
            {
                throw new HttpRequestException(httpEx.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("[ProductsService::requestAPIProducts] Error downloading product: " + ex.Message);
            }
        }

        public async Task<Book> getProduct(string sku)
        {
            try
            {
                var uri = new Uri(string.Format("http://appqrapi.azurewebsites.net/api/products?sku={0}", sku));

                return await requestAPIProducts(uri);
            }
            catch (HttpRequestException httpEx)
            {
                throw new HttpRequestException(httpEx.Message);
            }
            catch (Exception ex)
            {
                
                throw new Exception("[ProductsService::getProduct] Error downloading product: " + ex.Message);
            }
        }
    }
}
