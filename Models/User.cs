
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Models
{
    public class User
    {
        [Key]
        [MaxLength(36)]
        public string Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Bde> OwnerBdeList { get; set; } 
        public List<Member> BdeMemberList { get; set; }
        public List<Follower> BdeFollowList { get; set; }
        public List<Hype> Hypes { get; set; }
    }
}
