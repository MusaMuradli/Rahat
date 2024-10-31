using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Rahat.Application.Dtos;
using Rahat.Domain.Entities;
using Rahat.Persistencee.Repositories.Abstraction;
using Rahat.Persistencee.Repositories.Imlementations;
using System.Linq.Expressions;

namespace Rahat.Application.Services.CategoryService;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> AddAsync(CategoryCreateDto createDto)
    {
        var categoryEntity = _mapper.Map<Category>(createDto);
        var createdCategory = await _categoryRepository.AddAsync(categoryEntity);
        return _mapper.Map<CategoryDto>(createdCategory);
    }

    public async Task<CategoryDto> DeleteAsync(int id)
    {
        var existCategory = await _categoryRepository.GetAsync(id);

        if (existCategory == null) throw new Exception("Not found");

        var deletedCategory = await _categoryRepository.DeleteAsync(existCategory);

        return _mapper.Map<CategoryDto>(deletedCategory);
    }

    public async Task<CategoryDto?> GetAsync(int id)
    {
        var categoryEntity = await _categoryRepository.GetAsync(id);

        if (categoryEntity == null) throw new Exception("Not found");

        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task<CategoryDto?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        var categoryEntity = await _categoryRepository.GetAsync(predicate, include);

        if (categoryEntity == null) throw new Exception("Not found");

        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task<CategoryListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        var categoryListEntity = await _categoryRepository.GetListAsync(predicate, orderBy, include, index, size, enableTracking);

        if (categoryListEntity == null) throw new Exception("Not found");

        return _mapper.Map<CategoryListDto>(categoryListEntity);
    }

    public async Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto updateDto)
    {
        var existCategory = await _categoryRepository.GetAsync(id);

        if (existCategory == null) throw new Exception("Not found");

        existCategory = _mapper.Map(updateDto, existCategory);

        var updatedCategory = await _categoryRepository.UpdateAsync(existCategory);

        return _mapper.Map<CategoryDto>(updatedCategory);
    }
}
