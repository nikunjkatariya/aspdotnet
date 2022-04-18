using WithAuthorizationWithSwagger.Models;

namespace WithAuthorizationWithSwagger.Data
{
    public class ProductStore
    {
        private static Product[] products = new Product[]{
            new Product{ Id = 1, Name = "Rubber"},
            new Product{ Id = 2, Name = "Plastic"},
            new Product{ Id = 1, Name = "Sharpner"}
        };

        public static IEnumerable<Product>GetProducts()
        {
            return products;
        }

        public static Product? GetProduct(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }
    }
}