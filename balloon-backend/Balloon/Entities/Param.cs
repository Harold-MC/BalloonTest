using System.ComponentModel.DataAnnotations;

namespace Balloon.Entities
{
    public class Param
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public double Diameter { get; set; }
    }
}