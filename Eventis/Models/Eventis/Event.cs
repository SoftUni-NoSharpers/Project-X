using Eventis.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventis.Models.Eventis
{
    public class Event
    {
        private const int ContentMinimumLength = 5;

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100
            , ErrorMessage = "Title cannot be less than 5 symbols and more than 100 symbols"
            , MinimumLength = ContentMinimumLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(100
            , MinimumLength = 1
            , ErrorMessage = "Content cannot be less than 5 characters long")]
        public string Content { get; set; }

        public string ImagePath { get; set; }

        public int ViewCount { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        //public int CategoryId { get; set; }


        //[ForeignKey("CategoryId")]
        //public virtual Category Category { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        [Required]
        public Status Status { get; set; }


        public virtual ICollection<Contact> Contact { get; set; }
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]    
        public virtual Genre Genre { get; set; }
        
        public int HallId { get; set; }


        [ForeignKey("HallId")]
        public virtual Hall Hall { get; set; }
    }
}