using Eventis.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models
{
    public class Ticket
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Event Event { get; set; }

        public ApplicationUser Buyer { get; set; }
    }
}