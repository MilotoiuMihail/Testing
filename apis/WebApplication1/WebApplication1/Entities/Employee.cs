using System;
using System.Collections.Generic;

namespace WebApplication1.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeGames = new HashSet<EmployeeGame>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Department { get; set; }

        public virtual Department DepartmentNavigation { get; set; } = null!;
        public virtual ICollection<EmployeeGame> EmployeeGames { get; set; }
    }
}
