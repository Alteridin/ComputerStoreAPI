using Over9000.Data;
using Over9000.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Services
{
    public class ServiceServices
    {
        private readonly Guid _sUserId;
        public ServiceServices(Guid sUserId)
        {
            _sUserId = sUserId;
        }
        public bool ServiceCreate(ServiceCreate model)
        {
            var entity = new Service()
            {
                ServiceOwnerId = _sUserId,
                ServiceName = model.ServiceName,
                ServicePrice = model.ServicePrice,
                ServiceDescription = model.ServiceDescription,
                CreatedUtc = DateTimeOffset.Now,
                ServiceReviewId = model.ServiceReviewId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Services.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ServiceListItem> GetServices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Services.Where(e => e.ServiceOwnerId == _sUserId).Select(e => new ServiceListItem
                {
                    ServiceId = e.ServiceId,
                    ServiceName = e.ServiceName,
                    ServicePrice = e.ServicePrice,
                    ServiceDescription = e.ServiceDescription,
                    CreatedUtc = e.CreatedUtc,
                    ModifiedUtc = e.ModifiedUtc,
                    ServiceReviewId = e.ServiceReviewId
                });
                return query.ToArray();
            }
        }
        public bool UpdateService(ServiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Services.Single(e => e.ServiceId == model.ServiceId && e.ServiceOwnerId == _sUserId);
                entity.ServiceName = model.ServiceName;
                entity.ServicePrice = model.ServicePrice;
                entity.ServiceDescription = model.ServiceDescription;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.ServiceReviewId = model.ServiceReviewId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteService(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Services.Single(e => e.ServiceId == serviceId && e.ServiceOwnerId == _sUserId);
                ctx.Services.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
