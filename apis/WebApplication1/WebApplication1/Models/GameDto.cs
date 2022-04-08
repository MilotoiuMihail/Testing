using System;

namespace WebApplication1.Models
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Series { get; set; } = null!;
    }
}
