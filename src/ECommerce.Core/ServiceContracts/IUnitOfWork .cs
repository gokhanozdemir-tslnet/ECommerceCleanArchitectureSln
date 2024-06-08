

using ECommerce.Core.Domain.RepositoryContracts;

namespace ECommerce.Core.ServiceContracts
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoriesRepository Categories { get; }
        IProductsRepository Products { get; }
        int Complete();
    }
}
