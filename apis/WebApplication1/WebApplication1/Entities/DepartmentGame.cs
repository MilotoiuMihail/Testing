using System;
using System.Collections.Generic;

namespace WebApplication1.Entities
{
    public partial class DepartmentGame
    {
        public int DepartmentId { get; set; }
        public int GameId { get; set; }
        public int AvailableNumber { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Game Game { get; set; } = null!;
    }
}
