using Microsoft.AspNet.Identity;
using Over9000.Models.ServiceReviewModel;
using Over9000.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComputerStoreAPI.Controllers
{
    public class ServiceReviewController : ApiController
    {
        private ServiceReviewServices CreateServiceReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var srService = new ServiceReviewServices(userId);
            return srService;
        }
        public IHttpActionResult Get()
        {
            ServiceReviewServices srService = CreateServiceReviewService();
            var services = srService.GetServiceReviews();
            return Ok(services);
        }
        public IHttpActionResult Post(ServiceReviewCreate sr)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateServiceReviewService();
            if (!service.ServiceReviewCreate(sr))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(ServiceReviewEdit sr)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateServiceReviewService();
            if (!service.UpdateServiceReview(sr))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateServiceReviewService();
            if (!service.DeleteServiceReview(id))
                return InternalServerError();
            return Ok();
        }
    }
}
