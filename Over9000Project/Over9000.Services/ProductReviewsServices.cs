using Over9000.Data;
using Over9000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Services
{
    public class ProductReviewsServices
    {
        private readonly Guid _prUserId;
        public ProductReviewsServices(Guid prUserId)
        {
            _prUserId = prUserId;
        }
        public bool ProductReviewAdd(ProductReviewsAdd model)
        {
            var entity = new ProductReview()
            {
                ReviewOwnerId = _prUserId,
                ReviewTitle = model.ReviewTitle,
                ReviewText = model.ReviewText,
                ReviewStars = model.ReviewStars,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductReviewsListItem> GetProductReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ProductReviews.Where(e => e.ReviewOwnerId == _prUserId).Select(e => new ProductReviewsListItem
                {
                    ProductReviewId = e.ProductReviewId,
                    ReviewTitle = e.ReviewTitle,
                    ReviewText = e.ReviewText,
                    ReviewStars = e.ReviewStars,
                    ModifiedUtc = e.ModifiedUtc
                });
                return query.ToArray();
            }
        }
        public bool UpdateProductReview(ProductReviewsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ProductReviews.Single(e => e.ProductReviewId == model.ProductReviewId && e.ReviewOwnerId == _prUserId);
                entity.ReviewTitle = model.ReviewTitle;
                entity.ReviewText = model.ReviewText;
                entity.ReviewStars = model.ReviewStars;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProductReview(int productReviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ProductReviews.Single(e => e.ProductReviewId == productReviewId && e.ReviewOwnerId == _prUserId);
                ctx.ProductReviews.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
