using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ArtShop.Business;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/Product")]
    public class ProductService:ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public List<Product> List()
        {
            try
            {
                var bc = new ProductComponent();
                return bc.List();
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Agregar")]
        public Product Add(Product product)
        {
            try
            {
                var bc = new ProductComponent();
                return bc.Add(product);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
