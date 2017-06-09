using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppQRAPI.Models;

namespace AppQRAPI.Controllers
{
    public class productsController : ApiController
    {
        // GET: api/products/5
        public Book Get(string sku)
        {
            return new Book(sku);
        }
    }
}
