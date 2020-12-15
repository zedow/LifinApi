using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.EventDtos
{
    public class EventCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int BdeId { get; set; }
    }
}
