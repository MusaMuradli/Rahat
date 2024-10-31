using Core.Persistence.Repositories;

namespace Rahat.Domain.Entities;

public class Product:Entity
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
}
