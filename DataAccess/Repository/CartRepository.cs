using DataAccess;
using DataAccess.Reposetory.IReposetory;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace DataAccess.Reposetory
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Commit()
        {
            dbContext.SaveChanges(); // Save changes to the database
        }

        ////
        public IEnumerable<Cart> GetAll(Func<Cart, bool> predicate = null)
        {
            return dbContext.Set<Cart>().Where(predicate ?? (c => true));
        }

    }

}
