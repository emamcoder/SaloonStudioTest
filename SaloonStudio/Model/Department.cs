using System;
using System.Collections.Generic;

namespace SaloonStudio.Model
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HashSet<Employee> Employees { get; private set; }
    }
}
