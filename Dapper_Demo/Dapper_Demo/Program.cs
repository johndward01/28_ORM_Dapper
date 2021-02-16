using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Dapper_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();


            var connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var department_repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Would you like to see all the current departments?");
            if (Console.ReadLine().ToLower() == "yes")
            {
                var departments = department_repo.GetAllDepartments();

                foreach (var department in departments)
                {
                    Console.WriteLine(department.Name);
                }
            }
           


        }
    }
}
