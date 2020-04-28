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
            var paymentId = int.Parse(User.Identity.GetUserId());
            var payService = new SavedPaymentInformationServices(paymentId);
            return payService;
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
    }
}