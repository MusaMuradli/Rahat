using Core.Persistence.Paging;
using Rahat.Domain.Entities;

namespace Rahat.Application.Dtos;

public class CategoryDto:IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<ProductDto> Products { get; set; } = [];
}
public class CategoryCreateDto : IDto
{
    public required string Name { get; set; }
}
public class CategoryUpdateDto : IDto
{
    public  string? Name { get; set; }
}
public class CategoryListDto : BasePageableDto, IDto
{
    public List<CategoryDto> Items { get; set; } = [];
}