using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models.Eventis
{
    public class Category
    {
        public Category()
        {
            Genres = new HashSet<Genre>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15
            , ErrorMessage = "Category name cannot be less than 5 symbols"
            , MinimumLength = 5)]
        public string Name { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}