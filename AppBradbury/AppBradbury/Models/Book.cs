using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBradbury.Models
{
    public class Book
    {
        public string Sku { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Editorial { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Synopsis { get; set; }
        public double Price { get; set; }
        public string UrlCover { get; set; }
        public string UrlPDF { get; set; }

        public Book(string sSku = null, string sTitle = null, string sAuthor = null,
            string sEditorial = null, int iYear = 0, string sISBN = null,
            int iPages = 0, string sSynopsis = null, double dPrice = 0, string sUrlCover = null, string sUrlPDF = null)
        {
            Sku = sSku;
            Title = sTitle;
            Author = sAuthor;
            Editorial = sEditorial;
            Year = iYear;
            ISBN = sISBN;
            Pages = iPages;
            Synopsis = sSynopsis;
            Price = dPrice;
            UrlCover = sUrlCover;
            UrlPDF = sUrlPDF;
        }
    }
}
