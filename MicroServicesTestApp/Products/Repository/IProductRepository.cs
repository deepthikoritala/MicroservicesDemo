using Products.Models;

namespace Products.Repository
{
    public interface IProductRepository
    {
        void DeleteProduct(int productId);
        Product GetProductByID(int productId);
        IEnumerable<Product> GetProducts();
        IEnumerable<Category> GetCategories();
        void InsertProduct(Product product);
        void Save();
        void UpdateProduct(Product product);
    }
}
