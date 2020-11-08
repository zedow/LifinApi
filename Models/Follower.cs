
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Models
{
    public class Follower
    {
        public User User { get; set; }
        [Key]
        public string UserId { get; set; }
        public Bde Bde { get; set; }
        [Key]
        public int BdeId { get; set; }
        public DateTime Since { get; set; }
    }
}
