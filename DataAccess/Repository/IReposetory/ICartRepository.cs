using DataAccess.Repository;
using DataAccsess.Reposetory.IReposetory;
using Models;
namespace DataAccess.Reposetory.IReposetory
{
    public interface ICartRepository : IRepository<Cart>
    {
        void Commit();

        public interface ICartRepository : IRepository<Cart>
        {
            void Commit();
            IEnumerable<Cart> GetAll(Func<Cart, bool> predicate = null);
        }





    }
  
}
