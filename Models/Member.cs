using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Models
{
    public class Member
    {
        public User User { get; set; }
        [MaxLength(36)]
        public string UserId { get; set; }
        public Bde Bde { get; set; }
        [MaxLength(36)]
        public int BdeId { get; set; }
        public string Role { get; set; }
    }
}
