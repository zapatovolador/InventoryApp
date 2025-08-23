using InventoryApp.Models;
using InventoryApp.Repositories;
using Microsoft.AspNetCore.Mvc;
/*
 This controller handles HTTP requests for product operations.
*/
namespace InventoryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Injecting the repository interface, exposing endpoints for CRUD operations
        private readonly IProductRepository _repository;

        // Adding a logger to log important actions and errors
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // retrieving all data from the repository, GET /api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all products");
            return Ok(_repository.GetAll());
        }
        // retrieving a single product by its ID, GET /api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                _logger.LogWarning("Product not found: {Id}", id);
                return NotFound();
            }

            return Ok(product);
        }
        // creating a new product, POST /api/products
        [HttpPost]
        public IActionResult Create(Product product)
        {
            // Data entry validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repository.Create(product);
                _logger.LogInformation("Product added: {Name}", product.Name);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (InvalidOperationException ex)
            {
                // Log the error and return a 409 Conflict status code
                _logger.LogWarning("Failed to add product: {Message}", ex.Message);
                return Conflict(new { message = ex.Message });
            }
            
        }
        // updating an existing product, PUT /api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            // Data entry validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = id;
            if (!_repository.Update(product))
            {
                _logger.LogWarning("Product not found for update: {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Product updated: {Id}", id);
            return Ok(product);
        }
        // deleting a product by its ID, DELETE /api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repository.Delete(id))
            {
                _logger.LogWarning("Product not found for deletion: {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Product deleted: {Id}", id);
            return NoContent();
        }
    }
}
