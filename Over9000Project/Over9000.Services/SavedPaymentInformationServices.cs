using Over9000.Data;
using Over9000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Services
{
    public class SavedPaymentInformationServices
    {
        private readonly int _paymentId;
        public SavedPaymentInformationServices(int paymentId)
        {
            _paymentId = paymentId;
        }
        public bool CreatePayment(SavedPaymentInformationCreate model)
        {
            var entity =
                new SavedPaymentInformation()
                {
                    SavedPaymentInformationId = _paymentId,
                    CardNumber = model.CardNumber,
                    SavedPaymentInformationName = model.SavedPaymentInformationName,
                    ExpirationDate = model.ExpirationDate,
                    CVV = model.CVV
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SavedPaymentInformations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SavedPaymentInformationListItem> GetPayment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SavedPaymentInformations
                    .Where(e => e.SavedPaymentInformationId == _paymentId)
                    .Select(
                        e =>
                        new SavedPaymentInformationListItem
                        {
                            
                            SavedPaymentInformationId = e.SavedPaymentInformationId,
                            CardNumber = e.CardNumber,
                            SavedPaymentInformationName = e.SavedPaymentInformationName,
                            ExpirationDate = e.ExpirationDate,
                            CVV = e.CVV
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
