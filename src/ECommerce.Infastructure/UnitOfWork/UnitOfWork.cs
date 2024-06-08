
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.ServiceContracts;
using ECommerce.Infastructure.DbContexts;

namespace ECommerce.Infastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoriesRepository Categories { get; private set; }
        public IProductsRepository Products { get; private set; }

        public UnitOfWork(AppDbContext context, ICategoriesRepository categories, IProductsRepository products)
        {
            _context = context;
            Categories = categories;
            Products = products;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
