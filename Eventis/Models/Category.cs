using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eventis.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15
            , ErrorMessage = "Category name cannot be less than 5 symbols"
            , MinimumLength = 5)]
        public string Name { get; set; }
    }
}