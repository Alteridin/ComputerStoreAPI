using Microsoft.AspNet.Identity;
using Over9000.Models;
using Over9000.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComputerStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        private ProductServices CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductServices(userId);
            return productService;
        }
        public IHttpActionResult Get()
        {
            ProductServices productService = CreateProductService();
            var services = productService.GetProducts();
            return Ok(services);
        }
        public IHttpActionResult Post(ProductAdd product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateProductService();
            if (!service.ProductAdd(product))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(ProductEdit products)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateProductService();
            if (!service.UpdateProduct(products))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();
            if (!service.DeleteProduct(id))
                return InternalServerError();
            return Ok();
        }
    }
}
