using Over9000.Data;
using Over9000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace Over9000.Services
{
    public class AccountServices
    {
        private readonly Guid _userId;
        public AccountServices(Guid userId)
        {
            _userId = userId;
        }
        public bool AccountCreate(AccountCreate model)
        {
            var entity = new Account()
            {
                OwnerId = _userId,
                UserName = model.UserName,
                Email = model.Email,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Accounts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AccountListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Accounts.Where(e => e.OwnerId == _userId).Select(e => new AccountListItem
                {
                    AccountId = e.AccountId,
                    UserName = e.UserName,
                    CreatedUtc = e.CreatedUtc
                });
                return query.ToArray();
            }
        }
        public bool UpdateAccount(AccountEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Accounts.Single(e => e.AccountId == model.AccountId && e.OwnerId == _userId);
                entity.UserName = model.UserName;
                entity.Email = model.Email;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteNote(int accountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Accounts.Single(e => e.AccountId == accountId && e.OwnerId == _userId);
                ctx.Accounts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
*/