using Eventis.Models.Eventis;
using System;
using System.Collections.Generic;
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
        
        public string Content { get; set; }
        
        public string ImagePath { get; set; }
        

        public DateTime StartDate { get; set; }
        
        public string CategoryName { get; set; }

        
        public Status Status { get; set; }
        
        public string GenreName { get; set; }

        //Place Form
        
        public string HallName { get; set; }
        
        public string CityName { get; set; }
    }
}