using Eventis.Models.Eventis;
using Eventis.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventis.Models.CRUD
{
    public class DeleteEvent
    {
        public DeleteEvent()
        {
            Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string ImagePath { get; set; }


        public DateTime StartDate { get; set; }

        public string Category { get; set; }


        public Status Status { get; set; }

        public string Genre { get; set; }

        public string Hall { get; set; }

        public string City { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public ApplicationUser Author { get; set; }
    }
}