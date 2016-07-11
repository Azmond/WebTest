using System.ComponentModel.DataAnnotations;

namespace zadanie1.Models
{
    public class MData
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
