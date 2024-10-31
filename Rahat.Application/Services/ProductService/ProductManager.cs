using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Rahat.Application.Dtos;
using Rahat.Application.Services.CategoryService;
using Rahat.Domain.Entities;
using Rahat.Persistencee.Repositories.Abstraction;
using System.Linq.Expressions;


namespace Rahat.Application.Services.ProductService;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public ProductManager(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public async Task<ProductDto> AddAsync(ProductCreateDto createDto)
    {
        var foundCategory = await _categoryService.GetAsync(createDto.CategoryId);
        if (foundCategory == null) throw new Exception("Category yoxdu");
        var studentEntity = _mapper.Map<Product>(createDto);
        var createdStudent = await _productRepository.AddAsync(studentEntity);
        return _mapper.Map<ProductDto>(createdStudent);
    }
    public async Task<ProductDto> DeleteAsync(int id)
    {
        var existProduct = await _productRepository.GetAsync(id);

        if (existProduct == null) throw new Exception("Not found");

        var deletedProduct = await _productRepository.DeleteAsync(existProduct);

        return _mapper.Map<ProductDto>(deletedProduct);
    }

    public async Task<ProductDto?> GetAsync(int id)
    {
        var productEntity = await _productRepository.GetAsync(id);

        if (productEntity == null) throw new Exception("Not found");

        return _mapper.Map<ProductDto>(productEntity);
    }
    public async Task<ProductDto?> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        var productEntity = await _productRepository.GetAsync(predicate, include);

        if (productEntity == null) throw new Exception("Not found");

        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task<ProductListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        var productListEntity = await _productRepository.GetListAsync(predicate, orderBy, include, index, size, enableTracking);

        if (productListEntity == null) throw new Exception("Not found");

        return _mapper.Map<ProductListDto>(productListEntity);
    }

    public async Task<ProductDto> UpdateAsync(int id, ProductUpdateDto updateDto)
    {
        var existProduct = await _productRepository.GetAsync(id);

        if (existProduct == null) throw new Exception("Not found");

        existProduct = _mapper.Map(updateDto, existProduct);

        var updatedProduct = await _productRepository.UpdateAsync(existProduct);

        return _mapper.Map<ProductDto>(updatedProduct);
    }
}
