using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models.Eventis
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}