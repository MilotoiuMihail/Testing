using System;
using System.Collections.Generic;

namespace WebApplication1.Entities
{
    public partial class Department
    {
        public Department()
        {
            DepartmentGames = new HashSet<DepartmentGame>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Adress { get; set; } = null!;

        public virtual ICollection<DepartmentGame> DepartmentGames { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
