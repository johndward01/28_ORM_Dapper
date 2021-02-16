using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPracticeConsoleUI
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string name, double price, int categoryID);
        public Product GetProduct(int productID);//Update method helper
        public void UpdateProduct(Product product); // Bonus
        public Product ShowUpdatedProduct(int productID); //Bonus x 3
        public void DeleteProduct(int productID); //Bonus x 2
    }
}
