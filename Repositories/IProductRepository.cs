using InventoryApp.Models;
/*
 This interface defines the contract for product data access.
*/
namespace InventoryApp.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Create(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}
