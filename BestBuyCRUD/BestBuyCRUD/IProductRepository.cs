using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using System.Data;

namespace BestBuyCRUD
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string name, double price, int categoryID);
        public void UpdateProduct(string name, int ID);
        public void DeleteProduct(int ID);
    }
}
