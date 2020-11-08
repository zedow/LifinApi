using LifinAPI.Dtos.EventDtos;
using LifinAPI.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.HypeDtos
{
    public class HypeReadDto
    {
        public UserReadDto User { get; set; }
        public EventReadDto Event { get; set; }
    }
}
