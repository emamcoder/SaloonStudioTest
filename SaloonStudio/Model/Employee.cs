using System;
namespace SaloonStudio.Model
{
    public class Employee
    {
        public Employee()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public Guid DepartmetId { get; set; }
    }
}
