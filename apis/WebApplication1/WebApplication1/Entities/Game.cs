using System;
using System.Collections.Generic;

namespace WebApplication1.Entities
{
    public partial class Game
    {
        public Game()
        {
            DepartmentGames = new HashSet<DepartmentGame>();
            EmployeeGames = new HashSet<EmployeeGame>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Series { get; set; } = null!;

        public virtual ICollection<DepartmentGame> DepartmentGames { get; set; }
        public virtual ICollection<EmployeeGame> EmployeeGames { get; set; }
    }
}
