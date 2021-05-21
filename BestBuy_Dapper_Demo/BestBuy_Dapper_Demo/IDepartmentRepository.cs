using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuy_Dapper_Demo
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        public Department GetDepartment(int id);
        public void InsertDepartment(string newDepartmentName);
        public void UpdateDepartment(int id, string newName);
        public void DeleteDepartment(int id);
        //public void DeleteDepartments(int start, int end);

    }
}
