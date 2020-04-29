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
    public class ProductReviewController : ApiController
    {
        private ProductReviewsServices CreateProductReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var prService = new ProductReviewsServices(userId);
            return prService;
        }
        public IHttpActionResult Get()
        {
            ProductReviewsServices prService = CreateProductReviewService();
            var services = prService.GetProductReviews();
            return Ok(services);
        }
        public IHttpActionResult Post(ProductReviewsAdd productReview)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateProductReviewService();
            if (!service.ProductReviewAdd(productReview))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(ProductReviewsEdit productReview)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateProductReviewService();
            if (!service.UpdateProductReview(productReview))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductReviewService();
            if (!service.DeleteProductReview(id))
                return InternalServerError();
            return Ok();
        }
    }
}
