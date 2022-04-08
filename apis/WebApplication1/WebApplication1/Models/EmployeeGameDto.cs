using System;

namespace WebApplication1.Models
{
    public class EmployeeGameDto
    {
        //public int EmployeeId { get; set; }
        //public int GameId { get; set; }
        public DateTime BorrowDate { get; set; }
        public GameDto Game { get; set; }
    }
}
