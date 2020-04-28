using Over9000.Data;
using Over9000.Models.ServiceReviewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Services
{
    public class ServiceReviewServices
    {
        private readonly Guid _srUserId;
        public ServiceReviewServices(Guid srUserId)
        {
            _srUserId = srUserId;
        }
        public bool ServiceReviewCreate(ServiceReviewCreate model)
        {
            var entity = new ServiceReview()
            {
                ServiceReviewOwnerId = _srUserId,
                ServiceReviewTitle = model.ServiceReviewTitle,
                ServiceReviewText = model.ServiceReviewText,
                ServiceReviewStars = model.ServiceReviewStars,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ServiceReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ServiceReviewListItem> GetServiceReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ServiceReviews.Where(e => e.ServiceReviewOwnerId == _srUserId).Select(e => new ServiceReviewListItem
                {
                    ServiceReviewId = e.ServiceReviewId,
                    ServiceReviewTitle = e.ServiceReviewTitle,
                    ServiceReviewText = e.ServiceReviewText,
                    ServiceReviewStars = e.ServiceReviewStars,
                    ModifiedUtc = e.ModifiedUtc
                });
                return query.ToArray();
            }
        }
        public bool UpdateServiceReview(ServiceReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ServiceReviews.Single(e => e.ServiceReviewId == model.ServiceReviewId && e.ServiceReviewOwnerId == _srUserId);
                entity.ServiceReviewTitle = model.ServiceReviewTitle;
                entity.ServiceReviewText = model.ServiceReviewText;
                entity.ServiceReviewStars = model.ServiceReviewStars;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteServiceReview(int serviceReviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ServiceReviews.Single(e => e.ServiceReviewId == serviceReviewId && e.ServiceReviewOwnerId == _srUserId);
                ctx.ServiceReviews.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
