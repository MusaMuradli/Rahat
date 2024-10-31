using Microsoft.EntityFrameworkCore.Query;
using Rahat.Application.Dtos;
using Rahat.Domain.Entities;
using System.Linq.Expressions;

namespace Rahat.Application.Services.CategoryService;

public interface ICategoryService
{
    Task<CategoryDto?> GetAsync(int id);

    Task<CategoryDto?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);

    Task<CategoryListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null,
                                    Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
                                    Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
                                    int index = 0, int size = 10, bool enableTracking = true);

    Task<CategoryDto> AddAsync(CategoryCreateDto createDto);
    Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto updateDto);
    Task<CategoryDto> DeleteAsync(int id);
}
