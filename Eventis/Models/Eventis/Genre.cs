using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models.Eventis
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15
            , ErrorMessage = "Genre name cannot be less than 3 symbols"
            , MinimumLength = 3)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}