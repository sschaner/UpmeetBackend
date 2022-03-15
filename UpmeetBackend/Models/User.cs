using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetBackend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your first name must be 100 characters or less.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your last name must be 100 characters or less.")]
        public string LastName { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }
    }
}
