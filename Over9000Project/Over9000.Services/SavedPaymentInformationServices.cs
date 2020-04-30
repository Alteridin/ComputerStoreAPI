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
        //change paymentId to user
        private readonly Guid _userId; 
        public SavedPaymentInformationServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePayment(SavedPaymentInformationCreate model)
        {
            var entity =
                new SavedPaymentInformation()
                {
                    OwnerId = _userId,
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
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new SavedPaymentInformationListItem
                        {
                            OwnerId = e.OwnerId,                            
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

        public bool UpdatePaymentInformation(SavedPaymentInformationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.SavedPaymentInformations.Single(e => e.OwnerId == model.OwnerId && e.OwnerId == _userId);
                entity.CardNumber = model.CardNumber;
                entity.SavedPaymentInformationName = model.SavedPaymentInformationName;
                entity.ExpirationDate = model.ExpirationDate;
                entity.CVV = model.CVV;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePaymentInformation(int payId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.SavedPaymentInformations.Single(e => e.SavedPaymentInformationId == payId && e.OwnerId == _userId);
                ctx.SavedPaymentInformations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
