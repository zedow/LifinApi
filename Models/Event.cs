using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int BdeId { get; set; }
        public Bde Bde { get; set; }
        public List<Hype> Hypes { get; set; }
    }

    public class UserEvent : Event
    {
        public bool IsHyped { get; set; }
    }

}
