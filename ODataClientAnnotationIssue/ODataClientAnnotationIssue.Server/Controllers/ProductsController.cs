using ODataClientAnnotationIssue.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace ODataClientAnnotationIssue.Server.Controllers
{
    public class ProductsController : ODataController
    {
        private IEnumerable<Product> products = new List<Product>
        {
            new Product { Name = "Toy" },
            new Product { Name = "Car" },
        };

        [EnableQuery]
        public IHttpActionResult GetProducts()
        {
            return Ok(products);
        }
    }
}