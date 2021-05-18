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
            var config = StartUp.Setup();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepo(conn);

            //var departments = repo.GetAllDepartments();

            //foreach (var dept in departments)
            //{
            //    Console.WriteLine($"DepartmentID: {dept.DepartmentID}");
            //    Console.WriteLine($"Name: {dept.Name}");
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //repo.InsertDepartment("Test Department");
            //repo.UpdateDepartment("Appliances", 14);
            //repo.UpdateDepartment(13, "Test");
            repo.DeleteDepartment()

            
        }
    }
}
