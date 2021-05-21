using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuy_Dapper_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DapperDepartmentRepo(conn);
            var productRepo = new DapperProductRepo(conn);

            //-------------------------------------------------------------------------------------

            var departments = departmentRepo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
                Console.WriteLine();
            }

            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();
            //departmentRepo.InsertDepartment("Test Department");
            //departmentRepo.UpdateDepartment(13, "Test");



            //productRepo.CreateProduct("Test_Product", 100.59, 10);
            //productRepo.UpdateProductName(950, "Updated_Test_Product");
            //productRepo.DeleteProduct(950);

            var products = productRepo.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductID} {p.Name} {p.Price}");
                Console.WriteLine(); 
                Console.WriteLine(); 
            }


        }
    }
}
