using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBradbury.Services
{
    /// <summary>
    /// Interfaz para el gestor de dependencias.
    /// </summary>
    public interface IPDFHandler
    {
        Task OpenPDF(string sUrl, INavigation inNavigation);
    }
}
