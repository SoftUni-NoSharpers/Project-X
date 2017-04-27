using Eventis.Models.Eventis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eventis.Models.CRUD
{
    public class CreateEvent
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }

        [DisplayName("Start Date")]
       
        public DateTime StartDate { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }

        
        public Status Status { get; set; }
        [DisplayName("Genre")]
        public string GenreName { get; set; }

        [DisplayName("Hall")]
        public string HallName { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }
    }
}