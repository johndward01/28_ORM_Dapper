using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace BestBuyCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            var departmentRepo = new DapperDepartmentRepository(conn);

            var productRepo = new DapperProductsRepository(conn);

            Console.WriteLine("What is the name of your new product?");
            var productName = Console.ReadLine();

            Console.WriteLine("What is the product's price?");
            var productPrice = Double.Parse(Console.ReadLine());

            Console.WriteLine("What is the product's category ID?");
            var productID = Int32.Parse(Console.ReadLine());

            productRepo.CreateProduct(productName, productPrice, productID);

            var products = productRepo.GetAllProducts();

            Console.WriteLine("Name --- Price --- ID");
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Name}  {prod.Price}  {prod.ID}");
            }

            
            Console.WriteLine("What is the name of the product you would like to update?");
            var updatedProductName = Console.ReadLine();

            Console.WriteLine("What is the product ID number?");
            var updatedProductID = Int32.Parse(Console.ReadLine());

            productRepo.UpdateProduct(updatedProductName, updatedProductID);                              
                

            Console.WriteLine("What is the new dapartment's name?");
            var response = Console.ReadLine();

            departmentRepo.InsertNewDepartment(response);

            var departments = departmentRepo.GetAllDepartments();

            Console.WriteLine("ID --- NAME");
            foreach(var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID}  {dept.Name} ");
            }
        }

        static IEnumerable GetAllDepartments()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Departments;";

            using (conn)
            {
                conn.Open();
                List<string> allDepartments = new List<string>();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    var currentDepartment = reader.GetString("Name");
                    allDepartments.Add(currentDepartment);
                }

                return allDepartments;
            }
        }
    }
}
