using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetBackend.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public int userId { get; set; }
        public int EventId { get; set; }
    }
}
