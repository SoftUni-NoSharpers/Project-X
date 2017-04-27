using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models.Eventis
{
    public class Hall
    {
        public Hall()
        {
            Events = new HashSet<Event>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string Adress { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}