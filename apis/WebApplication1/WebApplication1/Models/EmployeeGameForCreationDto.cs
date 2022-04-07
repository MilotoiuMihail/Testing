using System;

namespace WebApplication1.Models
{
    public class EmployeeGameForCreationDto
    {
        public int EmployeeId { get; set; }
        public int GameId { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
