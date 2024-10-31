using Core.Persistence.Repositories;

namespace Rahat.Domain.Entities;

public class Category:Entity
{
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
