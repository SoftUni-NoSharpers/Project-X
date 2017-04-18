using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models.Eventis
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public string Adress { get; set; }



        public ICollection<Event> Events { get; set; }

    }
}