using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Models
{
    public class Hype
    {
        [Key]
        [MaxLength(36)]
        public string UserId { get; set; }
        public User User { get; set; }
        [Key]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
