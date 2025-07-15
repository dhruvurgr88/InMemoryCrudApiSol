using Microsoft.AspNetCore.Mvc;
using InMemoryCrudApi.Models;
using InMemoryCrudApi.Repositories;

namespace InMemoryCrudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll() => ProductRepository.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = ProductRepository.Get(id);
        if (product == null) return NotFound();
        return product;
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        var created = ProductRepository.Create(product);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        var updated = ProductRepository.Update(id, product);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = ProductRepository.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
