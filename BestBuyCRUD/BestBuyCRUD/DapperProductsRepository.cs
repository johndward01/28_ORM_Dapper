using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using Dapper;

namespace BestBuyCRUD
{
    public class DapperProductsRepository : IProductRepository
    {
        public DapperProductsRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        private readonly IDbConnection _connection;
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;").ToList();
        }
        public void CreateProduct(string name, double price, int CategoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) Values (@Name, @Price, @CategoryID);", 
                new { name , price, CategoryID});
        }
        public void UpdateProduct(string name, int ID)
        {
            _connection.Execute("UPDATE Products SET Name = @Name, WHERE ProductID = @ID);", new { name, ID});
        }

        public void DeleteProduct(int ID)
        {
            _connection.Execute("DELETE FROM Products WHERE productID = @ID);", new { ID });
            _connection.Execute("DELETE FROM Sales Where productID = @ID);", new { ID });
            _connection.Execute("DELETE FROM Reviews WHERE productID = @ID);", new { ID });
        }

    }
}
