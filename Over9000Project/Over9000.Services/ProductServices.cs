using Over9000.Data;
using Over9000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Services
{
    public class ProductServices
    {
        private readonly Guid _pUserId;
        public ProductServices(Guid pUserId)
        {
            _pUserId = pUserId;
        }
        public bool ProductAdd(ProductAdd model)
        {
            var entity = new Product()
            {
                OwnerId = _pUserId,
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                ProductDescription = model.ProductDescription,
                CreatedUtc = DateTimeOffset.Now,
                ProductReviewId = model.ProductReviewId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Where(e => e.OwnerId == _pUserId).Select(e => new ProductListItem
                {
                    ProductId = e.ProductId,
                    ProductName = e.ProductName,
                    ProductPrice = e.ProductPrice,
                    ProductDescription = e.ProductDescription,
                    ProductReviewId = e.ProductReviewId,
                    CreatedUtc = e.CreatedUtc,
                    ModifiedUtc = e.ModifiedUtc
                });
                return query.ToArray();
            }
        }
        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductId == model.ProductId && e.OwnerId == _pUserId);
                entity.ProductName = model.ProductName;
                entity.ProductPrice = model.ProductPrice;
                entity.ProductDescription = model.ProductDescription;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.ProductReviewId = model.ProductReviewId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductId == productId && e.OwnerId == _pUserId);
                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
