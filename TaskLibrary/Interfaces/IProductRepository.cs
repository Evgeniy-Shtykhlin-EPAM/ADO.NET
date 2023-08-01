using TaskLibrary.Entities;

namespace TaskLibrary.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product GetProductById(int id);
        public void UpdateProduct(Product product);
        public void AddProduct(Product product);
        public void DeleteProduct(int id);
    }
}
