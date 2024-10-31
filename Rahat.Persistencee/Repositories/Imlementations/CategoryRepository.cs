using Core.Persistence.Repositories;
using Rahat.Domain.Entities;
using Rahat.Persistencee.Contexts;
using Rahat.Persistencee.Repositories.Abstraction;

namespace Rahat.Persistencee.Repositories.Imlementations;

public class CategoryRepository : EfRepositoryBase<Category, AppDbContext>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}