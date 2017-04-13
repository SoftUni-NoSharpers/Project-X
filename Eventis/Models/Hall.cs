using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public City City { get; set; }

        public ICollection<Event> Events { get; set; }

    }
}