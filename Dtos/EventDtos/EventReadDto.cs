using LifinAPI.Dtos.BdeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.EventDtos
{
    public class EventReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public BdeReadDto Bde { get; set; }
    }
}
