using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuy_Dapper_Demo
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

    }
}
