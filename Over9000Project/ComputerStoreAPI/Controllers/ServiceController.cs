using Microsoft.AspNet.Identity;
using Over9000.Models.ServiceModel;
using Over9000.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComputerStoreAPI.Controllers
{
    public class ServiceController : ApiController
    {
        private ServiceServices CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var serviceService = new ServiceServices(userId);
            return serviceService;
        }
        public IHttpActionResult Get()
        {
            ServiceServices serviceService = CreateServiceService();
            var services = serviceService.GetServices();
            return Ok(services);
        }
        public IHttpActionResult Post(ServiceCreate servicez)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateServiceService();
            if (!service.ServiceCreate(servicez))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(ServiceEdit servicez)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateServiceService();
            if (!service.UpdateService(servicez))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateServiceService();
            if (!service.DeleteService(id))
                return InternalServerError();
            return Ok();
        }
    }
}
