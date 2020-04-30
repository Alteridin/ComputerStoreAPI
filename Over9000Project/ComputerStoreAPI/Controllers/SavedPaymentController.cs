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
    public class SavedPaymentController : ApiController
    {
        private SavedPaymentInformationServices CreatePayment()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var pService = new SavedPaymentInformationServices(ownerId);
            return pService;
        }
        public IHttpActionResult Get()
        {
            SavedPaymentInformationServices payService = CreatePayment();
            var pay = payService.GetPayment();
            return Ok(pay);
        }
        public IHttpActionResult Post(SavedPaymentInformationCreate pay)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePayment();

            if (!service.CreatePayment(pay))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SavedPaymentInformationEdit sr)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePayment();
            if (!service.UpdatePaymentInformation(sr))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePayment();
            if (!service.DeletePaymentInformation(id))
                return InternalServerError();
            return Ok();
        }
    }
}