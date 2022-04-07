using System;
using System.Collections.Generic;

namespace WebApplication1.Entities
{
    public partial class EmployeeGame
    {
        public int EmployeeId { get; set; }
        public int GameId { get; set; }
        public DateTime BorrowDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Game Game { get; set; } = null!;
    }
}
