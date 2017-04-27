using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models.Eventis
{
    public class City
    {
        public City()
        {
            Halls = new HashSet<Hall>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }

        
    }
}