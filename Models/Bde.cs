using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LifinAPI.Models
{
    public class Bde
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public List<Event> Events { get; set; }
        public List<Member> Members { get; set; }
        public List<Follower> Followers { get; set; }
    }
}