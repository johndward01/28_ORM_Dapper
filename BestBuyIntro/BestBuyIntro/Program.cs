using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BestBuyIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME!\n   Press Enter to Continue:");
            var response = Console.ReadLine().ToUpper();
            do
            {

                Console.WriteLine("Would you like to add a new Department?");
                Console.WriteLine("\n   Type Y for yes or U to update a current Department.\n   (At any time type Exit to exit the program)");

                response = Console.ReadLine().ToUpper();

                if (response == "Y")
                {
                    Console.WriteLine("What is the name of the new department?");

                    var departmentName = Console.ReadLine();
                    CreateDepartment(departmentName);
                }

                if (response == "U")
                {
                    Console.WriteLine("Which department would you like to update?");
                    var oldDepartmentName = Console.ReadLine();

                    Console.WriteLine("What is it's updated name?");
                    var updatedDepartmentName = Console.ReadLine();

                    UpdateDepartment(oldDepartmentName, updatedDepartmentName);
                }
            }
            while (response != "EXIT");
                        

            var departments = GetAllDepartments();

            foreach(var dept in departments)
            {
                Console.WriteLine(dept);
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
                List<String> allDepartments = new List<string>();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    var currentDepartment = reader.GetString("Name");
                    allDepartments.Add(currentDepartment);
                }

                return allDepartments;
            }
        }

        static void CreateDepartment(string departmentName)
        {
            var connStr = System.IO.File.ReadAllText("ConnectionString.txt");

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO departments (Name) VALUES (@departmentName);";
                cmd.Parameters.AddWithValue("departmentName", departmentName);
                cmd.ExecuteNonQuery();
            }
        }

        static void UpdateDepartment(string currentDepartmentName, string newDepartmentName)
        {
            var connStr = System.IO.File.ReadAllText("ConnectionString.txt");

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Departments SET Name = @newDepartmentName WHERE Name = @currentDepartmentName;";
                cmd.Parameters.AddWithValue("currentDepartmentName", currentDepartmentName);
                cmd.Parameters.AddWithValue("newDepartmentName", newDepartmentName);
                cmd.ExecuteNonQuery();
            }
            
        }
    }
}