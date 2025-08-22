using InventoryApp.Models;
/*
 This class provides an in-memory implementation of the IProductRepository interface.
 It stores products in a list and supports basic CRUD operations.
*/

namespace InventoryApp.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        // Get all products in the inventory
        public IEnumerable<Product> GetAll() => _products;

        // Get a product by ID
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        // Create a new product
        public void Create(Product product)
        {
            // Check if a product with the same name already exists
            if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                // Throw an exception or return a value indicating the failure
                throw new InvalidOperationException("A product with this name already exists.");
            }
            product.Id = _nextId++;
            _products.Add(product);
        }
        // Update any data in an existing product
        public bool Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing == null) return false;

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;
            return true;
        }
        // Delete a product by ID
        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
