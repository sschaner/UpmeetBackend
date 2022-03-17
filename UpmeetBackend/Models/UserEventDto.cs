using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetBackend.Models
{
    public class UserEventDto
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
    }
}
