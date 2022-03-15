using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetBackend.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="The title must be 100 characters or less.")]
        public string Title { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The host name must be 50 characters or less.")]
        public string Host { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The location must be 100 characters or less.")]
        public string Location { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }
    }
}
