using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPracticeConsoleUI
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }
}
