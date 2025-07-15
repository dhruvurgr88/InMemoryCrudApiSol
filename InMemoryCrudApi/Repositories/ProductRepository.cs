using InMemoryCrudApi.Models;

namespace InMemoryCrudApi.Repositories;

public static class ProductRepository
{
    private static readonly List<Product> Products;
    private static int _nextId;

    static ProductRepository()
    {
        // Initialize seed data
        Products = new List<Product>
        {
            new Product { Id = 1, Name = "Keyboard", Price = 49.99M },
            new Product { Id = 2, Name = "Monitor", Price = 199.99M },
            new Product { Id = 3, Name = "USB Cable", Price = 9.99M }
        };

        _nextId = Products.Max(p => p.Id) + 1;
    }

    public static List<Product> GetAll() => Products;

    public static Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);

    public static Product Create(Product product)
    {
        product.Id = _nextId++;
        Products.Add(product);
        return product;
    }

    public static bool Update(int id, Product updatedProduct)
    {
        var existing = Get(id);
        if (existing is null) return false;

        existing.Name = updatedProduct.Name;
        existing.Price = updatedProduct.Price;
        return true;
    }

    public static bool Delete(int id)
    {
        var product = Get(id);
        if (product is null) return false;
        return Products.Remove(product);
    }
}
