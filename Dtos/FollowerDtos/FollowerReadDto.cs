using LifinAPI.Dtos.BdeDtos;
using LifinAPI.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.FollowerDtos
{
    public class FollowerReadDto
    {
        public UserReadDto User { get; set; }
        public BdeReadDto Bde { get; set; }
        public DateTime Since { get; set; }
    }
}
