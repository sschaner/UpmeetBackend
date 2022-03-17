using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetBackend.Models
{
    public class EventDto
    {
        public int EventId { get; set; }
       
        public string Title { get; set; }
       
        public string Host { get; set; }
        
        public string Description { get; set; }
        
        public string Location { get; set; }
       
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
    }
}
