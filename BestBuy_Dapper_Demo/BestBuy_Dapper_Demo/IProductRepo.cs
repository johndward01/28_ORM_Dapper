using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuy_Dapper_Demo
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string newName, double newPrice, int newCategoryID);
        public void UpdateProductName(int newProductID, string newUpdatedName);
        public void DeleteProduct(int productID);
    }
}
