using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Dtos.BdeDtos;

namespace LifinAPI.Dtos.EventDtos
{
    public class UserEventReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public BdeReadDto Bde { get; set; }
        public bool IsHyped { get; set; }
    }
}
