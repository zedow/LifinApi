using LifinAPI.Dtos.BdeDtos;
using LifinAPI.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.MemberDtos
{
    public class MemberReadDto
    {
        public UserReadDto User { get; set; }
        public BdeReadDto Bde { get; set; }
        public string Role { get; set; }
    }
}
