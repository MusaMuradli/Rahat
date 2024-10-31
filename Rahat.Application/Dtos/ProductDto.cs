using Core.Persistence.Paging;

namespace Rahat.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MyProperty { get; set; }

    }
    public class ProductCreateDto
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
    }
    public class ProductUpdateDto
    {
        public  string? Name { get; set; }
        public int Price { get; set; }
    }
    public class ProductListDto : BasePageableDto, IDto
    {
        public List<ProductDto> Items { get; set; } = [];
    }
}
