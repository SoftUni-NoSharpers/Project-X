using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Hall> Halls { get; set; }
    }
}