using Core.Persistence.Repositories;
using Rahat.Domain.Entities;
using Rahat.Persistencee.Contexts;
using Rahat.Persistencee.Repositories.Abstraction;

namespace Rahat.Persistencee.Repositories.Imlementations;

public class ProductRepository: EfRepositoryBase<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
