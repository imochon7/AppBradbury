using AppBradbury.Services;
using System.Net.Http;
using Xamarin.Forms;

namespace AppBradbury.Utilities
{
    class Utilities
    {
        /// <summary>
        /// Gestor de dependencias para obtener un cliente http
        /// </summary>
        /// <returns></returns>
        public static HttpClient obtenerClienteHTTP()
        {
            object objHandler = null;
            var objHandlerDependencyService = DependencyService.Get<IHttpHandler>();
            if (objHandlerDependencyService != null)
                objHandler = objHandlerDependencyService.getHttpHandler();
            else
            {
                objHandler = new HttpClientHandler();
            }

            return new HttpClient((HttpMessageHandler)objHandler);
        }
    }
}
