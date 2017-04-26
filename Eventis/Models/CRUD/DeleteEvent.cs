using Eventis.Models.Eventis;
using Eventis.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eventis.Models.CRUD
{
    public class DeleteEvent
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string ImagePath { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime StartDate { get; set; }

        public string Category { get; set; }


        public Status Status { get; set; }

        public string Genre { get; set; }

        //Place Form

        public string Hall { get; set; }

        public string City { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ApplicationUser Author { get; set; }
    }
}